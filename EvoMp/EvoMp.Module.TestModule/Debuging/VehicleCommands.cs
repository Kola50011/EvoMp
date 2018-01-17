using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.TestModule.Server.TestingStateExtras;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.TestModule.Debuging
{
    public class VehicleCommands
    {
        private readonly API _api;

        public VehicleCommands(API api)
        {
            _api = api;
        }

        [PlayerCommand("/v")]
        public void TestVehicleCommand(Client sender, string vehicleName)
        {
            VehicleHashTestingStage possibleVehicleHash = (VehicleHashTestingStage)(-1);

            // Name like
            foreach (VehicleHashTestingStage vehicleHash in Enum.GetValues(typeof(VehicleHashTestingStage)))
                if (vehicleName.ToLower() == $"{vehicleHash}".ToLower())
                {
                    possibleVehicleHash = vehicleHash;
                    break;
                }

            //Name starts with
            if (possibleVehicleHash == (VehicleHashTestingStage)(-1))
                foreach (VehicleHashTestingStage vehicleHash in Enum.GetValues(typeof(VehicleHashTestingStage)))
                    if ($"{vehicleHash}".ToLower().StartsWith(vehicleName.ToLower()))
                    {
                        possibleVehicleHash = vehicleHash;
                        break;
                    }

            //Name contains
            if (possibleVehicleHash == (VehicleHashTestingStage)(-1))
                foreach (VehicleHashTestingStage vehicleHash in Enum.GetValues(typeof(VehicleHashTestingStage)))
                    if ($"{vehicleHash}".ToLower().Contains(vehicleName.ToLower()))
                    {
                        possibleVehicleHash = vehicleHash;
                        break;
                    }

            // No vehicle found -> message & return
            if (possibleVehicleHash == (VehicleHashTestingStage)(-1))
            {
                _api.sendChatMessageToPlayer(sender, $"There is no vehicle like~o~{vehicleName}~w~ .");
                return;
            }

            // Create new vehicle
            NetHandle newVehicle = _api.createVehicle((VehicleHash)possibleVehicleHash, sender.position,
                sender.rotation, 1, 1,
                sender.dimension);
            //_api.vehicle
            _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{possibleVehicleHash}~w~ created.");
            sender.setIntoVehicle(newVehicle, 0);
            sender.setIntoVehicle(newVehicle, -1);
        }
    }
}
