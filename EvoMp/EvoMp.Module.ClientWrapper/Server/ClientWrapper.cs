using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class ClientWrapper : IClientWrapper
    {
        public ISetFunctions Setter { get; }

        public ClientWrapper(IEventHandler eventHandler)
        {
            Setter = new SetFunctions(eventHandler);
        }
    }
}
