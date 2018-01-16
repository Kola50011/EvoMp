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
        public VehicleHash VehicleHash { get; set; }

        //public Vector3 Position  { get; set; }
        //public Vector3 Rotation  { get; set; }
        //public string PrimaryColorID  { get; set; }
        //public string SecondaryColorID  { get; set; }

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
