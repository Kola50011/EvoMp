using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using EvoMp.Core.Module.Server;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {

        }

        // Tables
        public DbSet<VehicleMap> Vehicles { get; set; }

        public void Init()
        {
            Database.SetInitializer<VehicleContext>(null);
            Database.Connection.Open();

            //Vehicles.First()
        }

        public void FirstInit()
        {
            Database.SetInitializer<VehicleContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<VehicleContext>
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true
            };

            DbMigrator dbMigrator = new DbMigrator(migratorConfig);

            dbMigrator.Update();

            Database.Connection.Open();
        }
    }
}
