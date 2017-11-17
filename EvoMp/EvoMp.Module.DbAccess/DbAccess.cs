using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EvoMp.Core.Core;
using EvoMp.Core.ConsoleHandler;
using GrandTheftMultiplayer.Server.Elements;
using EvoMp.Module.CommandHandler;

namespace EvoMp.Module.DbAccess
{
   
    public class DbAccess : IDbAccess
    {
        public DbAccess()
        {
            const string dataBaseName = "EvoMpGtMpServer";
            string dbConnectionString = Environment.GetEnvironmentVariable("EvoMp_dbConnectionString");

            if (dbConnectionString == null)
                Environment.SetEnvironmentVariable("NameOrConnectionString",
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=" + dataBaseName +";Integrated Security=True;" +
                    "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
                    "MultiSubnetFailover=False;MultipleActiveResultSets = True;");
            else
                Environment.SetEnvironmentVariable("NameOrConnectionString",
                    Environment.GetEnvironmentVariable("EvoMp_dbConnectionString"));
            
            // Write console output
            ConsoleOutput.WriteLine(ConsoleType.Database,
                $"Database: ~#8effa3~{dataBaseName}");
        }
    }
}