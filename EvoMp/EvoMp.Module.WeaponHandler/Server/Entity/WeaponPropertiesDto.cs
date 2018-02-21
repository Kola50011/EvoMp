using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.WeaponHandler.Server.Entity
{
    [Table("WeaponProperties")]
    public class WeaponPropertiesDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required]
        [Column("WeaponHash")]
        public WeaponHash WeaponHash { get; set; }

        [Column("WeaponName")]
        public string WeaponName { get; set; }

        [Column("WeaponType")]
        public WeaponType WeaponType { get; set; }

        [Column("Ammunition")]
        public int Ammunition { get; set; }

        [Column("WeaponAmmoType")]
        public WeaponAmmoType WeaponAmmoType { get; set; }

        [Column("WeaponTint")]
        public WeaponTint WeaponTint { get; set; }

        // really nessesary?
        [Column("Comment")]
        public string Comment { get; set; }
    }
}
