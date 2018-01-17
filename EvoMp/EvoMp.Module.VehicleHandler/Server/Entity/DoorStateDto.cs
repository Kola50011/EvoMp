using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleDoorStates")]
    public class DoorStateDto
    {
        [Key, Column(Order = 0)]
        public VehicleDto Vehicle { get; set; }

        [Key, Column("Door", Order = 1)]
        public int Door { get; set; }

        [Column("State")]
        public bool State { get; set; }
    }
}
