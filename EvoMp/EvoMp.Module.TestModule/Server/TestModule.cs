using System;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.TestModule.Server
{
    public class TestModule : ITestModule
    {
        private readonly API _api;
        private readonly IVehicleHandler _vehicleHandler;
        public CommandTests TestInitialized = new CommandTests();

        public TestModule(API api, ICommandHandler commandHandler, IVehicleHandler vehicleHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
        }

        [PlayerCommand("/test")]
        public void TestCommand(Client sender)
        {
            _api.sendChatMessageToPlayer(sender, "Test command runned.");
            _api.setEntityInvincible(sender, false);
            _api.freezePlayer(sender, false);
            _api.setEntityTransparency(sender, 255);
            _api.setEntityCollisionless(sender, false);
        }


        [PlayerCommand("/v")]
        public void TestVehicleCommand(Client sender, string vehicleName)
        {
            VehicleHash possibleVehicleHash = (VehicleHash) (-1);

            // Name like
            foreach (VehicleHash vehicleHash in Enum.GetValues(typeof(VehicleHash)))
                if (vehicleName.ToLower() == $"{vehicleHash}".ToLower())
                {
                    possibleVehicleHash = vehicleHash;
                    break;
                }

            //Name starts with
            if (possibleVehicleHash == (VehicleHash) (-1))
                foreach (VehicleHash vehicleHash in Enum.GetValues(typeof(VehicleHash)))
                    if ($"{vehicleHash}".ToLower().StartsWith(vehicleName.ToLower()))
                    {
                        possibleVehicleHash = vehicleHash;
                        break;
                    }

            //Name contains
            if (possibleVehicleHash == (VehicleHash) (-1))
                foreach (VehicleHash vehicleHash in Enum.GetValues(typeof(VehicleHash)))
                    if ($"{vehicleHash}".ToLower().Contains(vehicleName.ToLower()))
                    {
                        possibleVehicleHash = vehicleHash;
                        break;
                    }

            // No vehicle found -> message & return
            if (possibleVehicleHash == (VehicleHash) (-1))
            {
                _api.sendChatMessageToPlayer(sender, $"There is no vehicle like~o~{vehicleName}~w~ .");
                return;
            }

            // Create new vehicle
            NetHandle newVehicle = _api.createVehicle(possibleVehicleHash, sender.position, sender.rotation, 0, 0,
                sender.dimension);
            _api.setPlayerIntoVehicle(sender, newVehicle, -1);
            _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{possibleVehicleHash}~w~ created.");
        }
    }
}
