using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EvoMp.Core.Core;
using EvoMp.Core.ConsoleHandler;
using GrandTheftMultiplayer.Server.Elements;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Attributes;

namespace EvoMp.Module.DbAccess
{
    public class DbCommands
    {
        public DbCommands(ICommandHandler commandHandler)
        {

        }

        [PlayerCommand("/testdb")]
        public void TestFunctionDatabase(Client sender)
        {
            ConsoleOutput.WriteLine(ConsoleType.Debug, "Test function in database module");

        }
    }
}