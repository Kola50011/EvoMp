using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.DbAccess
{
    public class DbCommands2
    {
        public DbCommands2(ICommandHandler commandHandler)
        {
        }

        [PlayerCommand("/testdb3")]
        public void TestFunctionDatabase(Client sender)
        {
            ConsoleOutput.WriteLine(ConsoleType.Debug, "Test function in database module");
        }
    }
}