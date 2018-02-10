using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleUtils.Server.Enums;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleDoorStates")]
    public class DoorStateDto
    {
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        [Column(Order = 0)]
        public VehicleDto Vehicle { get; set; }

        [Key]
        [Column("Door", Order = 1)]
        public DoorState Door { get; set; }

        [Column("State")]
        public bool State { get; set; }
    }
}
