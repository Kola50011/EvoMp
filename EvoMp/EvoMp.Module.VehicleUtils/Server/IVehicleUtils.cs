using EvoMp.Core.Module.Server;
using System.Collections.Generic;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.VehicleUtils.Server
{
    [ModuleProperties("shared", "Ruffo", "Vehicle Utils & Enums")]
    public interface IVehicleUtils
    {
        List<VehicleHash> GetVehiclesByName(string searchVehicleName);

        List<VehicleHash> GetVehiclesByCategory(VehicleCategory category);

        List<VehicleHash> GetVehiclesByIngameName(string searchIngameVehicleName);

        VehicleCategory GetVehicleCategory(VehicleHash vehicleHash);
    }
}
