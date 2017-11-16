using EvoMp.Module.DbAccess;
using EvoMp.Module.EventHandler;
using EvoMp.Module.UserHandler.Entity;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.UserHandler
{
    public class UserHandler : IUserHandler
    {
        public UserHandler(API api, IEventHandler eventHandler, IDbAccess db)
        {
            UserRepository userRepository = new UserRepository(api);

            SpawnManager spawnManager = new SpawnManager(api, userRepository);
            Authentication.Authentication auth =
                new Authentication.Authentication(eventHandler, spawnManager, userRepository, api);
        }
    }
}