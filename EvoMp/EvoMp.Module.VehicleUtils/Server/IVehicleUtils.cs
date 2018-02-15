using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using EvoMp.Module.VehicleUtils.Server.Enums;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.VehicleUtils.Server
{
    [ModuleProperties("shared", "Ruffo", "Vehicle Utils & Enums")]
    public interface IVehicleUtils
    {
        List<VehicleHash> GetVehiclesByName(string searchVehicleName);

        List<VehicleHash> GetVehiclesByClass(VehicleClass vehicleClass);

        List<VehicleHash> GetVehiclesByIngameName(string searchIngameVehicleName);
    }
}
