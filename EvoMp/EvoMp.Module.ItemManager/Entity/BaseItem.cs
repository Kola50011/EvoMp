using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.ItemManager.Entity
{
    /// <summary>
    /// The BaseItem in an unique item database entry
    /// </summary>
    [Table("BaseItems")]
    public abstract class BaseItem
    {
        /// <summary>
        /// Unique BaseItem Identifier
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ItemId { get; set; }
        /// <summary>
        /// BaseItem Display name
        /// </summary>
        public virtual string ItemName { get; set; }
        /// <summary>
        /// Weight aka. Space the item uses in your inventory
        /// </summary>
        public virtual int Weight { get; set; }
        /// <summary>
        /// True if the item is illegal
        /// </summary>
        public virtual bool Illigal { get; set; }
        /// <summary>
        /// Called when you press use
        /// </summary>
        public virtual void Use() { }
    }
}
