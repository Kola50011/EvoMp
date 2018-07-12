using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.BotHandler.Server.Entity
{
    [Table("BotWaypoints")]
    public class BotWaypointDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index("IX_BotIdWaypointId", 1, IsUnique = true)]
        [Key]
        [Required]
        [Column("BotWaypointId")]
        public int BotWaypointId { get; set; }

        [Index("IX_BotIdWaypointId", 2, IsUnique = true)]
        [Column("BotId")]
        public int BotId { get; set; }

        [ForeignKey("BotId")]
        public BotDto Bot { get; set; }


        /// <summary>
        ///     Position of the waypoint
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
        ///     Rotation of the waypoint
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

        /// <summary>
        ///     Velocity of the waypoint
        /// </summary>
        [NotMapped]
        public Vector3 Velocity
        {
            get => new Vector3(VelX, VelY, VelZ);
            set
            {
                VelX = value.X;
                VelY = value.Y;
                VelZ = value.Z;
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

        [Column("VelX")]
        private double VelX { get; set; }

        [Column("VelY")]
        private double VelY { get; set; }

        [Column("VelZ")]
        private double VelZ { get; set; }
    }
}
