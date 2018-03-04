using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;
using EvoMp.Module.ClientHandler.Server.Entity;

namespace EvoMp.Module.ClientHandler.Server
{
    /// <inheritdoc />
    /// <summary>
    /// Initialize the ClientContext and contains the tables
    /// </summary>
    public class ClientContext : DbContext
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor. Based on DbContext and loads the connection string
        /// </summary>
        public ClientContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
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
        /// Initalize the Client Context, sets the migrator config and open the database connection
        /// </summary>
        public void FirstInit()
        {
            Database.SetInitializer<ClientContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<ClientContext>
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
        /// Table: Clients
        /// Contains all ExtendedClients
        /// </summary>
        public DbSet<ClientDto> Clients { get; set; }

        #endregion Tables
    }
}
