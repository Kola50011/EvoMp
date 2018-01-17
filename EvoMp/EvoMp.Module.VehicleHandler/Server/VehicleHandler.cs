using EvoMp.Module.CommandHandler;
using EvoMp.Module.VehicleHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class VehicleHandler : IVehicleHandler
    {
        private readonly API _api;

        private readonly VehicleRepository _vehicleRepository;

        public VehicleHandler(API api, ICommandHandler commandHandler)
        {
            _api = api;
            _vehicleRepository = VehicleRepository.GetInstance(api);

        }
    }
}
