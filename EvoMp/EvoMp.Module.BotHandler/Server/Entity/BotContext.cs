using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;

namespace EvoMp.Module.BotHandler.Server.Entity
{
    public class BotContext : DbContext
    {
        public BotContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
            // Database logging
            //Database.Log = s => { };
        }

        /// <inheritdoc />
        /// <summary>
        ///  Overwriting Convention to allow private fields
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
        }

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

        public DbSet<BotDto> Bots { get; set; }
        public DbSet<BotWaypointDto> BotWaypoints { get; set; }
        #endregion Tables
    }
}
