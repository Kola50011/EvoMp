using EvoMp.Module.ItemManager.Entity;
using EvoMp.Module.ItemManager.Interfaces;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.ItemManager
{
    public class ItemManager : IItemManager
    {
        private readonly API _api;
        public InventoryRepository InventoryRepository = InventoryRepository.Instance;

        public ItemManager(API api)
        {
            _api = api;
            _api.onPlayerDisconnected += _api_onPlayerDisconnected;
            //Just for testing
            _api.onPlayerConnected += _api_onPlayerConnected;
            //Loads all Item : BaseItem inside this assembly into the database
            InventoryRepository.LoadItemsIntoDatabase();
        }

        private void _api_onPlayerConnected(Client player)
        {
            player.setData("INVENTORY", CreateOrGetExistingInventory(player.socialClubName));
        }

        private async void _api_onPlayerDisconnected(Client player, string reason)
        {
            //Save the inventory if the player disconnects
            using (var inventoryContext = InventoryRepository.GetInventoryContext())
            {
                await inventoryContext.SaveChangesAsync();
            }
        }

        public Inventory CreateOrGetExistingInventory(string socialClubName)
        {
            return InventoryRepository.CreateOrGetExistingInventory(socialClubName);
        }

        public string ModuleName { get; } = "ItemManager";
        public string ModuleDesc { get; } = "Handles everything that has to do with items";
        public string ModuleAuth { get; } = "Koka, Lukas, S0PEX";
    }
}