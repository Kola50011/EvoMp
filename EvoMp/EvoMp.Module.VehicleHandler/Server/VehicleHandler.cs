using System;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    /// <summary>
    ///     THe VehicleHandler main class.
    /// </summary>
    public class VehicleHandler : BaseModule, IVehicleHandler
    {
        /// <summary>
        ///     Initalizes and sets up the VehicleHandler.
        ///     Checks also for new VehicleHashes to fill the VehicleProperties table.
        /// </summary>
        /// <param name="vehicleUtils">An IVehicleUtils module</param>
        public VehicleHandler(IVehicleUtils vehicleUtils)
        {
            CheckVehicleProperties();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates a new ExtendedVehicle by vehicleHash, position, rotation, dimension
        /// </summary>
        /// <param name="vehicleHash">The VehicleHash of the new ExtendedVehicle</param>
        /// <param name="position">The position of the new ExtendedVehicle</param>
        /// <param name="rotation">The rotation of the new ExtendedVehicle</param>
        /// <param name="dimension">The dimension of the new ExtendedVehicle</param>
        /// <returns>ExtendedVehicle</returns>
        public ExtendedVehicle CreateExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation,
            int dimension)
        {
            return new ExtendedVehicle(vehicleHash, position, rotation, dimension);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates an existing ExtendedVehicle by Vehicles table VehicleId
        /// </summary>
        /// <param name="vehicleId">The vehicleId of the wanted extendedVehicle</param>
        /// <returns>ExtendedVehicle</returns>
        public ExtendedVehicle CreateExtendedVehicle(int vehicleId)
        {
            return new ExtendedVehicle(vehicleId);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates an Extendend Vehicle from an NetHandle.
        ///     Creates the saved ExtendedVehicle if the NetHandle has the "VehicleId" entity data.
        ///     If this is not the case, it creates a new ExtendedVehicle
        /// </summary>
        /// <param name="vehicle">The vehicle from wich the extendedVehicle should created.</param>
        /// <returns>ExtendedVehicle</returns>
        public ExtendedVehicle CreateExtendedVehicle(NetHandle vehicle)
        {
            return new ExtendedVehicle(vehicle);
        }

        /// <summary>
        ///     Checks if new VehicleHashes exists
        /// </summary>
        private static void CheckVehicleProperties()
        {
            using (VehicleContext context = VehicleRepository.GetVehicleContext())
            {
                bool noticeWritten = false;

                string addedVehicleHashes = "";
                foreach (VehicleHash vehicleHash in Enum.GetValues(typeof(VehicleHash)))
                {
                    if (context.VehicleProperties.Any(dto => dto.VehicleHash == vehicleHash))
                        continue;

                    // Write notice for long waiting time.
                    if (!noticeWritten)
                    {
                        ConsoleOutput.WriteLine(ConsoleType.Database,
                            $"Setting default vehicle properties. This may take a moment.");
                        noticeWritten = true;
                    }

                    context.VehicleProperties.Add(new VehiclePropertiesDto
                    {
                        VehicleHash = vehicleHash,
                        BuildYear = 1996,
                        Consumption = 5,
                        DisplayName = API.shared.getVehicleDisplayName(vehicleHash),
                        DoorCount = 5,
                        FuelType = FuelType.Gasoline,
                        MaxSpeed = 999,
                        TankSize = 10,
                        TrunkSize = 12
                    });
                    addedVehicleHashes += $" {vehicleHash}";
                }

                // No vehicleHashes updated -> return;
                if (string.IsNullOrEmpty(addedVehicleHashes))
                    return;

                context.SaveChanges();
                ConsoleOutput.WriteLine(ConsoleType.Database,
                    $"Set default vehicle properties for ~o~{addedVehicleHashes}");
            }
        }
    }
}
