using System;
using System.Data.Entity;

namespace EvoMp.Module.ItemManager.Entity
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<BaseItem> Items { get; set; }

        public void FirstInit()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<InventoryContext>());
            //DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<InventoryContext>();
            //migratorConfig.AutomaticMigrationsEnabled = true;
            //migratorConfig.AutomaticMigrationDataLossAllowed = true;

            //DbMigrator dbMigrator = new DbMigrator(migratorConfig);
            //dbMigrator.Update();

            //Database.Connection.Open();

            //Console.WriteLine("Drop Database Inventories? (y/n)");
            //if (Console.ReadLine() == "y")
            //{
            //    foreach (Inventory inventory in Inventories.ToList())
            //        Inventories.Remove(inventory);

            //    foreach (var item in Items)
            //        Items.Remove(item);

            //    SaveChanges();
            //}
        }
    }
}