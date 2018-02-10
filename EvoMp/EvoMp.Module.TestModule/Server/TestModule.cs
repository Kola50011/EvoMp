using EvoMp.Module.CommandHandler;
using EvoMp.Module.TestModule.Debuging;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.TestModule.Server
{
    public class TestModule : ITestModule
    {
        private readonly API _api;
        private readonly IVehicleHandler _vehicleHandler;
        public LoginFucker LoginFucker;
        public VehicleCommands VehicleCommands;
        public CommandHelp CommandHelp;

        public TestModule(API api, ICommandHandler commandHandler, IVehicleHandler vehicleHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
            LoginFucker = new LoginFucker(api);
            CommandHelp = new CommandHelp(api, commandHandler);
           
            VehicleCommands = new VehicleCommands(api, vehicleHandler);
        }
    }
}
