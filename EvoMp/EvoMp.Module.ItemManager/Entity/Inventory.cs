using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.ItemManager.Items;

namespace EvoMp.Module.ItemManager.Entity
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("inventory_id")]
        public int Id { get; set; }

        [Column("items")]
        public List<IBaseItem> Items { get; set; }

        public Inventory()
        {
            Items = new List<IBaseItem>();
        }
    }
}