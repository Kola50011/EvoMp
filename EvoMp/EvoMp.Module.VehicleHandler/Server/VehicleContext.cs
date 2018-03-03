using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;

namespace EvoMp.Module.VehicleHandler.Server
{
    /// <inheritdoc />
    /// <summary>
    /// Initialize the VehicleContext and contains the tables
    /// </summary>
    public class VehicleContext : DbContext
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor. Based on DbContext and loads the connection string
        /// </summary>
        public VehicleContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
            // Database logging
            //Database.Log = s => { };
        }

        /// <inheritdoc />
        /// <summary>
        ///     Overwriting Convention to allow private fields
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
        }

        /// <summary>
        /// Initalize the Vehicle Context, sets the migrator config and open the database connection
        /// </summary>
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

        /// <summary>
        /// Table: Vehicles
        /// Contains all ExtendedVehicles
        /// </summary>
        public DbSet<VehicleDto> Vehicles { get; set; }

        /// <summary>
        /// Table: VehicleDoorStates
        /// Contains for each vehicle the state of all doors
        /// </summary>
        public DbSet<DoorStateDto> DoorStates { get; set; }

        /// <summary>
        /// Table: VehicleModifications
        /// Contains possibilitys of vehicle modifications. (Slot and value)
        /// </summary>
        public DbSet<ModificationDto> Modifications { get; set; }

        /// <summary>
        /// Table: VehicleModificationMappings
        /// Contains the mapping for the VehicleModifications table for each vehicle
        /// </summary>
        public DbSet<VehicleModificationDto> VehicleModifications { get; set; }

        /// <summary>
        /// Table: VehicleColors
        /// Contains possibilitys of color combinations
        /// </summary>
        public DbSet<VehicleColorDto> VehicleColors { get; set; }

        /// <summary>
        /// Table: VehicleProperties
        /// Contains VehicleHash based fix properties
        /// </summary>
        public DbSet<VehiclePropertiesDto> VehicleProperties { get; set; }

        /// <summary>
        /// Table: VehicleLiveries
        /// Contains the possibilitys of VehicleHash and VehicleLiveries
        /// </summary>
        public DbSet<VehicleLiveryDto> VehicleLiveries { get; set; }

        #endregion Tables
    }
}
