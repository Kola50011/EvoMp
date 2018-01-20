using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleDoorStates")]
    public class DoorStateDto
    {
        [Key]
        [Column(Order = 0)]
        public VehicleDto Vehicle { get; set; }

        [Key]
        [Column("Door", Order = 1)]
        public int Door { get; set; }

        [Column("State")]
        public bool State { get; set; }
    }
}
