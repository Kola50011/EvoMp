using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Attributes;
using EvoMp.Module.EventHandler;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule
{
    public class TestModule : ITestModule
    {
        private readonly API _api;
        public TestInitialized TestInitialized = new TestInitialized();

        public TestModule(API api, ICommandHandler commandHandler)
        {
            _api = api;
        }

        [PlayerCommand("/test")]
        public void TestCommand(Client sender)
        {
            _api.sendChatMessageToPlayer(sender, "Test command runned.");
        }
    }
}
