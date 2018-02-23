using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleUtils.Server.Enums;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleDoorStates")]
    public class DoorStateDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")] public VehicleDto Vehicle { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Door", Order = 1)]
        public DoorState Door { get; set; }

        [Column("State")] public bool State { get; set; }
    }
}
