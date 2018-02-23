using System;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleRepository
    {
        private static VehicleRepository _vehicleRepository;

        private VehicleRepository()
        {
            new VehicleContext().FirstInit();
        }

        private VehicleContext CreateContext()
        {
            VehicleContext context = new VehicleContext();
            return context;
        }

        public static VehicleContext GetVehicleContext()
        {
            return GetInstance().CreateContext();
        }

        public static VehicleRepository GetInstance()
        {
            return _vehicleRepository ?? (_vehicleRepository = new VehicleRepository());
        }
    }
}
