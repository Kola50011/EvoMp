using EvoMp.Module.Race.Server.Entity;
using EvoMp.Module.VehicleHandler.Server;

namespace EvoMp.Module.Race.Server
{
    /// <summary>
    /// Race minigame
    /// </summary>
    public class Race : IRace
    {
        private RaceRepository _raceRepository = RaceRepository.GetInstance();

        public Race(IVehicleHandler vehcileHandler)
        {
            
        }
    }
}
