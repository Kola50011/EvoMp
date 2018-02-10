using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using static EvoMp.Module.VehicleUtils.Server.VehicleUtils;

namespace EvoMp.Module.TestModule.Debuging
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
            List<VehicleHash> possibleVehicles = GetVehiclesByName(vehicleName);

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

            sender.setIntoVehicle(newVehicle, -1);

            _api.sendChatMessageToPlayer(sender,
                $"Vehicle ~o~{possibleVehicles.First()}~w~ ~c~(~w~{GetVehicleCategory(possibleVehicles.First())}~c~) ~w~created.");
            _api.sendNotificationToPlayer(sender, $"~w~Alternative Vehicles: ~g~{string.Join(",", possibleVehicles)}");
        }
    }
}
