using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EvoMp.Core.Module.Server.Entity;
using EvoMp.Module.VehicleHandler.Server.Enum;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleDto : BaseEntityDto
    {
        public VehicleHash VehicleHash { get; set; }

        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }

        //public string PrimaryColorID  { get; set; }
        //public string SecondaryColorID  { get; set; }

        public string NumberplateValue { get; set; }

        public VehicleState VehicleState { get; set; }

        public double KmStand { get; set; }

        public double Fuel { get; set; }

        public int Dimension { get; set; }

        public double Health { get; set; }

        public bool Locked { get; set; }

        public EngineState EngineState { get; set; }

        public SirenState SirenState { get; set; }

        public SpecialLightState SpecialLightState { get; set; }
    }
}
