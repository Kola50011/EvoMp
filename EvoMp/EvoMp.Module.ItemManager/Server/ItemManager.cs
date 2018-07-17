using System;
using System.Linq;
using EvoMp.Core.Module.Server;
using EvoMp.Module.ItemManager.Entity;
using EvoMp.Module.ItemManager.Items;

namespace EvoMp.Module.ItemManager.Server
{
    public class ItemManager : BaseModule, IItemManager
    {
        public InventoryRepository InventoryRepository;

        public ItemManager()
        {

        }

        /// <summary>
        /// Only for testing purpose. //TODO Remove
        /// </summary>
        public void TestFunction()
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
                inventoryContext.Inventories.First().Items.ForEach(item => Console.WriteLine("Item " + item.GetSomething()));
            }
        }
    }
}
