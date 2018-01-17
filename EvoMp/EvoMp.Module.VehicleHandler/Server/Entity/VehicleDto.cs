using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    [Table("Vehicles")]
    public class VehicleDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("VehicleId")]
        public int VehicleId { get; set; }

        [Required]
        [Column("VehicleHash")]
        public VehicleHash VehicleHash { get; set; }

        [NotMapped]
        public Vector3 Position
        {
            get => new Vector3(X, Y, Z);
            set
            {
                X = value.X;
                Y = value.Y;
                Z = value.Z;
            }
        }

        [NotMapped]
        public Vector3 Rotation
        {
            get => new Vector3(Xr, Yr, Zr);
            set
            {
                Xr = value.X;
                Yr = value.Y;
                Zr = value.Z;
            }
        }

        [Column("X")]
        private double X { get; set; }

        [Column("Y")]
        private double Y { get; set; }

        [Column("Z")]
        private double Z { get; set; }

        [Column("Xr")]
        private double Xr { get; set; }

        [Column("Yr")]
        private double Yr { get; set; }

        [Column("Zr")]
        private double Zr { get; set; }

        [Column("PrimaryColor")]
        public VehicleColorDto PrimaryColor  { get; set; }

        [Column("SecondaryColor")]
        public VehicleColorDto SecondaryColor  { get; set; }

        [Column("NumberplateValue")]
        public string NumberplateValue { get; set; }

        [Column("VehicleState")]
        public VehicleState VehicleState { get; set; }

        [Column("KmStand")]
        public double KmStand { get; set; }

        [Column("Fuel")]
        public double Fuel { get; set; }

        [Column("Dimension")]
        public int Dimension { get; set; }

        [Column("Health")]
        public double Health { get; set; }

        [Column("Locked")]
        public bool Locked { get; set; }

        [Column("EngineState")]
        public EngineState EngineState { get; set; }

        [Column("SirenState")]
        public SirenState SirenState { get; set; }

        [Column("SpecialLightState")]
        public SpecialLightState SpecialLightState { get; set; }
    }
}
