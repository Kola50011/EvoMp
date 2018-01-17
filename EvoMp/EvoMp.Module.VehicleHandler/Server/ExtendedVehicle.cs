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
        public readonly VehicleMap Properties;
        private VehicleMap _vehicle;

        public ExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation)
        {
            Properties = new VehicleMap()
            {
                VehicleHash = vehicleHash
            };
        }

        public void Save()
        {
            _vehicle = Properties;

            // Start new transaction for possibillity rollback
            using (var contextTransaction = VehicleRepository.GetVehicleContext().Database.BeginTransaction())
            {
                // Get wanted repository context
                using (VehicleContext context = VehicleRepository.GetVehicleContext())
                {
                    // Try to update values & commit values to transaction
                    try
                    {
                        context.Vehicles.Attach(_vehicle);
                        context.SaveChanges();
                        contextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Rollback changes on failure
                        contextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
