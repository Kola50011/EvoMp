using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.WeaponHandler.Server.Entity
{
    [Table("WeaponModificationMapping")]
    public class WeaponModificationDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int WeaponId { get; set; }

        [ForeignKey("WeaponId")]
        public WeaponDto Weapon { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public int ModificationId { get; set; }

        [ForeignKey("ModificationId")] public ModificationDto Modification { get; set; }

    }
}
