using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        public readonly VehicleDto Properties;
        private VehicleDto _vehicle;
        public NetHandle VehicleHandle;

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

        public ExtendedVehicle(int vehicleId)
        {
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                Properties = context.Vehicles.First(vdto => vdto.VehicleId == vehicleId);
            }
        }

        public ExtendedVehicle(NetHandle vehicle)
        {
            VehicleHandle = vehicle;

            if (!API.shared.hasEntityData(vehicle, "VehicleHash"))
            {
                ConsoleOutput.WriteLine(ConsoleType.Error, "Can't create extended Vehicle from anonymus Vehicle!");
                return;
            }

            // Get Database entry if given
            if (API.shared.hasEntityData(vehicle, "VehicleId"))
                using (VehicleContext context = VehicleRepository.GetVehicleContext())
                {
                    int vehicleId = (int) API.shared.getEntityData(vehicle, "VehicleId");
                    Properties = context.Vehicles.First(vdto => vdto.VehicleId == vehicleId);
                }
            else // Create new extendedVehcile
                Properties = new VehicleDto
                {
                    VehicleHash = (VehicleHash) API.shared.getEntityData(vehicle, "VehicleHash"),
                    Position = API.shared.getEntityPosition(vehicle),
                    Rotation = API.shared.getEntityRotation(vehicle),
                    Dimension = API.shared.getEntityDimension(vehicle)
                };

            FullUpdate(false); // Update current vehicle state
        }

        public void FullUpdate(bool saveAlso = false)
        {
            UpdateDoorStates();

            if (saveAlso)
                Save();
        }

        public void UpdateDoorStates()
        {
            if (Properties.DoorStates == null)
                Properties.DoorStates = new List<DoorStateDto>();

            foreach (DoorState doorState in Enum.GetValues(typeof(DoorState)))
            {
                // Create DoorState if not existing
                if (Properties.DoorStates.All(dstate => dstate.Door != doorState))
                    Properties.DoorStates.Add(new DoorStateDto {VehicleId = Properties.VehicleId, Door = doorState});

                // Change door state
                Properties.DoorStates.First(dstate => dstate.Door == doorState).State =
                    API.shared.getVehicleDoorState(VehicleHandle, (int) doorState);
            }
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

                        // Doorstates
                        if (Properties.DoorStates != null)
                            foreach (DoorStateDto doorState in Properties.DoorStates)
                            {
                                context.DoorStates.Attach(doorState);
                                context.DoorStates.AddOrUpdate(doorState);
                                context.SaveChanges();
                            }

                        contextTransaction.Commit();

                        // Save VehicleId to the Vehicle
                        if (!VehicleHandle.IsNull)
                            API.shared.setEntityData(VehicleHandle, "VehicleId", Properties.VehicleId);
                    }
                    catch (Exception e)
                    {
                        ConsoleOutput.WriteLine(ConsoleType.Database, "Error on Saving ExtendedVehicle!");
                        ConsoleOutput.WriteException($"{e}");
                        // Rollback changes on failure
                        contextTransaction.Rollback();
                    }
                }
            }
        }

        public void Create()
        {
            VehicleHandle = API.shared.createVehicle(Properties.VehicleHash,
                Properties.Position, Properties.Rotation, 1, 1,
                Properties.Dimension);
            API.shared.setEntityData(VehicleHandle, "VehicleHash", Properties.VehicleHash);

            // Set door states
            if (Properties.DoorStates != null)
                foreach (DoorStateDto doorState in Properties.DoorStates)
                    API.shared.setVehicleDoorState(VehicleHandle, (int) doorState.Door, doorState.State);
        }

        public void Destroy(bool saveBefore)
        {
            if (saveBefore)
                FullUpdate(true);

            API.shared.deleteEntity(VehicleHandle);
        }
    }
}
