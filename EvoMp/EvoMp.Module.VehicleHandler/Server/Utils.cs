using System;
using System.Collections.Generic;
using System.Linq;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.VehicleHandler.Server
{
    public class Utils : IUtils
    {

        /// <inheritdoc />
        public List<VehicleHash> GetVehiclesByName(string searchVehicleName)
        {
            searchVehicleName = searchVehicleName.ToLower();
            return Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().AsParallel()
                .Where(vH => searchVehicleName == $"{vH}".ToLower()
                || $"{vH}".ToLower().StartsWith(searchVehicleName)
                || $"{vH}".ToLower().Contains(searchVehicleName))
                .Distinct()
                .ToList();
        }

        /// <inheritdoc />
        public List<VehicleHash> GetVehiclesByClass(VehicleClass vehicleClass)
        {
            return Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().AsParallel()
                .Where(vehicleHash => (VehicleClass) API.shared.getVehicleClass(vehicleHash) == vehicleClass).ToList();
        }

        /// <inheritdoc />
        public List<VehicleHash> GetVehiclesByIngameName(string searchIngameVehicleName)
        {
            searchIngameVehicleName = searchIngameVehicleName.ToLower();

            return Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().AsParallel()
                .Where(vh => searchIngameVehicleName == API.shared.getVehicleDisplayName(vh)
                || API.shared.getVehicleDisplayName(vh).ToLower().StartsWith(searchIngameVehicleName)
                || API.shared.getVehicleDisplayName(vh).ToLower().Contains(searchIngameVehicleName))
                .Distinct()
                .ToList();
        }
    }
}
