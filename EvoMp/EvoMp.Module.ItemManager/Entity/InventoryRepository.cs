namespace EvoMp.Module.ItemManager.Entity
{
    public class InventoryRepository
    {
        public InventoryRepository()
        {
            //new InventoryContext().FirstInit();
            GetInventoryContext();
        }

        public InventoryContext GetInventoryContext()
        {
            return new InventoryContext();
        }
    }
}