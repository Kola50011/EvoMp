using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;

namespace EvoMp.Module.ItemManager.Entity
{
    public class InventoryRepository
    {
        private readonly Dictionary<Type, BaseItem> _itemsDictionary = new Dictionary<Type, BaseItem>();

        private static volatile InventoryRepository _instance;
        private static readonly object singeltonLock = new object();

        public static InventoryRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (singeltonLock)
                    {
                        if (_instance == null)
                            _instance = new InventoryRepository();
                    }
                }

                return _instance;
            }
        }

        private InventoryRepository()
        {
            new InventoryContext().FirstInit();
        }

        public InventoryContext GetInventoryContext()
        {
            return new InventoryContext();
        }

        public void LoadItemsIntoDatabase()
        {
            using (var inventoryContext = GetInventoryContext())
            {
                foreach (var itemType in Assembly.GetExecutingAssembly().GetTypes().Where(c => !c.IsAbstract && c.IsSubclassOf(typeof(BaseItem))))
                {
                    inventoryContext.Items.AddOrUpdate((BaseItem)Activator.CreateInstance(itemType));
                }

                inventoryContext.SaveChanges();

                foreach (var item in inventoryContext.Items)
                {
                    _itemsDictionary[item.GetType()] = item;
                }
            }
        }

        /// <summary>
        /// Return the stored instance of an item inside the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Item Obj derives from BaseItem</returns>
        public T GetBaseItem<T>() where T : BaseItem
        {
            return (T)_itemsDictionary[typeof(T)];
        }

        /// <summary>
        /// Creates a new InventoryItem which should be store inside the inventory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>New InventoryItem</returns>
        public InventoryItem GetNewInventoryItem<T>() where T : BaseItem
        {
            return new InventoryItem(GetBaseItem<T>());
        }

        /// <summary>
        /// Returns the users inventory if exists else creates a new one and returns it
        /// </summary>
        /// <param name="socialClubName"></param>
        /// <returns>Inventory Obj</returns>
        public Inventory CreateOrGetExistingInventory(string socialClubName)
        {
            using (var inventoryContext = GetInventoryContext())
            {
                var inventory = inventoryContext.Inventories.FirstOrDefault(inv => inv.SocialClubName == socialClubName);
                return inventory ?? inventoryContext.Inventories.Add(new Inventory { SocialClubName = socialClubName });
            }
        }
    }
}