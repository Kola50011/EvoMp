using EvoMp.Module.CommandHandler;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.TestModule.Server.Debuging;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.TestModule.Server
{
    public class TestModule : ITestModule
    {
        private readonly API _api;
        private readonly IVehicleHandler _vehicleHandler;
        private readonly IMessageHandler _messageHandler;
        public LoginFucker LoginFucker;
        public VehicleCommands VehicleCommands;
        public CommandHelp CommandHelp;
        public ExtendedVehicleTest ExtendedVehicleTest;

        public TestModule(API api, ICommandHandler commandHandler, IVehicleHandler vehicleHandler, IMessageHandler messageHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
            _messageHandler = messageHandler;
            LoginFucker = new LoginFucker(api, messageHandler);
            CommandHelp = new CommandHelp(api, commandHandler, messageHandler);
            ExtendedVehicleTest = new ExtendedVehicleTest(api, vehicleHandler, messageHandler);

            VehicleCommands = new VehicleCommands(api, vehicleHandler);
        }
    }
}
