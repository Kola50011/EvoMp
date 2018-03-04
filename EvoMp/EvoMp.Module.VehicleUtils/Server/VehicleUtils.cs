using System;
using System.Collections.Generic;
using System.Linq;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.VehicleUtils.Server
{
    public class VehicleUtils : BaseModule, IVehicleUtils
    {

        /// <inheritdoc />
        /// <summary>
        /// Returns possible vehicleHashes for the given vehicle hash name
        /// </summary>
        /// <param name="searchVehicleName">The search vehicle hash name pattern</param>
        /// <returns>List with possible VehicleHashes</returns>
        List<VehicleHash> IVehicleUtils.GetVehiclesByName(string searchVehicleName)
        {
            List<VehicleHash> vehicleHashes = new List<VehicleHash>();
            searchVehicleName = searchVehicleName.ToLower();

            // Name like
            vehicleHashes.AddRange(Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>()
                .Where(vehicleHash =>
                    searchVehicleName == $"{vehicleHash}".ToLower() && !vehicleHashes.Contains(vehicleHash)));

            //Name starts with
            vehicleHashes.AddRange(Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().Where(vehicleHash =>
                $"{vehicleHash}".ToLower().StartsWith(searchVehicleName) && !vehicleHashes.Contains(vehicleHash)));

            //Name contains
            vehicleHashes.AddRange(Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().Where(vehicleHash =>
                $"{vehicleHash}".ToLower().Contains(searchVehicleName) && !vehicleHashes.Contains(vehicleHash)));

            return vehicleHashes;
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns vehicleHashes for the given vehicle class
        /// </summary>
        /// <param name="vehicleClass">The searched vehicleClass</param>
        /// <returns>List with class matching VehicleHashes</returns>
        List<VehicleHash> IVehicleUtils.GetVehiclesByClass(VehicleClass vehicleClass)
        {
            return Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>()
                .Where(vehicleHash => (VehicleClass)API.shared.getVehicleClass(vehicleHash) == vehicleClass).ToList();
        }

        /// <inheritdoc />
        /// <summary>
        /// Returns possible vehicleHashes for the given ingame vehicle name
        /// </summary>
        /// <param name="searchIngameVehicleName">The search ingame vehicle name pattern</param>
        /// <returns>List with possible VehicleHashes</returns>
        List<VehicleHash> IVehicleUtils.GetVehiclesByIngameName(string searchIngameVehicleName)
        {
            searchIngameVehicleName = searchIngameVehicleName.ToLower();
            List<VehicleHash> vehicleHashes = new List<VehicleHash>();

            // Name like
            vehicleHashes.AddRange(Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>()
                .Where(vehicleHash =>
                    searchIngameVehicleName == API.shared.getVehicleDisplayName(vehicleHash).ToLower() &&
                    !vehicleHashes.Contains(vehicleHash)));

            //Name starts with
            vehicleHashes.AddRange(Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().Where(vehicleHash =>
                API.shared.getVehicleDisplayName(vehicleHash).ToLower().StartsWith(searchIngameVehicleName) &&
                !vehicleHashes.Contains(vehicleHash)));

            //Name contains
            vehicleHashes.AddRange(Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>().Where(vehicleHash =>
                API.shared.getVehicleDisplayName(vehicleHash).ToLower().Contains(searchIngameVehicleName) &&
                !vehicleHashes.Contains(vehicleHash)));

            return vehicleHashes;
        }
    }
}
