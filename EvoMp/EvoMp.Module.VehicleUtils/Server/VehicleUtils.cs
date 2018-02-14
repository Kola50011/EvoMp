using System;
using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.VehicleUtils.Server
{
    public class VehicleUtils : IVehicleUtils
    {
        List<VehicleHash> IVehicleUtils.GetVehiclesByName(string searchVehicleName)
        {
            return GetVehiclesByName(searchVehicleName);
        }

        List<VehicleHash> IVehicleUtils.GetVehiclesByCategory(VehicleCategory category)
        {
            return GetVehiclesByCategory(category);
        }

        List<VehicleHash> IVehicleUtils.GetVehiclesByIngameName(string searchIngameVehicleName)
        {
            return GetVehiclesByIngameName(searchIngameVehicleName);
        }

        VehicleCategory IVehicleUtils.GetVehicleCategory(VehicleHash vehicleHash)
        {
            return GetVehicleCategory(vehicleHash);
        }

        public static List<VehicleHash> GetVehiclesByName(string searchVehicleName)
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

        public static List<VehicleHash> GetVehiclesByCategory(VehicleCategory category)
        {
            return Enum.GetValues(typeof(VehicleHash)).Cast<VehicleHash>()
                .Where(vehicleHash => GetVehicleCategory(vehicleHash) == category).ToList();
        }

        public static List<VehicleHash> GetVehiclesByIngameName(string searchIngameVehicleName)
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

        public static VehicleCategory GetVehicleCategory(VehicleHash vehicleHash)
        {
            return (VehicleCategory) API.shared.getVehicleClass(vehicleHash);
        }
    }
}
