using System.Collections.Generic;
using EvoMp.Core.ConsoleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;

namespace EvoMp.Module.EventHandler.Server
{
    public class EventHandler : IEventHandler
    {
        private readonly API _api;

        //ServerEvents
        private readonly Dictionary<string, List<ServerEventHandle>> _subscriberList =
            new Dictionary<string, List<ServerEventHandle>>();

        public EventHandler(API api)
        {
            _api = api;
            _api.onClientEventTrigger += InvokeServerEvent;
        }

        // ClientEvents
        public void InvokeClientEvent(Client client, string eventName, params object[] args)
        {
            ConsoleOutput.WriteLine(ConsoleType.Event,
                eventName + " for " + client.name + " with " + JsonConvert.SerializeObject(args));
            _api.triggerClientEvent(client, eventName, args);
        }

        public void InvokeClientEvent(string eventName, params object[] args)
        {
            ConsoleOutput.WriteLine(ConsoleType.Event,
                eventName + "for everyone with " + JsonConvert.SerializeObject(args));
            _api.triggerClientEventForAll(eventName, args);
        }

        public void SubscribeToServerEvent(string eventName, ServerEventHandle serverEventHandle)
        {
            ConsoleOutput.WriteLine(ConsoleType.Event,
                "SubscribeToServerEvent " + eventName + " with " + serverEventHandle.Cab.Method.Name);

            List<ServerEventHandle> list = new List<ServerEventHandle>();

            if (_subscriberList.ContainsKey(eventName))
                list = _subscriberList.Get(eventName);

            list.Add(serverEventHandle);
            _subscriberList.Set(eventName, list);
        }

        public void InvokeServerEvent(Client client, string eventName, object[] args)
        {
            if (args.Length > 0)
            {
                Dictionary<string, string> argsDir =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(args[0].ToString());

                if (argsDir.ContainsKey("password"))
                    argsDir["password"] = "*****";

                ConsoleOutput.WriteLine(ConsoleType.Event, eventName + " invoked by " + client.name + " with " +
                                                           JsonConvert.SerializeObject(argsDir));
            }
            else
            {
                ConsoleOutput.WriteLine(ConsoleType.Event, eventName + " invoked by " + client.name + " with " +
                                                           JsonConvert.SerializeObject(args));
            }

            if (_subscriberList.ContainsKey(eventName))
                foreach (ServerEventHandle serverEventHandle in _subscriberList.Get(eventName))
                    serverEventHandle.Cab.Invoke(client, eventName, args);
        }
    }

    public class ServerEventHandle
    {
        public delegate void Callback(Client user, string eventName, params object[] args);

        public Callback Cab;

        public ServerEventHandle(Callback cab)
        {
            Cab = cab;
        }
    }
}
