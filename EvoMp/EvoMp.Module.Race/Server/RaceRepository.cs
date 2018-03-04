namespace EvoMp.Module.Race.Server
{
    /// <summary>
    ///     The RaceRepository class
    /// </summary>
    public class RaceRepository
    {
        /// <summary>
        ///     The singleton RaceRepository instance
        /// </summary>
        private static RaceRepository _raceRepository;

        /// <summary>
        ///     Private constructor wich initialize the RaceContext
        /// </summary>
        private RaceRepository()
        {
            new RaceContext().FirstInit();
        }

        /// <summary>
        ///     Creates an new RaceContext
        /// </summary>
        /// <returns>New Race context</returns>
        public static RaceContext GetRaceContext()
        {
            RaceContext context = new RaceContext();
            return context;
        }

        /// <summary>
        ///     Returns the singleton instance of the RaceRepository
        /// </summary>
        /// <returns></returns>
        public static RaceRepository GetInstance()
        {
            return _raceRepository ?? (_raceRepository = new RaceRepository());
        }
    }
}
