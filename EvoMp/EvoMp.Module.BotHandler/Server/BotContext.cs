using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;
using EvoMp.Module.BotHandler.Server.Entity;

namespace EvoMp.Module.BotHandler.Server
{
    /// <inheritdoc />
    /// <summary>
    ///     Initialize the BotContext and contains the tables
    /// </summary>
    public class BotContext : DbContext
    {
        /// <inheritdoc />
        /// <summary>
        ///     Constructor. Based on DbContext and loads the connection string
        /// </summary>
        public BotContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
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
        ///     Initalize the Bot Context, sets the migrator config and open the database connection
        /// </summary>
        public void FirstInit()
        {
            Database.SetInitializer<BotContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<BotContext>
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
        ///     Table: Bots
        ///     Contains all recorded bots
        /// </summary>
        public DbSet<BotDto> Bots { get; set; }

        /// <summary>
        ///     Table: BotWaypoints
        ///     Contains all recorded Waypoints for a bot
        /// </summary>
        public DbSet<BotWaypointDto> BotWaypoints { get; set; }

        #endregion Tables
    }
}
