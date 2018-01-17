using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.TestModule.Server.TestingStateExtras;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

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


        private VehicleHash GetVehicleByName(string vehicleName)
        {
            // Name like
            foreach (VehicleHashTestingStage vehicleHash in Enum.GetValues(typeof(VehicleHashTestingStage)))
                if (vehicleName.ToLower() == $"{vehicleHash}".ToLower())
                    return (VehicleHash) vehicleHash;

            //Name starts with
            foreach (VehicleHashTestingStage vehicleHash in Enum.GetValues(typeof(VehicleHashTestingStage)))
                if ($"{vehicleHash}".ToLower().StartsWith(vehicleName.ToLower()))
                    return (VehicleHash) vehicleHash;

            //Name contains
            foreach (VehicleHashTestingStage vehicleHash in Enum.GetValues(typeof(VehicleHashTestingStage)))
                if ($"{vehicleHash}".ToLower().Contains(vehicleName.ToLower()))
                    return (VehicleHash) vehicleHash;

            return (VehicleHash) (-1);
        }

        [PlayerCommand("/v")]
        public void TestVehicleCommand(Client sender, string vehicleName)
        {
            VehicleHash possibleVehicleHash = GetVehicleByName(vehicleName);

            // No vehicle found -> message & return
            if (possibleVehicleHash == (VehicleHash) (-1))
            {
                _api.sendChatMessageToPlayer(sender, $"There is no vehicle like ~o~{vehicleName}~w~ .");
                return;
            }

            // Create new vehicle
            NetHandle newVehicle = _api.createVehicle(possibleVehicleHash, sender.position,
                sender.rotation, 1, 1,
                sender.dimension);

            _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{possibleVehicleHash}~w~ created.");
            sender.setIntoVehicle(newVehicle, -1);
        }


        [PlayerCommand("/saveVehicle", new[] {"/sv"})]
        public void SaveVehicle(Client sender, string vehicleName)
        {
            VehicleHash possibleVehicleHash = GetVehicleByName(vehicleName);

            // No vehicle found -> message & return
            if (possibleVehicleHash == (VehicleHash)(-1))
            {
                _api.sendChatMessageToPlayer(sender, $"There is no vehicle like ~o~{vehicleName}~w~ .");
                return;
            }

            // Create new vehicle
            ExtendedVehicle newExtendedVehicle = new ExtendedVehicle(possibleVehicleHash, sender.position, sender.rotation, sender.dimension);
            NetHandle newVehicle = newExtendedVehicle.Create();
            _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{possibleVehicleHash}~w~ created.");
            sender.setIntoVehicle(newVehicle, -1);

            //TODO: Testing
            newExtendedVehicle.Save();
            _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{possibleVehicleHash}~w~ saved.");

        }
    }
}
