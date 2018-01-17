using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Core.Module.Server.Entity;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleMap : BaseEntityMap
    {
        [Required]
        [Column("VehicleHash")]
        public VehicleHash VehicleHash { get; set; }

        // Position
        [Required]
        [Column("PositionX")]
        public double X { get; set; }

        [Required]
        [Column("PositionY")]
        public double Y { get; set; }

        [Required]
        [Column("PositionZ")]
        public double Z { get; set; }

        // Rotation
        [Required]
        [Column("RotationX")]
        public double Xr { get; set; }

        [Required]
        [Column("RotationY")]
        public double Yr { get; set; }

        [Required]
        [Column("RotationZ")]
        public double Zr { get; set; }

        // Other properties
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
