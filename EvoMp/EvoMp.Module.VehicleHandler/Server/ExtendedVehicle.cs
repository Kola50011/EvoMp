using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        public VehicleDto Properties;
        private VehicleDto _vehicle;
        public NetHandle VehicleHandle;

        public ExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation, int dimension)
        {
            InitNew(vehicleHash, position, rotation, dimension);
        }

        public ExtendedVehicle(int vehicleId)
        {
            InitFromDatabase(vehicleId);
        }

        /// <summary>
        /// Initalize the Extenden Vehicle from the database
        /// </summary>
        /// <param name="vehicleId">The vehicleId of the wanted Extended Vehicle</param>
        private void InitFromDatabase(int vehicleId)
        {
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                Properties = context.Vehicles.First(vdto => vdto.VehicleId == vehicleId);
                Properties.DoorStates =
                    context.DoorStates.Where(doorState => doorState.VehicleId == vehicleId).ToList();
            }

            Debug("Init - Loaded from database.");
        }

        /// <summary>
        /// Initalize the extended Vehicle from a few informations
        /// </summary>
        /// <param name="vehicleHash">The VehicleHash</param>
        /// <param name="position">The Vehicle position</param>
        /// <param name="rotation">The Vehicle rotation</param>
        /// <param name="dimension">The vehicle dimension</param>
        private void InitNew(VehicleHash vehicleHash, Vector3 position, Vector3 rotation, int dimension)
        {
            Properties = new VehicleDto
            {
                VehicleHash = vehicleHash,
                Position = position,
                Rotation = rotation,
                Dimension = dimension
            };
            Debug("Init - By vehicleHash, position, rotation, dimension.");
        }

        /// <summary>
        /// Creates an Extendend Vehicle from an NetHandle
        /// <remarks>The NetHandle must have the Entity Data VehicleHash!</remarks>
        /// </summary>
        /// <param name="vehicle"></param>
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
                    InitFromDatabase((int) API.shared.getEntityData(vehicle, "VehicleId"));
            else // Create new extendedVehcile
                InitNew((VehicleHash) API.shared.getEntityData(vehicle, "VehicleHash"),
                    API.shared.getEntityPosition(vehicle), API.shared.getEntityRotation(vehicle),
                    API.shared.getEntityDimension(vehicle));
        }

        public void FullUpdate(bool saveAlso = false)
        {
            UpdateDoorStates();
            UpdatePositionRotation();

            Debug("Update - Full Update done.");
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

            Debug("Update - Door States updated.");
        }

        public void UpdatePositionRotation()
        {
            if (VehicleHandle.IsNull)
                return;

            Properties.Position = API.shared.getEntityPosition(VehicleHandle);
            Properties.Rotation = API.shared.getEntityRotation(VehicleHandle);

            Debug("Update - Position and rotation updated.");

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
                        //context.Vehicles.Attach(_vehicle);
                        context.Vehicles.AddOrUpdate(Properties);
                        context.SaveChanges();

                        // Doorstates
                        if (Properties.DoorStates != null)
                            foreach (DoorStateDto doorState in Properties.DoorStates)
                            {
                                // context.DoorStates.Attach(doorState);
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
                Debug("Save - Extended Vehicle saved to database.");
            }

        }

        public void Create()
        {
            VehicleHandle = API.shared.createVehicle(Properties.VehicleHash,
                Properties.Position, Properties.Rotation, 1, 1,
                Properties.Dimension);

            API.shared.setEntityData(VehicleHandle, "VehicleHash", Properties.VehicleHash);
            API.shared.setEntityData(VehicleHandle, "VehicleId", Properties.VehicleId);

            // Set door states
            if (Properties.DoorStates != null)
                foreach (DoorStateDto doorState in Properties.DoorStates)
                    API.shared.setVehicleDoorState(VehicleHandle, (int) doorState.Door, doorState.State);

            Debug("Create - Extended Vehicle created.");
        }

        public void Destroy(bool saveBefore)
        {
            if (saveBefore)
                FullUpdate(true);

            API.shared.deleteEntity(VehicleHandle);
            Debug("Destroy - Extended Vehicle destroyed.");
        }

        /// <summary>
        /// Debug function for the VehicleHandler
        /// </summary>
        /// <param name="message"></param>
        private void Debug(string message)
        {
            message = $"[ID: {Properties.VehicleId}] {message}";
            ConsoleOutput.WriteLine(ConsoleType.Debug, message);
            MessageHandler.Server.MessageHandler.BroadcastMessage(message, MessageType.Debug);
        }
    }
}
