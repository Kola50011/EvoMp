using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.VehicleHandler.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class VehicleCommands
    {
        private readonly API _api;
        private readonly IVehicleHandler _vehicleHandler;

        public VehicleCommands(API api, IVehicleHandler vehicleHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
        }

        [PlayerCommand("/v")]
        public void TestVehicleCommand(Client sender, string vehicleName)
        {
            List<VehicleHash> possibleVehicles = VehicleUtils.Server.VehicleUtils.GetVehiclesByName(vehicleName);

            // No vehicle found -> message & return
            if (!possibleVehicles.Any())
            {
                _api.sendChatMessageToPlayer(sender, $"There is no vehicle like ~o~{vehicleName}~w~ .");
                return;
            }

            // Create new vehicle
            NetHandle newVehicle = _api.createVehicle(possibleVehicles.First(), sender.position,
                sender.rotation, 1, 1,
                sender.dimension);

            foreach (DoorState doorState in Enum.GetValues(typeof(DoorState)))
                API.shared.setVehicleDoorState(newVehicle, (int)doorState, true);

            sender.setIntoVehicle(newVehicle, -1);

            _api.sendChatMessageToPlayer(sender,
                $"Vehicle ~o~{possibleVehicles.First()}~w~ ~c~(~w~{VehicleUtils.Server.VehicleUtils.GetVehicleCategory(possibleVehicles.First())}~c~) ~w~created.");
            _api.sendNotificationToPlayer(sender, $"~w~Alternative Vehicles: ~g~{string.Join(",", possibleVehicles)}");
        }

        [PlayerCommand("/togglealldoors", playerOnlyState: PlayerOnlyState.OnlyAsDriver)]
        public void SetAllVehicleDoors(Client sender, bool state)
        {
            // Change door state
            foreach (DoorState doorState in Enum.GetValues(typeof(DoorState)))
                API.shared.setVehicleDoorState(sender.vehicle, (int) doorState, state);
        }
    }
}
