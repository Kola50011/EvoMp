using System;
using System.Net.Mail;
using System.Runtime.InteropServices;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class VehicleRepository
    {
        private readonly API _api;

        public VehicleRepository(API api)
        {
            _api = api;
            new VehicleContext().FirstInit();
        }

        public VehicleContext GetUserContext()
        {
            VehicleContext context = new VehicleContext();
            context.Init();
            return context;
        }
    }
}
