namespace EvoMp.Module.MapHandler.Server
{
    /// <summary>
    ///     The VehicleRepository class
    /// </summary>
    public class MapRepository
    {
        /// <summary>
        ///     The singleton VehicleRepository instance
        /// </summary>
        private static MapRepository _vehicleRepository;

        /// <summary>
        ///     Private constructor wich initialize the VehicleContext
        /// </summary>
        private MapRepository()
        {
            new MapContext().FirstInit();
        }

        /// <summary>
        ///     Creates an new VehicleContext
        /// </summary>
        /// <returns>New vehicle context</returns>
        public static MapContext GetMapContext()
        {
            MapContext context = new MapContext();
            return context;
        }

        /// <summary>
        ///     Returns the singleton instance of the VehicleRepository
        /// </summary>
        /// <returns></returns>
        public static MapRepository GetInstance()
        {
            return _vehicleRepository ?? (_vehicleRepository = new MapRepository());
        }
    }
}
