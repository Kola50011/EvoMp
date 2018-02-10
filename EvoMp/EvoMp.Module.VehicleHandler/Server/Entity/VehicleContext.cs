using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleContext : DbContext
    {
        public VehicleContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
            // Database logging
            Database.Log = s => { };
        }

        // Overwriting Convention to allow private fields
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
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

        #region Tables

        public DbSet<VehicleDto> Vehicles { get; set; }

        public DbSet<DoorStateDto> DoorStates { get; set; }

        //public DbSet<ComponentDto> Components { get; set; }

        //public DbSet<VehicleComponentDto> VehicleComponents { get; set; }

        public DbSet<VehicleColorDto> VehicleColors { get; set; }

        #endregion Tables
    }
}
