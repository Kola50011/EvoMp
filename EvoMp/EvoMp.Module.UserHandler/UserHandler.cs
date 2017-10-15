using EvoMp.Module.DbAccess;
using EvoMp.Module.EventHandler;
using EvoMp.Module.Logger;
using EvoMp.Module.UserHandler.Entity;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.UserHandler
{
    public class UserHandler : IUserHandler
    {
        public UserHandler(API api, IEventHandler eventHandler, IDbAccess db, ILogger logger)
        {
            UserRepository userRepository = new UserRepository(api);

            SpawnManager spawnManager = new SpawnManager(api, userRepository, logger);
            Authentication.Authentication auth =
                new Authentication.Authentication(eventHandler, spawnManager, userRepository, api);
        }

        public string ModuleName { get; } = "UserHandler";
        public string ModuleDesc { get; } = "Everything that has to do with a user";
        public string ModuleAuth { get; } = "Koka, Lukas";
    }
}