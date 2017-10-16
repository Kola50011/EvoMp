using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.ItemManager.Entity
{
    /// <summary>
    /// The Inventory Item is an virtual Item, based on the BaseItem and the foreign key of the owning inventory
    /// This item is pushed back into the players inventory
    /// </summary>
    public class InventoryItem
    {
        public InventoryItem(BaseItem baseItem, int durability = 100)
        {
            BaseItem = baseItem;
            Durability = durability;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ItemId { get; set; }
        public Inventory OwnerInventory { get; set; }
        public BaseItem BaseItem { get; set; }
        public int Durability { get; set; }
    }
}
