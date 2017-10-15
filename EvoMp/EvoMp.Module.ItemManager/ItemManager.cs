using System;
using System.Linq;
using EvoMp.Module.ItemManager.Entity;
using EvoMp.Module.ItemManager.Items;

namespace EvoMp.Module.ItemManager
{
    public class ItemManager : IItemManager
    {
        public InventoryRepository _inventoryRepository;
        public ItemManager()
        {
            _inventoryRepository = new InventoryRepository();

            Inventory testInventory = new Inventory();
            testInventory.Items.Add(new Apple());
            testInventory.Items.Add(new Apple());
            testInventory.Items.Add(new Knife());

            using (InventoryContext inventoryContext = _inventoryRepository.GetInventoryContext())
            {
                inventoryContext.Inventories.Add(testInventory);
                inventoryContext.SaveChanges();
            }

            using (InventoryContext inventoryContext = _inventoryRepository.GetInventoryContext())
            {
                foreach (IBaseItem item in inventoryContext.Inventories.First().Items)
                {
                    Console.WriteLine("Item " + item.GetSomething());
                }
            }

        }

        public string ModuleName { get; } = "ItemManager";
        public string ModuleDesc { get; } = "Handles everything that has to do with items";
        public string ModuleAuth { get; } = "Koka, Lukas";
    }
}