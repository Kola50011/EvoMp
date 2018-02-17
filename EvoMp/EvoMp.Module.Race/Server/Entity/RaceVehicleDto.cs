using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Entity;

namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    /// Vehicles avalible to a race
    /// </summary>
    public class RaceVehicleDto
    {
        /// <summary>
        ///     Foreign key to the race the Vehicle belongs to
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int RaceId { get; set; }

        /// <summary>
        ///     Foreign key to the race the Vehicle belongs to
        /// </summary>
        [ForeignKey("RaceId")]
        public RaceDto RaceDto { get; set; }

        /// <summary>
        ///     Foreign key to a vehicle avalible for a race
        /// </summary>
        public int VehicleId { get; set; }

        /// <summary>
        ///     Foreign key to a vehicle avalible for a race
        /// </summary>
        [Key]
        [Column(Order = 2)]
        [ForeignKey("VehicleId")]
        public VehicleDto VehicleDto { get; set; }
    }
}
