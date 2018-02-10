using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using static EvoMp.Module.VehicleUtils.Server.VehicleUtils;

namespace EvoMp.Module.TestModule.Debuging
{
    public class ExtendedVehicleTest
    {
        private readonly API _api;
        private readonly IVehicleHandler _vehicleHandler;

        public ExtendedVehicleTest(API api, IVehicleHandler vehicleHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
        }

        [PlayerCommand("/dbvehicle", new[] {"/dbv"})]
        public void SaveVehicle(Client sender, string vehicleName)
        {
            List<VehicleHash> possibleVehicles = GetVehiclesByName(vehicleName);

            // No vehicle found -> message & return
            if (!possibleVehicles.Any())
            {
                _api.sendChatMessageToPlayer(sender, $"There is no vehicle like ~o~{vehicleName}~w~ .");
                return;
            }

            // Create new vehicle
            ExtendedVehicle newExtendedVehicle =
                new ExtendedVehicle(possibleVehicles.First(), sender.position, sender.rotation, sender.dimension);
            newExtendedVehicle.Create();


            _api.sendChatMessageToPlayer(sender,
                $"Vehicle ~o~{possibleVehicles.First()}~w~ ~c~(~w~{GetVehicleCategory(possibleVehicles.First())}~c~)~w~ created.");
            sender.setIntoVehicle(newExtendedVehicle.VehicleHandle, -1);

            newExtendedVehicle.Save();
            _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{possibleVehicles.First()}~w~ saved.");
        }


        [PlayerCommand("/dbvUFull", playerOnlyState: PlayerOnlyState.OnlyInVehicle)]
        public void UpdateVehicleFull(Client sender)
        {
            ExtendedVehicle extendedVehicle = new ExtendedVehicle(sender.vehicle);
            extendedVehicle.Save();

            _api.sendChatMessageToPlayer(sender, $"VehicleID: {extendedVehicle.Properties.VehicleId}");
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
