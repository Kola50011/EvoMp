namespace EvoMp.Module.ItemManager.Entity
{
    public class InventoryRepository
    {
        public InventoryRepository()
        {
            new InventoryContext().FirstInit();
        }

        public InventoryContext GetInventoryContext()
        {
            return new InventoryContext();
        }
    }
}