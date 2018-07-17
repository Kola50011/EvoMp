using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;
using EvoMp.Module.MapHandler.Server.Entity;

namespace EvoMp.Module.MapHandler.Server
{
    /// <inheritdoc />
    /// <summary>
    ///     Initialize the MapContext and contains the tables
    /// </summary>
    public class MapContext : DbContext
    {
        /// <inheritdoc />
        /// <summary>
        ///     Constructor. Based on DbContext and loads the connection string
        /// </summary>
        public MapContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
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
        ///     Initalize the Map Context, sets the migrator config and open the database connection
        /// </summary>
        public void FirstInit()
        {
            Database.SetInitializer<MapContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<MapContext>
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
        ///     Table: Maps
        ///     Contains all Maps
        /// </summary>
        public DbSet<MapDto> Maps { get; set; }

        /// <summary>
        ///     Table: MapObjects
        ///     Contains all MapObjects
        /// </summary>
        public DbSet<MapObjectDto> MapObjects { get; set; }

        #endregion Tables
    }
}
