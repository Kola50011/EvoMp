using System;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.VehicleHandler.Server.Entity;
using EvoMp.Module.VehicleUtils.Server;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class VehicleHandler : IVehicleHandler
    {
        private readonly API _api;

        private readonly VehicleRepository _vehicleRepository;

        public VehicleHandler(API api, IVehicleUtils vehicleUtils)
        {
            _api = api;
            _vehicleRepository = VehicleRepository.GetInstance(api);
            CheckVehicleProperties();
        }

        /// <summary>
        ///     Checks if new VehicleHashes given
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
                        ConsoleOutput.WriteLine(ConsoleType.Database, $"Setting default vehicle properties. This may take a moment.");
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
