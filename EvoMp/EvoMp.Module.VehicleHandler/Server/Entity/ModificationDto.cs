using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleModifications")]
    public class ModificationDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ModificationId { get; set; }

        [Index("IX_SlotAndValue", 1, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public VehicleModType Slot { get; set; }

        [Index("IX_SlotAndValue", 2, IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Value { get; set; }
    }
}
