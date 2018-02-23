using System;
using System.Collections.Generic;
using EvoMp.Module.BotHandler.Server.Entity;
using EvoMp.Module.ClientWrapper.Server;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.BotHandler.Server
{
    public class Tracking
    {
        private readonly API _api;
        private readonly IClientWrapper _clientWrapper;
        private readonly IEventHandler _eventHandler;
        private const int updateIntervall = 50; // 100ms
        private DateTime lastStep = DateTime.Now;

        public Tracking(API api, IClientWrapper clientWrapper, IEventHandler eventHandler)
        {
            _api = api;
            _clientWrapper = clientWrapper;
            _eventHandler = eventHandler;
            // TODO: Write update handler
            api.onUpdate += OnUpdateEvent;

            // Disable Logging for this massive events
            _eventHandler.SetLogging("ClientWrapper.Set.setEntityVelocity", false);
            _eventHandler.SetLogging("ClientWrapper.Set.setEntityRotation", false);
            
        }

        private void OnUpdateEvent()
        {
            //// Update only in interval steps
            //if (lastStep.AddMilliseconds(updateIntervall) > DateTime.Now)
            //    return;
            //lastStep = DateTime.Now;

            // Recordings
            foreach (ExtendedBot extendedBot in BotModule.RecordingBots)
            {
                // Leaved vehicle -> stop record
                if (!extendedBot.Owner.Client.isInVehicle)
                {
                    extendedBot.StopRecording();
                    continue;
                }

                // Add Waypoint
                extendedBot.AddWaypoint(extendedBot.Owner.Client.vehicle);
            }

            // Playbacks
            foreach (ExtendedBot extendedBot in BotModule.PlaybackBots.ToArray())
            {
                BotWaypointDto nextWaypoint = extendedBot.GetNextWaypoint();
                if (nextWaypoint == null)
                {
                    extendedBot.StopPlayback();
                    continue;
                }


                foreach (Client player in _api.getAllPlayers())
                {
                    _clientWrapper.Setter.SetEntityVelocity(player, extendedBot.Vehicle.Vehicle, nextWaypoint.Velocity);
                    _clientWrapper.Setter.SetEntityRotation(player, extendedBot.Vehicle.Vehicle, nextWaypoint.Rotation);
                }
            }
        }
    }
}
