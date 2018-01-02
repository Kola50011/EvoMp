using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.Elements;

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