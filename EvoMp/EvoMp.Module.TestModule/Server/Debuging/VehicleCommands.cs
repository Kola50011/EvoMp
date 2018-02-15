using System;
using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.VehicleHandler.Server;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

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
            Vehicle newVehicle = _api.createVehicle(possibleVehicles.First(), sender.position,
                sender.rotation, 1, 1,
                sender.dimension);

            newVehicle.waitForSynchronization(200);

            sender.setIntoVehicle(newVehicle, -1);

            _api.sendChatMessageToPlayer(sender,
                $"Vehicle ~o~{possibleVehicles.First()}~w~ ~c~(~w~{(VehicleClass)API.shared.getVehicleClass(possibleVehicles.First())}~c~) ~w~created.");
            _api.sendNotificationToPlayer(sender, $"~w~Alternative Vehicles: ~g~{string.Join(",", possibleVehicles)}");
        }

        [PlayerCommand("/togglealldoors", playerOnlyState: PlayerOnlyState.OnlyAsDriver)]
        public void SetAllVehicleDoors(Client sender, bool state)
        {
            // Change door state
            foreach (DoorState doorState in Enum.GetValues(typeof(DoorState)))
                API.shared.setVehicleDoorState(sender.vehicle, (int) doorState, state);
        }

        [PlayerCommand("/setvmod", playerOnlyState: PlayerOnlyState.OnlyAsDriver)]
        public void SetVehicleMod(Client sender, VehicleModification slot, int value)
        {
            API.shared.setVehicleMod(sender.vehicle, (int) slot, value);
        }

        [PlayerCommand("/rvmod", playerOnlyState: PlayerOnlyState.OnlyAsDriver)]
        public void SetRandomVehicleMod(Client sender)
        {
            Random random = new Random();
            foreach (VehicleModification modification in Enum.GetValues(typeof(VehicleModification)))
                API.shared.setVehicleMod(sender.vehicle, (int) modification, random.Next(0, 5));
        }

        [PlayerCommand("/rvcolor", playerOnlyState: PlayerOnlyState.OnlyAsDriver)]
        public void SetRandomVehicleColors(Client sender)
        {
            Random random = new Random();
            API.shared.setVehicleCustomPrimaryColor(sender.vehicle, random.Next(0, 255), random.Next(0, 255),
                random.Next(0, 255));
            API.shared.setVehicleCustomSecondaryColor(sender.vehicle, random.Next(0, 255), random.Next(0, 255),
                random.Next(0, 255));
        }
    }
}
