using EvoMp.Module.ClientWrapper.Server;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.TestModule.Server.Debuging;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.TestModule.Server
{
    public class TestModule : ITestModule
    {
        public ClientWrapperTest ClientWrapperTest;
        public CommandHelp CommandHelp;
        public ExtendedVehicleTest ExtendedVehicleTest;
        public LoginFucker LoginFucker;
        public VehicleCommands VehicleCommands;

        public TestModule(API api, ICommandHandler commandHandler, IVehicleHandler vehicleHandler,
            IMessageHandler messageHandler, IClientWrapper clientWrapper)
        {
            LoginFucker = new LoginFucker(api, messageHandler);
            CommandHelp = new CommandHelp(api, commandHandler, messageHandler);
            ExtendedVehicleTest = new ExtendedVehicleTest(api, vehicleHandler, messageHandler);

            VehicleCommands = new VehicleCommands(api, vehicleHandler);
            ClientWrapperTest = new ClientWrapperTest(clientWrapper);
        }
    }
}
