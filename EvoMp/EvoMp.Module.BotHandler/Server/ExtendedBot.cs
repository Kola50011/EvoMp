using System;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.BotHandler.Server.Entity;
using EvoMp.Module.BotHandler.Server.Exceptions;
using EvoMp.Module.ClientHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.BotHandler.Server
{
    public class ExtendedBot
    {
        private const string EntityDataStringRecording = "BotHandler.Recording";
        public readonly ExtendetClient Owner;
        private int _currentWaypoint;
        public bool IsRecording;
        public BotDto Properties;
        public ExtendedVehicle Vehicle;

        public ExtendedBot(Client sender, string botName)
        {
            Owner = BotHandler.ClientHandler.GetExtendetClient(sender);
            IsRecording = API.shared.hasEntityData(sender, EntityDataStringRecording) &&
                          API.shared.getEntityData(sender, EntityDataStringRecording);

            // Get Properties
            using (BotContext context = BotRepository.GetBotContext())
            {
                Properties = context.Bots.FirstOrDefault(dto =>
                    dto.BotName.ToLower() == botName.ToLower() && dto.OwnerId == Owner.Properties.Id);
            }

            if (Properties == null)
                InitNew(botName);
            else
                Vehicle = BotHandler.VehicleHandler.CreateExtendedVehicle(Properties.VehicleId);

            if (IsRecording)
            {
                ExtendedBot cBot = BotHandler.RecordingBots
                    .First(bot => bot.Properties.BotId == Properties.BotId);
                Properties.Waypoints = cBot.Properties.Waypoints;
                Properties.Vehicle = cBot.Vehicle.Properties;
            }
            else
            {
                using (BotContext context = BotRepository.GetBotContext())
                {
                    Properties.Waypoints =
                        context.BotWaypoints.Where(dto => dto.BotId == Properties.BotId).ToList();
                    Properties.Vehicle = Vehicle.Properties;
                    Properties.Owner = Owner.Properties;
                }
            }


            Debug("ExtendedBot inited");
        }

        private void SaveWaypoints()
        {
            Debug($"Saving waypoints. {DateTime.Now}");
            using (BotContext context = BotRepository.GetBotContext())
            {
                foreach (BotWaypointDto waypoint in Properties.Waypoints)
                    context.BotWaypoints.Add(waypoint);

                context.SaveChanges();
            }

            Debug($"Waypoints saved. {DateTime.Now}");
        }

        private void InitNew(string botName)
        {
            // Create new ExtendedVehicle by copy
            Vehicle = BotHandler.VehicleHandler.CreateExtendedVehicle(Owner.Client.vehicle).Copy();
            Vehicle.Save();
            Debug("Extended Vehicle created and saved");

            using (BotContext context = BotRepository.GetBotContext())
            {
                // Create new & save
                Properties = context.Bots.Add(new BotDto
                {
                    VehicleId = Vehicle.Properties.VehicleId,
                    OwnerId = Owner.Properties.Id,
                    BotName = botName
                });
                context.SaveChanges();
            }

            Debug("Extended Bot created and saved.");

            Properties.Vehicle = Vehicle.Properties;
            Properties.Owner = Owner.Properties;
        }


        public void StartRecording()
        {
            // Is already recording -> Exception
            if (IsRecording)
                throw new RecordingException($"Player {Owner.Client.name} is already recording");

            IsRecording = true;
            API.shared.setEntityData(Owner.Client, EntityDataStringRecording, IsRecording);
            BotHandler.RecordingBots.Add(this);
            Debug("Start recording");
        }

        public void StopRecording()
        {
            // Is not recording -> Exception
            if (!IsRecording)
                throw new RecordingException($"Player {Owner.Client.name} is currently not recording");

            IsRecording = false;
            API.shared.setEntityData(Owner.Client, EntityDataStringRecording, false);
            BotHandler.RecordingBots.Remove(this);
            SaveWaypoints();
            Debug("Stopped recording");
        }

        private void Debug(string message)
        {
            string botId = Properties?.BotId.ToString() ?? "X";
            message = $"(ExtendedBot) [ID: {botId}] {message}";
            ConsoleOutput.WriteLine(ConsoleType.Debug, message);
            MessageHandler.Server.MessageHandler.BroadcastMessage(message, MessageType.Debug);
        }


        public void StartPlayBack()
        {
            if (BotHandler.PlaybackBots.Contains(this))
                throw new PlaybackException($"Bot {Properties.BotName} is already playing");

            Vehicle.Create();
            BotHandler.PlaybackBots.Add(this);
            Debug("Started playback");
        }

        public void StopPlayback()
        {
            if (!BotHandler.PlaybackBots.Contains(this))
                throw new PlaybackException($"Bot {Properties.BotName} isn't playing");

            Vehicle.Destroy(false);
            BotHandler.PlaybackBots.Remove(this);
            Debug("Stop playback");
        }

        public void AddWaypoint(NetHandle recordVehicle)
        {
            Properties.Waypoints.Add(new BotWaypointDto
            {
                BotId = Properties.BotId,
                Position = API.shared.getEntityPosition(recordVehicle),
                Rotation = API.shared.getEntityRotation(recordVehicle),
                Velocity = API.shared.getEntityVelocity(recordVehicle)
            });
        }

        public BotWaypointDto GetNextWaypoint()
        {
            if (_currentWaypoint > Properties.Waypoints.Count - 1)
                return null;

            _currentWaypoint++;
            return Properties.Waypoints.ToList()[_currentWaypoint - 1];
        }
    }
}
