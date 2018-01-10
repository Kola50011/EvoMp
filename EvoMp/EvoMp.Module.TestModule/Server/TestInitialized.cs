using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Server
{
    public class TestInitialized
    {
        [PlayerCommand("/testDoubleCommandName")]
        public void TestDoubleCommandName(Client sender)
        {
        }

        [PlayerCommand("/testDoubleCommandName")]
        public void TestDoubleCommandName2(Client sender)
        {
        }

        [PlayerCommand("/testDoubleCommandAlias", new[] {"/alias1", "/alias2", "/alias3"})]
        public void TestDoubleCommandAlias(Client sender)
        {
        }

        [PlayerCommand("/testDoubleCommandAlias2", new[] {"/alias1a", "/alias2", "/alias3b"})]
        public void TestDoubleCommandAlias2(Client sender)
        {
        }
    }
}