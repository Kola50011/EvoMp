using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Module.VehicleHandler.Server.Entity;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        public readonly Vehicle Properties;
        private Vehicle _vehicle;

        public ExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation)
        {
            Properties = new Vehicle()
            {
                VehicleHash = vehicleHash
            };
        }

        public void Save()
        {
            //_vehicle = Properties;
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                //context.Vehicles.Attach(_vehicle);
                context.SaveChanges();
            }
        }
    }
}
