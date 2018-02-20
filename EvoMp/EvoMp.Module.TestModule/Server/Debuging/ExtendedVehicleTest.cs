using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class ExtendedVehicleTest
    {
        private readonly API _api;
        private readonly IMessageHandler _messageHandler;
        private readonly IVehicleHandler _vehicleHandler;

        public ExtendedVehicleTest(API api, IVehicleHandler vehicleHandler, IMessageHandler messageHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
            _messageHandler = messageHandler;
        }

       


        [PlayerCommand("/dbvUFull", playerOnlyState: PlayerOnlyState.OnlyInVehicle)]
        public void UpdateVehicleFull(Client sender)
        {
            ExtendedVehicle extendedVehicle = new ExtendedVehicle(sender.vehicle);
            extendedVehicle.FullUpdate();
            extendedVehicle.Save();
        }


        [PlayerCommand("/dbvDestroy", playerOnlyState: PlayerOnlyState.OnlyInVehicle)]
        public void DestroyVehicle(Client sender)
        {
            ExtendedVehicle extendedVehicle = new ExtendedVehicle(sender.vehicle);
            extendedVehicle.Destroy(true);
        }

        [PlayerCommand("/dbvspawn")]
        public void SpawnVehicle(Client sender, int vehicleId)
        {
            ExtendedVehicle extendedVehicle = new ExtendedVehicle(vehicleId);
            extendedVehicle.Create();
        }
    }
}
