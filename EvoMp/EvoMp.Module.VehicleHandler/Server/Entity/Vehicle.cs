using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [Column("VehicleId")]
        public int VehicleId { get; set; }

        [Required]
        [Column("VehicleHash")]
        public VehicleHash VehicleHash;

        //public Vector3 Position;
        //public Vector3 Rotation;
        //public string PrimaryColorID;
        //public string SecondaryColorID;

        [Column("NumberplateValue")]
        public string NumberplateValue;

        [Column("VehicleState")]
        public VehicleState VehicleState;

        [Column("KmStand")]
        public double KmStand;

        [Column("Fuel")]
        public double Fuel;

        [Column("Dimension")]
        public int Dimension;

        [Column("Health")]
        public double Health;

        [Column("Locked")]
        public bool Locked;

        [Column("EngineState")]
        public EngineState EngineState;

        [Column("SirenState")]
        public SirenState SirenState;

        [Column("SpecialLightState")]
        public SpecialLightState SpecialLightState;
    }
}
