using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using Object = GrandTheftMultiplayer.Server.Elements.Object;

namespace EvoMp.Module.MapHandler.Server.Entity
{
    [Table("MapObjects")]
    public class MapObjectDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("MapObjectId")]
        public int MapId { get; set; }

        [Required]
        [Column("Hash")]
        public int Hash { get; set; }

        [Column("HashName")]
        public string HashName { get; set; }

        [ForeignKey("MapId")]
        public MapDto Map { get; set; }

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

        [Column("OpacityLevel")]
        public byte OpacityLevel { get; set; }

        [Column("Visible")]
        public bool Visible { get; set; }

        [Column("Dynamic")]
        public bool Dynamic { get; set; }

        [Column("Collisionless")]
        public bool Collisionless { get; set; }

        [NotMapped]
        public Object Object{ get; set; }

    }
}
