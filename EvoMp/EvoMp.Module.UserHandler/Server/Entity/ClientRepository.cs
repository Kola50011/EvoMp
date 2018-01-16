using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.UserHandler.Server.Entity
{
    public class ClientRepository
    {
        private readonly API _api;

        public ClientRepository(API api)
        {
            _api = api;
            new ClientContext().FirstInit();
        }

        public ClientContext GetContext()
        {
            return new ClientContext();
        }
    }
}
