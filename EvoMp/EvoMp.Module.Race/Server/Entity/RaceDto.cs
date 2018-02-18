using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    /// The main race DTO
    /// </summary>
    [Table("Races")]
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
        [Index("IX_RaceName", IsUnique = true)]
        [Required]
        [StringLength(60)]
        [Column("RaceName", Order = 1, TypeName = "NVARCHAR")]
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
