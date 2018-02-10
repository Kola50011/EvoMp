using System;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.TestModule.Debuging;
using EvoMp.Module.TestModule.Server.TestingStateExtras;
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
        public LoginFucker LoginFucker;
        public VehicleCommands VehicleCommands;

        public TestModule(API api, ICommandHandler commandHandler, IVehicleHandler vehicleHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
            LoginFucker = new LoginFucker(api, commandHandler);
            VehicleCommands = new VehicleCommands(api, vehicleHandler);
        }


       
    }
}
