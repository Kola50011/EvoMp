using System;
using System.Data.Entity.Migrations;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        public readonly VehicleDto Properties;
        private VehicleDto _vehicle;

        public ExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation, int dimension)
        {
            Properties = new VehicleDto
            {
                VehicleHash = vehicleHash,
                Position = position,
                Rotation = rotation,
                Dimension = dimension
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
                        context.Vehicles.AddOrUpdate(Properties);
                        context.SaveChanges();
                        contextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        ConsoleOutput.WriteLine(ConsoleType.Database, "Error on Saving ExtendedVehicle!");
                        ConsoleOutput.WriteException(e.Message + e.StackTrace);

                        // Rollback changes on failure
                        contextTransaction.Rollback();
                    }
                }
            }
        }

        public NetHandle Create()
        {
            return API.shared.createVehicle(Properties.VehicleHash, Properties.Position, Properties.Rotation, 1, 1,
                Properties.Dimension);
        }
    }
}
