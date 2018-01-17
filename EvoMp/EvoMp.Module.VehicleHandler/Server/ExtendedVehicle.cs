using System;
using EvoMp.Module.VehicleHandler.Server.Entity;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        public readonly VehicleDto Properties;
        private VehicleDto _vehicle;

        public ExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation)
        {
            Properties = new VehicleDto()
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
