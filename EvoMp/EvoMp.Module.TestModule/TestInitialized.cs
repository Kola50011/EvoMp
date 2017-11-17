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
    public class TestInitialized
    {
        [PlayerCommand("/testDoubleCommandName")]
        public void testDoubleCommandName(Client sender)
        {
        }

        [PlayerCommand("/testDoubleCommandName")]
        public void testDoubleCommandName2(Client sender)
        {
        }

        [PlayerCommand("/testDoubleCommandAlias", new []{"/alias1", "/alias2", "/alias3"})]
        public void testDoubleCommandAlias(Client sender)
        {
        }

        [PlayerCommand("/testDoubleCommandAlias2", new[] { "/alias1a", "/alias2", "/alias3b" })]
        public void testDoubleCommandAlias2(Client sender)
        {
        }
    }
}