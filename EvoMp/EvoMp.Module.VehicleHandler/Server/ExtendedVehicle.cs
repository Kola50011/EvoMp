using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        private VehicleDto _vehicle;
        public VehicleDto Properties;
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
        ///     Creates an Extendend Vehicle from an NetHandle
        ///     <remarks>The NetHandle must have the Entity Data VehicleHash!</remarks>
        /// </summary>
        /// <param name="vehicle"></param>
        public ExtendedVehicle(NetHandle vehicle)
        {
            VehicleHandle = vehicle;
            VehicleHash vehicleHash = (VehicleHash) API.shared.getEntityModel(vehicle);

            // Get Database entry if given
            if (API.shared.hasEntityData(vehicle, "VehicleId"))
                using (VehicleContext context = VehicleRepository.GetVehicleContext())
                {
                    InitFromDatabase((int) API.shared.getEntityData(vehicle, "VehicleId"));
                }
            else // Create new extendedVehcile
                InitNew(vehicleHash,
                    API.shared.getEntityPosition(vehicle), API.shared.getEntityRotation(vehicle),
                    API.shared.getEntityDimension(vehicle));
        }

        /// <summary>
        ///     Initalize the Extenden Vehicle from the database
        /// </summary>
        /// <param name="vehicleId">The vehicleId of the wanted Extended Vehicle</param>
        private void InitFromDatabase(int vehicleId)
        {
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                Properties = context.Vehicles
                    .Include(vDto => vDto.SecondaryColor)
                    .Include(vDto => vDto.PrimaryColor)
                    .Include(vDto => vDto.VehicleProperties)
                    .First(vdto => vdto.VehicleId == vehicleId);

                Properties.DoorStates =
                    context.DoorStates.Where(doorState => doorState.VehicleId == vehicleId).ToList();

                Properties.Modifications =
                    context.VehicleModifications.Where(vcDto => vcDto.VehicleId == vehicleId)
                        .Include(dto => dto.Modification).ToList();
            }

            Debug("Init - Loaded from database.");
        }

        /// <summary>
        ///     Initalize the extended Vehicle from a few informations
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

        public void FullUpdate(bool saveAlso = false)
        {
            UpdateDoorStates();
            UpdatePositionRotation();
            UpdateVehicleModifications();
            UpdateColor();

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

        public void UpdateVehicleModifications()
        {
            if (Properties.Modifications == null)
                Properties.Modifications = new List<VehicleModificationDto>();

            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                foreach (VehicleModification modification in Enum.GetValues(typeof(VehicleModification)))
                {
                    // Search for existing Modification
                    int value = API.shared.getVehicleMod(VehicleHandle, (int) modification);

                    ModificationDto modificationDto = context.Modifications
                        .FirstOrDefault(modDto => modDto.Slot == modification && modDto.Value == value);

                    // No existing modification found -> Create new
                    if (modificationDto == null)
                    {
                        modificationDto = context.Modifications.Add(new ModificationDto
                        {
                            Value = value,
                            Slot = modification
                        });
                        context.SaveChanges();
                    }

                    // Check for existing modification mapping or create new
                    if (Properties.Modifications.Any(vmdto =>
                        vmdto.Modification != null && vmdto.Modification.Slot == modification))
                        Properties.Modifications.First(vmdto =>
                                vmdto.Modification != null && vmdto.Modification.Slot == modification)
                            .Modification = modificationDto;
                    else
                        Properties.Modifications.Add(new VehicleModificationDto
                        {
                            VehicleId = Properties.VehicleId,
                            ModificationId = modificationDto.ModificationId
                        });
                }
            }

            Debug("Update - Vehicle Modifications updated.");
        }

        public void UpdatePositionRotation()
        {
            if (VehicleHandle.IsNull)
                return;

            Properties.Position = API.shared.getEntityPosition(VehicleHandle);
            Properties.Rotation = API.shared.getEntityRotation(VehicleHandle);

            Debug("Update - Position and rotation updated.");
        }

        public void UpdateColor()
        {
            if (VehicleHandle.IsNull)
                return;

            Color primaryColor = API.shared.getVehicleCustomPrimaryColor(VehicleHandle);
            Color secondaryColor = API.shared.getVehicleCustomSecondaryColor(VehicleHandle);
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                // Search for existing color combination
                VehicleColorDto primaryColorDto = context.VehicleColors.FirstOrDefault(vcDto =>
                    vcDto.Blue == primaryColor.blue && vcDto.Green == primaryColor.green &&
                    vcDto.Red == primaryColor.red);

                // Create color if not exist
                if (primaryColorDto == null)
                {
                    primaryColorDto = context.VehicleColors.Add(new VehicleColorDto
                    {
                        Green = primaryColor.green,
                        Blue = primaryColor.blue,
                        Red = primaryColor.red
                    });
                    context.SaveChanges();
                }

                VehicleColorDto secondaryColorDto = context.VehicleColors.FirstOrDefault(vcDto =>
                    vcDto.Blue == secondaryColor.blue && vcDto.Green == secondaryColor.green &&
                    vcDto.Red == secondaryColor.red);

                if (secondaryColorDto == null)
                {
                    secondaryColorDto = context.VehicleColors.Add(new VehicleColorDto
                    {
                        Green = secondaryColor.green,
                        Blue = secondaryColor.blue,
                        Red = secondaryColor.red
                    });
                    context.SaveChanges();
                }

                // Save color to vehicle
                Properties.PrimaryColor = primaryColorDto;
                Properties.SecondaryColor = secondaryColorDto;
                Properties.PrimaryColorId = primaryColorDto.VehicleColorId;
                Properties.SecondaryColorId = secondaryColorDto.VehicleColorId;
            }

            Debug("Update - Vehicle color updated.");
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
                        context.Vehicles.AddOrUpdate(Properties);

                        // Doorstates
                        if (Properties.DoorStates != null)
                            foreach (DoorStateDto doorState in Properties.DoorStates)
                                context.DoorStates.AddOrUpdate(doorState);

                        // Modifications
                        if (Properties.Modifications != null)
                            foreach (VehicleModificationDto modification in Properties.Modifications)
                                context.VehicleModifications.AddOrUpdate(modification);

                        context.SaveChanges();
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

        /// <summary>
        ///     Spawns the extended Vehicle on the server.
        /// </summary>
        public void Create()
        {
            Vehicle newVehicle = API.shared.createVehicle(Properties.VehicleHash,
                Properties.Position, Properties.Rotation, 1, 1,
                Properties.Dimension);

            newVehicle.waitForSynchronization();

            // Set Global VehicleHandle
            VehicleHandle = newVehicle;
            API.shared.setEntityData(VehicleHandle, "VehicleId", Properties.VehicleId);

            // Set door states
            if (Properties.DoorStates != null)
                foreach (DoorStateDto doorState in Properties.DoorStates)
                    API.shared.setVehicleDoorState(VehicleHandle, (int) doorState.Door, doorState.State);

            // Set vehicle modifications
            if (Properties.Modifications != null)
                foreach (VehicleModificationDto modification in Properties.Modifications)
                    API.shared.setVehicleMod(VehicleHandle, (int) modification.Modification.Slot,
                        modification.Modification.Value);

            // Set vehicle color
            if (Properties.PrimaryColor != null)
                API.shared.setVehicleCustomPrimaryColor(VehicleHandle, Properties.PrimaryColor.Red,
                    Properties.PrimaryColor.Green, Properties.PrimaryColor.Blue);
            if (Properties.SecondaryColor != null)
                API.shared.setVehicleCustomSecondaryColor(VehicleHandle, Properties.SecondaryColor.Red,
                    Properties.SecondaryColor.Green, Properties.SecondaryColor.Blue);

            Debug("Create - Extended Vehicle created.");
        }

        /// <summary>
        ///     Destroys the extended Vehicle on the server
        /// </summary>
        /// <param name="saveBefore">Should the vehicle saved before?</param>
        public void Destroy(bool saveBefore)
        {
            if (saveBefore)
                FullUpdate(true);

            API.shared.deleteEntity(VehicleHandle);
            Debug("Destroy - Extended Vehicle destroyed.");
        }

        /// <summary>
        ///     Debug function for the VehicleHandler
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
