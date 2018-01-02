using System;
using System.Linq;
using EvoMp.Module.ItemManager.Entity;
using EvoMp.Module.ItemManager.Items;

namespace EvoMp.Module.ItemManager.Server
{
    public class ItemManager : IItemManager
    {
        public InventoryRepository InventoryRepository;

        public ItemManager()
        {
            InventoryRepository = new InventoryRepository();

            Inventory testInventory = new Inventory();
            testInventory.Items.Add(new Apple());
            testInventory.Items.Add(new Apple());
            testInventory.Items.Add(new Knife());

            using (InventoryContext inventoryContext = InventoryRepository.GetInventoryContext())
            {
                inventoryContext.Inventories.Add(testInventory);
                inventoryContext.SaveChanges();
            }

            using (InventoryContext inventoryContext = InventoryRepository.GetInventoryContext())
            {
                foreach (IBaseItem item in inventoryContext.Inventories.First().Items)
                    Console.WriteLine("Item " + item.GetSomething());
            }
        }
    }
}