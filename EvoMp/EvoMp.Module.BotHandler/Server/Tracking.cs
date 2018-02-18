using System;
using System.Collections.Generic;
using EvoMp.Module.BotHandler.Server.Entity;
using EvoMp.Module.ClientWrapper.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.BotHandler.Server
{
    public class Tracking
    {
        private readonly API _api;
        private readonly IClientWrapper _clientWrapper;
        private const int updateIntervall = 100; // 100ms
        private DateTime lastStep = DateTime.Now;
        public Tracking(API api, IClientWrapper clientWrapper)
        {
            _api = api;
            _clientWrapper = clientWrapper;
            // TODO: Write update handler
            api.onUpdate += OnUpdateEvent;
        }

        private void OnUpdateEvent()
        {
            // Update only in interval steps
            if (lastStep.AddMilliseconds(updateIntervall) > DateTime.Now)
                return;
            lastStep = DateTime.Now;

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
                extendedBot.AddWaypoint();
            }

            // Playbacks
            foreach (ExtendedBot extendedBot in BotModule.PlaybackBots)
            {
                BotWaypointDto nextWaypoint = extendedBot.GetNextWaypoint();
                if (nextWaypoint == null)
                {
                    extendedBot.StopPlayback();
                    continue;
                }

                foreach (Client player in _api.getAllPlayers())
                    _clientWrapper.Setter.SetEntityVelocity(player, extendedBot.Vehicle.Vehicle, nextWaypoint.Velocity);
            }
        }
    }
}
