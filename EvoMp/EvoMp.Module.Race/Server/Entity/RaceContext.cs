using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;

namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    ///     Context responsible
    /// </summary>
    public class RaceContext : DbContext
    {
        /// <inheritdoc />
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
        ///     Gets called on server launch for automatic migrations
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
        ///     All races
        /// </summary>
        public DbSet<RaceDto> Races { get; set; }

        /// <summary>
        ///     All checkpoints currently associated with races
        /// </summary>
        public DbSet<RaceCheckpointDto> RaceCheckpoints { get; set; }

        /// <summary>
        ///     All vehicles currently associated with races
        /// </summary>
        public DbSet<RaceVehicleDto> RaceVehicles { get; set; }

        /// <summary>
        /// </summary>
        public DbSet<RaceSpawnpointDto> RaceSpawnPoints { get; set; }

        #endregion
    }
}
