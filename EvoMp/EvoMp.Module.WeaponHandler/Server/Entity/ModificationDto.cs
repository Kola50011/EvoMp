using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared.Gta.Weapon;

namespace EvoMp.Module.WeaponHandler.Server.Entity
{
    [Table("WeaponModification")]
    public class ModificationDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ModificationId { get; set; }

        [Index("IX_SlotAndValue", 1, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public WeaponComponent Slot { get; set; }


        // save or not save 
        /*[Index("IX_SlotAndValue", 2, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool Value { get; set; }*/


    }
}
