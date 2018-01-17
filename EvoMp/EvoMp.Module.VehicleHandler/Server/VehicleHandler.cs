using System;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.VehicleHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

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
