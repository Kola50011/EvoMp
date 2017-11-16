﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EvoMp.Core.Core;
using EvoMp.Core.ModuleProperties;
using EvoMp.Core.ConsoleHandler;

namespace EvoMp.Module.DbAccess
{
   
    public class DbAccess : IDbAccess
    {
        public DbAccess()
        {
            string dbConnectionString = Environment.GetEnvironmentVariable("EvoMp_dbConnectionString");

            if (dbConnectionString == null)
                Environment.SetEnvironmentVariable("NameOrConnectionString",
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EvoMpGtMpServer;Integrated Security=True;" +
                    "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
                    "MultiSubnetFailover=False;MultipleActiveResultSets = True;");
            else
                Environment.SetEnvironmentVariable("NameOrConnectionString",
                    Environment.GetEnvironmentVariable("EvoMp_dbConnectionString"));

            List<string> connectionParameters = (Environment.GetEnvironmentVariable("NameOrConnectionString") ?? "").
                                                 Split(';').ToList();

            // Write console output
            ConsoleOutput.WriteLine(ConsoleType.Database,
                $"Database: ~#8effa3~{connectionParameters.Find(s => s.ToLower().StartsWith("initial catalog"))?.Trim()}");
        }
    }
}