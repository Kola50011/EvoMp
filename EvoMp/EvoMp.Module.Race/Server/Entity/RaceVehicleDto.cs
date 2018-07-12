using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Entity;

namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    ///     Vehicles avalible to a race
    /// </summary>
    [Table("RaceVehicles")]
    public class RaceVehicleDto
    {
        /// <summary>
        ///     The id column
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("RaceVehicleId")]
        public int RaceVehicleId { get; set; }

        /// <summary>
        ///     Foreign key to the race the Vehicle belongs to
        /// </summary>
        [Index("IX_RaceVehicle", 1, IsUnique = true)]
        [Column("RaceId", Order = 0)]
        public int RaceId { get; set; }

        /// <summary>
        ///     Foreign key to the race the Vehicle belongs to
        /// </summary>
        [ForeignKey("RaceId")]
        public RaceDto RaceDto { get; set; }

        /// <summary>
        ///     Foreign key to a vehicle avalible for a race
        /// </summary>
        [Index("IX_RaceVehicle", 2, IsUnique = true)]
        [Column("VehicleId")]
        public int VehicleId { get; set; }

        /// <summary>
        ///     Vehicle avalible for a race
        ///     //TODO: Koka fragen, warum man fahrzeuge für ein race speichern muss.
        ///     //TODO: werden die nicht immer frisch erstellt und dann gelöscht?
        /// </summary>
        [ForeignKey("VehicleId")]
        [NotMapped]
        public VehicleDto VehicleDto { get; set; }
    }
}
