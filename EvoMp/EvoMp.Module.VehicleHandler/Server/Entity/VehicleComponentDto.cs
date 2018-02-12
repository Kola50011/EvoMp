using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleComponentMappings")]
    public class VehicleComponentDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public VehicleDto Vehicle { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public int ComponentId { get; set; }
        
        [ForeignKey("ComponentId")]
        public ComponentDto Component { get; set; }
    }
}
