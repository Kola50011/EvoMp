using EvoMp.Core.Module.Server;
using EvoMp.Module.VehicleHandler.Server;

namespace EvoMp.Module.Race.Server
{
    /// <summary>
    ///     Race minigame
    /// </summary>
    public class Race : BaseModule, IRace
    {
        private RaceRepository _raceRepository = RaceRepository.GetInstance();

        public Race(IVehicleHandler vehcileHandler)
        {
        }
    }
}
