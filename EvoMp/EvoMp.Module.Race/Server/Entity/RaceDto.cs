using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    /// The main race DTO
    /// </summary>
    public class RaceDto
    {
        /// <summary>
        /// Primary key for race.
        /// Auto Incrementing
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("RaceId")]
        public int RaceId { get; set; }

        /// <summary>
        /// The Name of a race.
        /// Unique
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        public string RaceName { get; set; }

        /// <summary>
        /// The checkpoints for the race
        /// </summary>
        public ICollection<RaceCheckpointDto> Checkpoints { get; set; }

        /// <summary>
        /// The spawnpoints for the race
        /// </summary>
        public ICollection<RaceSpawnpointDto> Spawnpoints { get; set; }

        /// <summary>
        /// The vehicles for the race
        /// </summary>
        public ICollection<RaceVehicleDto> Vehicles { get; set; }

    }
}
