using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleRepository
    {
        private static VehicleRepository _vehicleRepository;
        private readonly API _api;

        private VehicleRepository(API api)
        {
            _api = api;
            new VehicleContext().FirstInit();
        }

        public static VehicleContext GetVehicleContext()
        {
            VehicleContext context = new VehicleContext();
            return context;
        }

        public static VehicleRepository GetInstance(API api)
        {
            return _vehicleRepository ?? (_vehicleRepository = new VehicleRepository(api));
        }
    }
}
