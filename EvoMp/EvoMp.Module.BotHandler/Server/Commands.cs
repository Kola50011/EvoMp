using System.Linq;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Util;

namespace EvoMp.Module.BotHandler.Server
{
    public class Commands
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IVehicleHandler _vehicleHandler;

        public Commands(IMessageHandler messageHandler, IVehicleHandler vehicleHandler)
        {
            _messageHandler = messageHandler;
            _vehicleHandler = vehicleHandler;
        }

        [PlayerCommand("/RecordBot", new[] {"/rbot"}, PlayerOnlyState.OnlyAsDriver)]
        public void RecordNewBot(Client sender, string botName)
        {
            ExtendedBot newRecord = new ExtendedBot(sender, botName);
            if (newRecord.IsRecording)
            {
                _messageHandler.PlayerMessage(sender, "Already recording an bot!", MessageType.Error);
                return;
            }

            if (newRecord.Properties.Waypoints.Any())
            {
                _messageHandler.PlayerMessage(sender, "Bot exist already!", MessageType.Error);
                return;
            }

            newRecord.StartRecording();
            _messageHandler.PlayerMessage(sender, $"Recording started for bot ~b~{botName}", MessageType.Info);
        }

        [PlayerCommand("/stoprRecodBot", new[] {"/sbot"}, PlayerOnlyState.OnlyAsDriver)]
        public void StopRecordBot(Client sender)
        {
            ExtendedBot currenRecordingBot =
                BotModule.RecordingBots.FirstOrDefault(bot => bot.IsRecording && bot.Owner.Client == sender);

            if (currenRecordingBot == null)
            {
                _messageHandler.PlayerMessage(sender, "Don't recording", MessageType.Error);
                return;
            }

            currenRecordingBot.StopRecording();
            _messageHandler.PlayerMessage(sender,
                $"Recording bot ~b~{currenRecordingBot.Properties.BotName} ~w~stopped. Saving..", MessageType.Info);
        }

        [PlayerCommand("/playbot", new[] {"/pbot"})]
        public void PlaybackBot(Client sender, string botName)
        {
            ExtendedBot playBot = new ExtendedBot(sender, botName);
            playBot.StartPlayBack();
            _messageHandler.PlayerMessage(sender, $"Playback of bot {botName} started.", MessageType.Info);
        }
    }
}
