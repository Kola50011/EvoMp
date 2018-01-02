using EvoMp.Core.Module.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Server
{
    public class TestNotInitializedClass
    {
        [PlayerCommand("/invalidTest")]
        public void TestFunction(Client sender)
        {
        }

        [PlayerCommand("/staticTest")]
        public static void StaticTestFunction(Client sender)
        {
            Shared.Api.sendChatMessageToPlayer(sender, "Static command entered!");
        }
    }
}