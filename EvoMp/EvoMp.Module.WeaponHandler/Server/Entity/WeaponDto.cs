using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.WeaponHandler.Server.Entity
{
    [Table("Weapons")]
    public class WeaponDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("WeaponId")]
        public int WeaponId { get; set; }

        [Required][Column("WeaponHash")]
        public WeaponHash WeaponHash { get; set; }

        [ForeignKey("WeaponHash")]
        public WeaponPropertiesDto WeaponProperties { get; set; }
        
        public ICollection<WeaponModificationDto> WeaponModification { get; set; }
    }
}
