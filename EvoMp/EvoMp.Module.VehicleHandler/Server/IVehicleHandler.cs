using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.VehicleHandler.Server
{
    [ModuleProperties("shared", "Ruffo", "Vehicle Handler Module")]
    public interface IVehicleHandler
    {
        /// <summary>
        ///     Creates a new ExtendedVehicle by vehicleHash, position, rotation, dimension
        /// </summary>
        /// <param name="vehicleHash">The VehicleHash of the new ExtendedVehicle</param>
        /// <param name="position">The position of the new ExtendedVehicle</param>
        /// <param name="rotation">The rotation of the new ExtendedVehicle</param>
        /// <param name="dimension">The dimension of the new ExtendedVehicle</param>
        ExtendedVehicle CreateExtendedVehicle(VehicleHash vehicleHash, Vector3 position, Vector3 rotation, int dimension);

        /// <summary>
        ///     Creates an existing ExtendedVehicle by Vehicles table VehicleId
        /// </summary>
        /// <param name="vehicleId">The vehicleId of the wanted extendedVehicle</param>
        ExtendedVehicle CreateExtendedVehicle(int vehicleId);

        /// <summary>
        ///     Creates an Extendend Vehicle from an NetHandle.
        ///     Creates the saved ExtendedVehicle if the NetHandle has the "VehicleId" entity data.
        ///     If this is not the case, it creates a new ExtendedVehicle
        /// </summary>
        /// <param name="vehicle">The vehicle from wich the extendedVehicle should created.</param>
        ExtendedVehicle CreateExtendedVehicle(NetHandle vehicle);
    }
}
