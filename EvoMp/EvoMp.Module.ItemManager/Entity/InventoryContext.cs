using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace EvoMp.Module.ItemManager.Entity
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
        }

        public DbSet<Inventory> Inventories { get; set; }

        public void FirstInit()
        {
            Database.SetInitializer<InventoryContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<InventoryContext>();
            migratorConfig.AutomaticMigrationsEnabled = true;
            migratorConfig.AutomaticMigrationDataLossAllowed = true;

            DbMigrator dbMigrator = new DbMigrator(migratorConfig);
            dbMigrator.Update();

            Database.Connection.Open();

           /**/
        }
    }
}