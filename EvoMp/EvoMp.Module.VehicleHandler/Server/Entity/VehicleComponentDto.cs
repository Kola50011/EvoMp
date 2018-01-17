using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleComponentMappings")]
    public class VehicleComponentDto
    {
        [Key]
        public VehicleDto Vehicle { get; set; }

        [Key, Column(Order = 1)]
        public ComponentDto Component { get; set; }
    }
}
