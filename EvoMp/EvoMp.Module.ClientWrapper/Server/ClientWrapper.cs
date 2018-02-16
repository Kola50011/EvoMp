using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class ClientWrapper : IClientWrapper
    {
        private readonly IEventHandler _eventHandler;
        private readonly API _api;

        public ClientWrapper(API api, IEventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }
    }
}
