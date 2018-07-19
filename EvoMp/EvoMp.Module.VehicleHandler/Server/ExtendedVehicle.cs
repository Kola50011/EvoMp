using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleHandler.Server.Exceptions;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;
using GrandTheftMultiplayer.Shared.Math;
using DoorState = EvoMp.Module.VehicleHandler.Server.Enums.DoorState;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class ExtendedVehicle
    {
        private VehicleDto _vehicle;
        public VehicleDto Properties;
        public NetHandle Vehicle;

        /// <summary>
        ///     Creates a new ExtendedVehicle by vehicleHash, position, rotation, dimension
        /// </summary>
        /// <param name="vehicleHash">The VehicleHash of the new ExtendedVehicle</param>
        /// <param name="position">The position of the new ExtendedVehicle</param>
        /// <param name="rotation">The rotation of the new ExtendedVehicle</param>
        /// <param name="dimension">The dimension of the new ExtendedVehicle</param>
        internal ExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation, int dimension)
        {
            InitNew(vehicleHash, position, rotation, dimension);
        }

        /// <summary>
        ///     Creates an existing ExtendedVehicle by Vehicles table VehicleId
        /// </summary>
        /// <param name="vehicleId">The vehicleId of the wanted extendedVehicle</param>
        internal ExtendedVehicle(int vehicleId)
        {
            InitFromDatabase(vehicleId);
        }

        /// <summary>
        ///     Creates an Extendend Vehicle from an NetHandle.
        ///     Creates the saved ExtendedVehicle if the NetHandle has the "VehicleId" entity data.
        ///     If this is not the case, it creates a new ExtendedVehicle
        /// </summary>
        /// <param name="vehicle">The vehicle from wich the extendedVehicle should created.</param>
        internal ExtendedVehicle(NetHandle vehicle)
        {
            Vehicle = vehicle;

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
        ///     Creates a copy of the current ExtendedVehicle.
        /// </summary>
        /// <exception cref="ExtendedVehicleException">Throws if the ExtendedVehicle has no valid/existing NetHandle.</exception>
        /// <returns>New ExtendedVehicle object</returns>
        public ExtendedVehicle Copy()
        {
            if (Vehicle.IsNull)
                throw new ExtendedVehicleException("Can't call .Copy() an ExtendedVehicle without NetHandle!");

            ExtendedVehicle copyVehicle = new ExtendedVehicle(Properties.VehicleHash,
                API.shared.getEntityPosition(Vehicle), API.shared.getEntityRotation(Vehicle),
                API.shared.getEntityDimension(Vehicle));
            copyVehicle.Save();
            copyVehicle.Vehicle = Vehicle;
            copyVehicle.FullUpdate(false);
            copyVehicle.Vehicle = new NetHandle();
            copyVehicle.Save();
            return copyVehicle;
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
                    .Include(vdto => vdto.TyreSmokingColor)
                    .Include(vdto => vdto.VehicleLivery)
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
            //Get Vehicle properties
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                Properties = context.Vehicles.Add(new VehicleDto
                {
                    VehicleHash = vehicleHash,
                    VehicleProperties = context.VehicleProperties.First(dto => dto.VehicleHash == vehicleHash),
                    Position = position,
                    Rotation = rotation,
                    Dimension = dimension
                });
                context.SaveChanges();

                // Save VehicleId to the Vehicle
                if (!Vehicle.IsNull)
                    API.shared.setEntityData(Vehicle, "VehicleId", Properties.VehicleId);
            }

            Debug("Init - By vehicleHash, position, rotation, dimension.");
        }

        /// <summary>
        ///     Updates the Properties object by the NetHandle.
        /// </summary>
        /// <param name="saveAlso">Save the updated changes also?</param>
        public void FullUpdate(bool saveAlso = false)
        {
            UpdateDoorStates();
            UpdatePositionRotation();
            UpdateVehicleModifications();
            UpdateColor();
            UpdateLiveries();
            UpdateDirtLevel();

            Debug("Update - Full Update done.");
            if (saveAlso)
                Save();
        }

        /// <summary>
        /// Updates level of dirt from vehicle
        /// </summary>
        public void UpdateDirtLevel()
        {
            if (Vehicle.IsNull)
                return;
            Properties.Dirt = API.shared.getVehicleDirtLevel(Vehicle);

            Debug("Update - Level of dirt");
        }

        /// <summary>
        ///     Updates the Properties.DoorStates by the NetHandle
        /// </summary>
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
                    API.shared.getVehicleDoorState(Vehicle, (int) doorState);
            }

            Debug("Update - Door States updated.");
        }

        /// <summary>
        ///     Updates the Properties.VehicleLivery by the NetHandle.
        ///     Adds also new VehicleLivery combinations to the VehicleLiverys table.
        /// </summary>
        public void UpdateLiveries()
        {
            if (Vehicle.IsNull)
                return;

            int liveryValue = API.shared.getVehicleLivery(Vehicle);

            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                // check if a livery with this combination already exist
                VehicleLiveryDto livery = context.VehicleLiveries.FirstOrDefault(vlDto =>
                    vlDto.VehicleLiveryId == liveryValue &&
                    vlDto.VehicleHash == Properties.VehicleHash);

                if (livery == null)
                {
                    livery = context.VehicleLiveries.Add(new VehicleLiveryDto
                    {
                        Value = liveryValue,
                        VehicleHash = Properties.VehicleHash
                    });
                    context.SaveChanges();
                }

                Properties.LiveryId = livery.VehicleLiveryId;
                Properties.VehicleLivery = livery;
            }

            Debug("Update - Liveries.");
        }

        /// <summary>
        ///     Updates the Properties.Modifications by the NetHandle.
        ///     Adds also new modification combinations to the VehicleModifications table.
        /// </summary>
        public void UpdateVehicleModifications()
        {
            if (Properties.Modifications == null)
                Properties.Modifications = new List<VehicleModificationDto>();

            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                foreach (VehicleModType modification in Enum.GetValues(typeof(VehicleModType)))
                {
                    // Search for existing Modification
                    int value = API.shared.getVehicleMod(Vehicle, (int) modification);

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

        /// <summary>
        ///     Updates the Properties.Position and the Properties.Rotation by the NetHandle.
        /// </summary>
        public void UpdatePositionRotation()
        {
            if (Vehicle.IsNull)
                return;

            Properties.Position = API.shared.getEntityPosition(Vehicle);
            Properties.Rotation = API.shared.getEntityRotation(Vehicle);

            Debug("Update - Position and rotation updated.");
        }

        /// <summary>
        ///     Updates the Properties.primaryColor, Properties.secondaryColor and the tyreColor by the NetHandle.
        ///     Adds also new color combinations to the VehicleColors table.
        /// </summary>
        public void UpdateColor()
        {
            if (Vehicle.IsNull)
                return;

            Color primaryColor = API.shared.getVehicleCustomPrimaryColor(Vehicle);
            Color secondaryColor = API.shared.getVehicleCustomSecondaryColor(Vehicle);
            Color tyreColor = API.shared.getVehicleTyreSmokeColor(Vehicle);
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

                VehicleColorDto tyreColorDto = context.VehicleColors.FirstOrDefault(vcDto =>
                    vcDto.Blue == tyreColor.blue && vcDto.Green == tyreColor.green &&
                    vcDto.Red == tyreColor.red);

                if (tyreColorDto == null)
                {
                    tyreColorDto = context.VehicleColors.Add(new VehicleColorDto
                    {
                        Green = tyreColor.green,
                        Blue = tyreColor.blue,
                        Red = tyreColor.red
                    });
                    context.SaveChanges();
                }

                // Save color to vehicle
                Properties.PrimaryColor = primaryColorDto;
                Properties.SecondaryColor = secondaryColorDto;
                Properties.TyreSmokingColor = tyreColorDto;
                Properties.PrimaryColorId = primaryColorDto.VehicleColorId;
                Properties.SecondaryColorId = secondaryColorDto.VehicleColorId;
                Properties.TyreSmokingColorId = tyreColorDto.VehicleColorId;
            }

            Debug("Update - Vehicle color updated.");
        }

        /// <summary>
        ///     Saves the current Properties to the database.
        /// </summary>
        public void Save()
        {
            _vehicle = Properties;

            // Start new transaction for possibillity rollback
            using (DbContextTransaction contextTransaction =
                VehicleRepository.GetVehicleContext().Database.BeginTransaction())
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
                        if (!Vehicle.IsNull)
                            API.shared.setEntityData(Vehicle, "VehicleId", Properties.VehicleId);
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
        ///     Spawns the extended Vehicle as NetHandle on the server.
        /// </summary>
        /// <param name="allowMultiple">Allow multiple NetHandles with the same ExtendedVehicle?</param>
        /// <exception cref="ExtendedVehicleException">
        ///     Throws exception, if there is already an NetHandle with the same
        ///     ExtendedVehicle. (Ignored by allowMultiple)
        /// </exception>
        public void Create(bool allowMultiple = false)
        {
            // Only one NetHandle for this ExtendedVehicle -> throw exception
            if (!allowMultiple && API.shared.getAllVehicles().Any(handle =>
                    API.shared.hasEntityData(handle, "VehicleId") &&
                    (int) API.shared.getEntityData(handle, "VehicleId") == Properties.VehicleId))
                throw new ExtendedVehicleException("Only one existing NetHandle allowed for this ExtendedVehicle.");

            // Create NetHandle & wait for player sync
            Vehicle newVehicle = API.shared.createVehicle(Properties.VehicleHash,
                Properties.Position, Properties.Rotation, 1, 1,
                Properties.Dimension);

            newVehicle.waitForSynchronization();

            // Set Global VehicleHandle
            Vehicle = newVehicle;
            API.shared.setEntityData(Vehicle, "VehicleId", Properties.VehicleId);

            // Set door states
            if (Properties.DoorStates != null)
                foreach (DoorStateDto doorState in Properties.DoorStates)
                    API.shared.setVehicleDoorState(Vehicle, (int) doorState.Door, doorState.State);

            // Set vehicle modifications
            if (Properties.Modifications != null)
                foreach (VehicleModificationDto modification in Properties.Modifications)
                    API.shared.setVehicleMod(Vehicle, (int) modification.Modification.Slot,
                        modification.Modification.Value);

            // Set vehicle color
            if (Properties.PrimaryColor != null)
                API.shared.setVehicleCustomPrimaryColor(Vehicle, Properties.PrimaryColor.Red,
                    Properties.PrimaryColor.Green, Properties.PrimaryColor.Blue);
            if (Properties.SecondaryColor != null)
                API.shared.setVehicleCustomSecondaryColor(Vehicle, Properties.SecondaryColor.Red,
                    Properties.SecondaryColor.Green, Properties.SecondaryColor.Blue);
            if (Properties.TyreSmokingColor != null)
                API.shared.setVehicleTyreSmokeColor(Vehicle, Properties.TyreSmokingColor.Red,
                    Properties.TyreSmokingColor.Green, Properties.TyreSmokingColor.Blue);

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

            API.shared.deleteEntity(Vehicle);
            Debug("Destroy - Extended Vehicle destroyed.");
        }

        /// <summary>
        ///     Debug function for the VehicleHandler
        /// </summary>
        /// <param name="message">The debug message</param>
        private void Debug(string message)
        {
            message = $"(ExtendedVehicle) [ID: {Properties.VehicleId}] {message}";
            ConsoleOutput.WriteLine(ConsoleType.Debug, message);
            VehicleHandler.MessageHandler.BroadcastMessage(message, MessageType.Debug);
        }
    }
}
