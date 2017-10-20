using EvoMp.Module.ItemManager.Entity;
using EvoMp.Module.ItemManager.Items;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;

namespace EvoMp.Module.ItemManager.Controller
{
    class InventoryController
    {
        private Inventory _owningInventory;

        public InventoryController(Inventory inventory)
        {
            _owningInventory = inventory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">Item to add</param>
        /// <returns></returns>
        public bool AddItem(InventoryItem item)
        {
            return false;
        }
    }

    class InventoryCommands : Script
    {
        [Command("showinventory", "Benutzung : /showinventory")]
        public void ShowInventory(Client player)
        {
            if (!(player.getData("INVENTORY") is Inventory inventory))
                return;

            foreach (var item in inventory.Items)
            {
                player.sendChatMessage($"~g~{item.BaseItem.ItemName}");
            }
        }

        [Command("additem", "Benutzung : /additem [itemname / id] [ammount]")]
        public void AddItem(Client player, string itemName, int ammount)
        {
            if (!(player.getData("INVENTORY") is Inventory inventory))
                return;

            inventory.Items.Add(InventoryRepository.Instance.GetNewInventoryItem<Apple>());
        }
    }
}
