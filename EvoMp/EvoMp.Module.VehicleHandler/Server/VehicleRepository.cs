namespace EvoMp.Module.VehicleHandler.Server
{
    /// <summary>
    ///     The VehicleRepository class
    /// </summary>
    public class VehicleRepository
    {
        /// <summary>
        ///     The singleton VehicleRepository instance
        /// </summary>
        private static VehicleRepository _vehicleRepository;

        /// <summary>
        ///     Private constructor wich initialize the VehicleContext
        /// </summary>
        private VehicleRepository()
        {
            new VehicleContext().FirstInit();
        }

        /// <summary>
        ///     Creates an new VehicleContext
        /// </summary>
        /// <returns>New vehicle context</returns>
        public static VehicleContext GetVehicleContext()
        {
            VehicleContext context = new VehicleContext();
            return context;
        }

        /// <summary>
        ///     Returns the singleton instance of the VehicleRepository
        /// </summary>
        /// <returns></returns>
        public static VehicleRepository GetInstance()
        {
            return _vehicleRepository ?? (_vehicleRepository = new VehicleRepository());
        }
    }
}
