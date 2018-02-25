using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.ClientWrapper.Server
{
    /// <summary>
    ///     <code>",[^,]+(,[^,)]+){13} (Regex. Use for parameter type remove)</code>
    /// </summary>
    public class ClientWrapper : BaseModule, IClientWrapper
    {
        public ClientWrapper(API api, IEventHandler eventHandler)
        {
            Setter = new SetFunctions(eventHandler);
            Getter = new GetFunctions(eventHandler);
        }

        public ISetFunctions Setter { get; }
        public IGetFunctions Getter { get; }
    }
}
