using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;
using EvoMp.Module.Race.Server.Entity;

namespace EvoMp.Module.Race.Server
{
    /// <inheritdoc />
    /// <summary>
    ///     Initialize the RaceContext and contains the tables
    /// </summary>
    public class RaceContext : DbContext
    {
        /// <inheritdoc />
        /// <summary>
        ///     Constructor. Based on DbContext and loads the connection string
        /// </summary>
        public RaceContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
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
        ///     Initalize the Race Context, sets the migrator config and open the database connection
        /// </summary>
        public void FirstInit()
        {
            Database.SetInitializer<RaceContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<RaceContext>
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
        ///     Table: Races
        ///     All races
        /// </summary>
        public DbSet<RaceDto> Races { get; set; }

        /// <summary>
        ///     Table: RaceCheckpoints
        ///     All checkpoints currently associated with races
        /// </summary>
        public DbSet<RaceCheckpointDto> RaceCheckpoints { get; set; }

        /// <summary>
        ///     Table: RaceVehicles
        ///     All vehicles currently associated with races
        /// </summary>
        public DbSet<RaceVehicleDto> RaceVehicles { get; set; }

        /// <summary>
        ///     Table: RaceSpawnpoints
        ///     Contains the spawnpoints for a race
        /// </summary>
        public DbSet<RaceSpawnpointDto> RaceSpawnPoints { get; set; }

        #endregion
    }
}
