using EvoMp.Module.ClientHandler.Server;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.Login.Server
{
    public class Login : ILogin
    {
        public Login(API api, IEventHandler eventHandler, IClientHandler clientHandler)
        {
            Authentication.Authentication auth = new Authentication.Authentication(api, eventHandler, clientHandler);
        }
    }
}
