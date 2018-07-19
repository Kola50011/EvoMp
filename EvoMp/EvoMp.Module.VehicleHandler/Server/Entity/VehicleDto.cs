using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using EngineState = EvoMp.Module.VehicleHandler.Server.Enums.EngineState;
using SirenState = EvoMp.Module.VehicleHandler.Server.Enums.SirenState;
using SpecialLightState = EvoMp.Module.VehicleHandler.Server.Enums.SpecialLightState;
using VehicleState = EvoMp.Module.VehicleHandler.Server.Enums.VehicleState;

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

        [ForeignKey("VehicleHash")]
        public VehiclePropertiesDto VehicleProperties { get; set; }

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

        [Column("TyreSmokingColorId")]
        public int? TyreSmokingColorId { get; set; }

        [ForeignKey("TyreSmokingColorId")]
        public VehicleColorDto TyreSmokingColor { get; set; }

        [Column("PrimaryColorId")]
        public int? PrimaryColorId { get; set; }

        [ForeignKey("PrimaryColorId")]
        public VehicleColorDto PrimaryColor { get; set; }

        [Column("SecondaryColorId")]
        public int? SecondaryColorId { get; set; }

        [ForeignKey("SecondaryColorId")]
        public VehicleColorDto SecondaryColor { get; set; }

        [Column("LiveryId")]
        public int? LiveryId { get; set; }

        [ForeignKey("LiveryId")]
        public VehicleLiveryDto VehicleLivery { get; set; }

        [Column("NumberplateValue")]
        public string NumberplateValue { get; set; }

        [Column("VehicleState")]
        public VehicleState VehicleState { get; set; }

        [Column("KmStand")]
        public double KmStand { get; set; }

        [Column("Fuel")]
        public double Fuel { get; set; }

        [Column("Dirt")]
        public float Dirt { get; set; }

        [Column("Dimension")]
        public int Dimension { get; set; }

        [Column("Health")]
        public double Health { get; set; }

        [Column("EngineHealth")]
        public float EngineHealth { get; set; }

        [Column("Locked")]
        public bool Locked { get; set; }

        [Column("EngineState")]
        public EngineState EngineState { get; set; }

        [Column("SirenState")]
        public SirenState SirenState { get; set; }

        [Column("SpecialLightState")]
        public SpecialLightState SpecialLightState { get; set; }

        /// <summary>
        ///     The door states of the vehicle
        /// </summary>
        public ICollection<DoorStateDto> DoorStates { get; set; }

        /// <summary>
        ///     Vehicle Modifications
        /// </summary>
        public ICollection<VehicleModificationDto> Modifications { get; set; }
    }
}
