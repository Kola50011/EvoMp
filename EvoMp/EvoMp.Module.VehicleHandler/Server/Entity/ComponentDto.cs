using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleComponents")]
    public class ComponentDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public VehicleDto ComponentId { get; set; }

        [Key, Column("Slot", Order = 1)]
        public int Slot { get; set; }

        [Key, Column("Value", Order = 2)]
        public int Value { get; set; }

    }
}
