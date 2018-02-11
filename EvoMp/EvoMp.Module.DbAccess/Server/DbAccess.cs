using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Core.Parameter.Server;
using EvoMp.Module.CommandHandler;

namespace EvoMp.Module.DbAccess.Server
{
    public class DbAccess : IDbAccess
    {
        public DbAccess(ICommandHandler commandHandler)
        {
            // Get Database name from Parameter
            ParameterHandler.SetDefault("DatabaseName", "EvoMpGtMpServer");
            string dataBaseName = ParameterHandler.GetValue("DatabaseName");

            SetConnectionString();

            void SetConnectionString()
            {
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
            }

            // Init reset procedure if database reset wanted.
            if (ParameterHandler.GetValue("ResetDatabase") != null)
            {
                string sqlCommandText = $"DROP DATABASE {dataBaseName}";
                dataBaseName = "Reset";
                SetConnectionString();
                string nameOrConnectionString = Environment.GetEnvironmentVariable("NameOrConnectionString");
                if (nameOrConnectionString != null)
                {
                    SqlConnection connection = new SqlConnection(nameOrConnectionString);
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }

            // Write console output
            ConsoleOutput.WriteLine(ConsoleType.Database,
                $"Database: ~#8effa3~{dataBaseName}");

            // If Database reset -> restart
            Shared.OnCoreStartupCompleted += () =>
            {
                if (ParameterHandler.GetValue("ResetDatabase") == null)
                    return;

                List<string> startArguments = Environment.GetCommandLineArgs().ToList();
                startArguments.RemoveAt(0);

                Process.Start(Environment.GetCommandLineArgs()[0],
                    $"{string.Join(" ", startArguments).Replace("-ResetDatabase", "")}");
                Process.GetCurrentProcess().Kill();
            };
        }


        [ConsoleCommand("/resetDatabase",
            importantCommand: true, description:
            "Wipes the complete Database. (Server restarts 2 Times to fool the Entity Framework Migrations.)")]
        public void ResetDatabaseConsoleCommand()
        {
            List<string> startArguments = Environment.GetCommandLineArgs().ToList();
            startArguments.RemoveAt(0);

            Process.Start(Environment.GetCommandLineArgs()[0], $"{string.Join(" ", startArguments)} -ResetDatabase");
            Process.GetCurrentProcess().Kill();
        }
    }
}
