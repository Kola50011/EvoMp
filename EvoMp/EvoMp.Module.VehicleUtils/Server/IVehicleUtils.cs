using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.VehicleUtils.Server
{
    [ModuleProperties("shared", "Ruffo", "Vehicle Utils & Enums")]
    public interface IVehicleUtils
    {
        /// <summary>
        /// Returns possible vehicleHashes for the given vehicle hash name
        /// </summary>
        /// <param name="searchVehicleName">The search vehicle hash name pattern</param>
        /// <returns>List with possible VehicleHashes</returns>
        List<VehicleHash> GetVehiclesByName(string searchVehicleName);

        /// <summary>
        /// Returns vehicleHashes for the given vehicle class
        /// </summary>
        /// <param name="vehicleClass">The searched vehicleClass</param>
        /// <returns>List with class matching VehicleHashes</returns>
        List<VehicleHash> GetVehiclesByClass(VehicleClass vehicleClass);

        /// <summary>
        /// Returns possible vehicleHashes for the given ingame vehicle name
        /// </summary>
        /// <param name="searchIngameVehicleName">The search ingame vehicle name pattern</param>
        /// <returns>List with possible VehicleHashes</returns>
        List<VehicleHash> GetVehiclesByIngameName(string searchIngameVehicleName);
    }
}
