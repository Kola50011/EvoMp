using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using FuelType = EvoMp.Module.VehicleHandler.Server.Enums.FuelType;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("VehicleProperties")]
    public class VehiclePropertiesDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required]
        [Column("VehicleHash")]
        public VehicleHash VehicleHash { get; set; }

        [Column("VehicleClass")]
        private VehicleClass VehicleClass { get; set; }

        [Column("DisplayName")]
        public string DisplayName { get; set; }

        [Column("TankSize")]
        public double TankSize { get; set; }

        [Column("Consumption")]
        public double Consumption { get; set; }

        [Column("FuelType")]
        public FuelType FuelType { get; set; }

        [Column("TrunkSize")]
        public double TrunkSize { get; set; }

        [Column("DoorCount")]
        public int DoorCount { get; set; }

        [Column("BuildYear")]
        public int BuildYear { get; set; }

        [Column("MaxSpeed")]
        public double MaxSpeed { get; set; }

        [Column("Comment")]
        public string Comment { get; set; }
    }
}
