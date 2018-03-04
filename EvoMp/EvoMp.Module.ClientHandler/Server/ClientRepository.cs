using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.ClientHandler.Server
{
    /// <summary>
    /// The ClientRepository class
    /// </summary>
    public class ClientRepository
    {
        /// <summary>
        /// The singleton ClientRepository instance
        /// </summary>
        private static ClientRepository _ClientRepository;

        /// <summary>
        /// Private constructor wich initialize the ClientContext
        /// </summary>
        private ClientRepository()
        {
            new ClientContext().FirstInit();
        }

        /// <summary>
        /// Creates an new ClientContext
        /// </summary>
        /// <returns>New Client context</returns>
        public static ClientContext GetClientContext()
        {
            ClientContext context = new ClientContext();
            return context;
        }

        /// <summary>
        /// Returns the singleton instance of the ClientRepository
        /// </summary>
        /// <returns></returns>
        public static ClientRepository GetInstance()
        {
            return _ClientRepository ?? (_ClientRepository = new ClientRepository());
        }
    }
}
