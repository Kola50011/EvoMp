using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleComponentMappings")]
    public class VehicleComponentDto
    {
        [Key]
        public VehicleDto Vehicle { get; set; }

        [Key]
        [Column(Order = 1)]
        public ComponentDto Component { get; set; }
    }
}
