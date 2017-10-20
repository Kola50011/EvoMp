using System.Data.Entity;

namespace EvoMp.Module.ItemManager.Entity
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base(/*Environment.GetEnvironmentVariable("NameOrConnectionString")*/
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EvoMpGtMpServerTest1;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False;MultipleActiveResultSets = True;")
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<BaseItem> Items { get; set; }

        public void FirstInit()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<InventoryContext>());
        }
    }
}