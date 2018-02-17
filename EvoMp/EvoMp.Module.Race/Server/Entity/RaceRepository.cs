namespace EvoMp.Module.Race.Server.Entity
{
    /// <summary>
    ///     Repository handling the races
    /// </summary>
    public class RaceRepository
    {
        private static RaceRepository _vehicleRepository;

        private RaceRepository()
        {
            new RaceContext().FirstInit();
        }

        /// <summary>
        ///     Returns a context to interact with the race context
        /// </summary>
        /// <returns></returns>
        public static RaceContext GetRaceContext()
        {
            RaceContext context = new RaceContext();
            return context;
        }

        /// <summary>
        ///     Returns an instance of the RaceRepository
        /// </summary>
        /// <returns></returns>
        public static RaceRepository GetInstance()
        {
            return _vehicleRepository ?? (_vehicleRepository = new RaceRepository());
        }
    }
}
