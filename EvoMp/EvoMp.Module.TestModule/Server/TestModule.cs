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
        public TestInitialized TestInitialized = new TestInitialized();

        public TestModule(API api, ICommandHandler commandHandler, IVehicleHandler vehicleHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
        }

        [PlayerCommand("/test")]
        public void TestCommand(Client sender)
        {
            _api.sendChatMessageToPlayer(sender, "Test command runned.");
        }


        [PlayerCommand("/v")]
        public void TestVehicleCommand(Client sender, string vehicleName)
        {
            foreach (VehicleHash vehicleHash in Enum.GetValues(typeof(VehicleHash)))
                if (vehicleName.ToLower() == $"{vehicleHash}".ToLower())
                {
                    NetHandle newVehicle = _api.createVehicle(vehicleHash, sender.position, sender.rotation, 0, 0,
                        sender.dimension);
                    _api.setPlayerIntoVehicle(sender, newVehicle, -1);
                    _api.sendChatMessageToPlayer(sender, $"Vehicle ~o~{vehicleHash}~w~ created.");


                    // Create new Database vehicle entry
                    //ExtendedVehicle newTestVehicle = new ExtendedVehicle(vehicleHash, sender.position, sender.rotation);
                    // save enw Database vehcile entry
                    //newTestVehicle.Save();
                }
        }
    }
}
