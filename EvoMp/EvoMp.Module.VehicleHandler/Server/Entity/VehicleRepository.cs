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

        public static VehicleContext GetVehicleContext()
        {
            VehicleContext context = new VehicleContext();
            return context;
        }

        public static VehicleRepository GetInstance(API api)
        {
            return _vehicleRepository ?? (_vehicleRepository = new VehicleRepository());
        }
    }
}
