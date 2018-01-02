using System;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.DbAccess.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.DbAccess
{
    public class DbAccess : IDbAccess
    {
        public DbCommands2 DbCommands2;


        public DbAccess(ICommandHandler commandHandler)
        {
            const string dataBaseName = "EvoMpGtMpServer";
            string dbConnectionString = Environment.GetEnvironmentVariable("EvoMp_dbConnectionString");

            if (dbConnectionString == null)
                Environment.SetEnvironmentVariable("NameOrConnectionString",
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=" + dataBaseName +
                    ";Integrated Security=True;" +
                    "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
                    "MultiSubnetFailover=False;MultipleActiveResultSets = True;");
            else
                Environment.SetEnvironmentVariable("NameOrConnectionString",
                    Environment.GetEnvironmentVariable("EvoMp_dbConnectionString"));

            // Write console output
            ConsoleOutput.WriteLine(ConsoleType.Database,
                $"Database: ~#8effa3~{dataBaseName}");

            // Debug
            DbCommands = new DbCommands(commandHandler);
            DbCommands2 = new DbCommands2(commandHandler);
        }

        public DbCommands DbCommands { get; set; }

        [PlayerCommand("/testdb2")]
        public void TestFunctionDatabase2(Client sender)
        {
            ConsoleOutput.WriteLine(ConsoleType.Debug, "Test function in database module");
        }
    }
}