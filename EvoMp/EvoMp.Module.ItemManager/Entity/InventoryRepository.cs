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

        public InventoryRepository()
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
                    ////Linq to entity doesnt know GetType, so we have to interate everything by hand
                    //if (!inventoryContext.Items.Any())
                    //{
                    //    inventoryContext.Items.Add((BaseItem)Activator.CreateInstance(itemType));
                    //}
                    //else
                    //{
                    //    foreach (var contextItem in inventoryContext.Items)
                    //    {
                    //        if (contextItem.GetType() != itemType)
                    //        {
                    //            inventoryContext.Items.Add((BaseItem)Activator.CreateInstance(itemType));
                    //        }
                    //    }
                    //}
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
            var inventory = GetInventoryContext().Inventories.First(inv => inv.SocialClubName == socialClubName);
            return inventory ?? GetInventoryContext().Inventories.Add(new Inventory { SocialClubName = socialClubName });
        }
    }
}