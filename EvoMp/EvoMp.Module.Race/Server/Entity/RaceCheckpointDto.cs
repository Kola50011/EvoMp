using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    /// A checkpoint for one race.
    /// All checkpoints together form a course
    /// </summary>
    [Table("RaceCheckpoints")]
    public class RaceCheckpointDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RaceCheckpointId", Order = 0)]
        public int RaceCheckpointId { get; set; }
        /// <summary>
        /// Foreign key to the race the checkpoint belongs to 
        /// </summary>
        [Index("IX_RaceCheckpointNumber", 1, IsUnique = true)]
        [Column("RaceId")]
        public int RaceId { get; set; }

        /// <summary>
        /// Foreign key to the race the checkpoint belongs to
        /// </summary>
        [ForeignKey("RaceId")]
        public RaceDto RaceDto { get; set; }


        /// <summary>
        /// The number of the checkpoint.
        /// Used to order the checkpoints in the correct order.
        /// </summary>
        [Index("IX_RaceCheckpointNumber", 2, IsUnique = true)]
        [Column("CheckpointNumber")]
        public int CheckpointNumber { get; set; }

        /// <summary>
        /// Size of the checkpoint
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Position of the checkpoint
        /// </summary>
        [NotMapped]
        public Vector3 Position
        {
            get => new Vector3(PosX, PosY, PosZ);
            set
            {
                PosX = value.X;
                PosY = value.Y;
                PosZ = value.Z;
            }
        }

        /// <summary>
        /// Rotation of the checkpoint
        /// </summary>
        [NotMapped]
        public Vector3 Rotation
        {
            get => new Vector3(RotX, RotY, RotZ);
            set
            {
                RotX = value.X;
                RotY = value.Y;
                RotZ = value.Z;
            }
        }

        [Column("PosX")]
        private double PosX { get; set; }

        [Column("PosY")]
        private double PosY { get; set; }

        [Column("PosZ")]
        private double PosZ { get; set; }

        [Column("RotX")]
        private double RotX { get; set; }

        [Column("RotY")]
        private double RotY { get; set; }

        [Column("RotZ")]
        private double RotZ { get; set; }

    }
}
