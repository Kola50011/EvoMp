using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.ItemManager.Entity
{
    [Table("Inventories")]
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int InventoryId { get; set; }
        /// <summary>
        /// Used as the unique identifier for the user
        /// </summary>
        public string SocialClubName { get; set; }

        public virtual ICollection<InventoryItem> Items { get; set; } = new Collection<InventoryItem>();
    }
}