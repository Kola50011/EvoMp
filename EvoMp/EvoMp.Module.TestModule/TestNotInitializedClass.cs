using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Core.Module;
using EvoMp.Module.CommandHandler.Attributes;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule
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