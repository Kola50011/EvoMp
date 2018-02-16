using System;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using NLog.Targets;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class ClientWrapper : IClientWrapper
    {
        public ISetFunctions Setter { get; }
        public IGetFunctions Getter { get; }

        public ClientWrapper(API api, IEventHandler eventHandler)
        {
            Setter = new SetFunctions(eventHandler);
            Getter = new GetFunctions(api, eventHandler);
            eventHandler.SubscribeToServerEvent("Debug", new ServerEventHandle(OnClientDebugEvent));
        }

        private static void OnClientDebugEvent(Client user, string eventName, params object[] args)
        {
            if (args.Any())
                ConsoleOutput.WriteLine(ConsoleType.Debug, $"Client - [{user.name}] {args[0]}");
        }
    }
}
