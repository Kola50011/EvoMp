using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleUtils.Server.Enums;
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

        [Column("PrimaryColor")]
        public VehicleColorDto PrimaryColor { get; set; }

        [Column("SecondaryColor")]
        public VehicleColorDto SecondaryColor { get; set; }

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
