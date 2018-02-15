using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Core.Parameter.Server;
using EvoMp.Module.CommandHandler.Server;

namespace EvoMp.Module.DbAccess.Server
{
    public class DbAccess : IDbAccess
    {
        public DbAccess(ICommandHandler commandHandler)
        {
            // Get Database name from Parameter
            ParameterHandler.SetDefault("DatabaseName", "EvoMpGtMpServer");
            string dataBaseName = ParameterHandler.GetValue("DatabaseName");
            // Write console output
            ConsoleOutput.WriteLine(ConsoleType.Database, $"Database: ~#8effa3~{dataBaseName}");

            SetConnectionString();

            void SetConnectionString(bool force = false)
            {
                string dbConnectionString = Environment.GetEnvironmentVariable("EvoMp_dbConnectionString");

#if __MonoCS__
                string connectionString = "Data Source=localhost\\SQLEXPRESS;" +
                                          "Initial Catalog=" + dataBaseName + ";" +
                                          "User ID=EvoMp; " +
                                          "Password=evomp;" +
                                          "Integrated Security=True;" +
                                          "Connect Timeout=30;" +
                                          "Encrypt=False;" +
                                          "MultipleActiveResultSets=True;";
#else
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                          "Initial Catalog=" + dataBaseName +
                                          ";Integrated Security=True;" +
                                          $"Connect Timeout=30;" +
                                          $"Encrypt=False;" +
                                          $"TrustServerCertificate=True;" +
                                          $"ApplicationIntent=ReadWrite;" +
                                          "MultiSubnetFailover=False;" +
                                          "MultipleActiveResultSets = True;";
#endif

                if (dbConnectionString == null || force)
                    Environment.SetEnvironmentVariable("NameOrConnectionString", connectionString);
                else
                    Environment.SetEnvironmentVariable("NameOrConnectionString",
                        Environment.GetEnvironmentVariable("EvoMp_dbConnectionString"));
            }
        }


        [ConsoleCommand("/resetDatabase",
            importantCommand: true, description:
            "Wipes the complete Database. (Server restarts 2 Times to fool the Entity Framework Migrations.)")]
        public void ResetDatabaseConsoleCommand()
        {
            //TODO: Linux support
#if __MonoCS__
            ConsoleOutput.WriteLine(ConsoleType.Error, "Currently not supported on Linux. See #23");
#else
            List<string> startArguments = Environment.GetCommandLineArgs().ToList();
            startArguments.RemoveAt(0);

            Process.Start(Environment.GetCommandLineArgs()[0], $"{string.Join(" ", startArguments)} -ResetDatabase");
            Process.GetCurrentProcess().Kill();
#endif
        }
    }
}
