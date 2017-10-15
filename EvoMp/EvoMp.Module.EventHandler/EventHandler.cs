using System.Collections.Generic;
using EvoMp.Module.Logger;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;

namespace EvoMp.Module.EventHandler
{
    public class EventHandler : IEventHandler
    {
        private readonly API _api;
        private readonly ILogger _logger;

        //ServerEvents
        private readonly Dictionary<string, List<ServerEventHandle>> _subscriberList =
            new Dictionary<string, List<ServerEventHandle>>();

        public EventHandler(API api, ILogger logger)
        {
            _api = api;
            _api.onClientEventTrigger += InvokeServerEvent;
            _logger = logger;
        }

        // ClientEvents
        public void InvokeClientEvent(Client client, string eventName, params object[] args)
        {
            _logger.Write(eventName + " for " + client.name + " with " + JsonConvert.SerializeObject(args),
                LogCase.ClientEvent);
            _api.triggerClientEvent(client, eventName, args);
        }

        public void InvokeClientEvent(string eventName, params object[] args)
        {
            _logger.Write(eventName + "for everyone with " + JsonConvert.SerializeObject(args),
                LogCase.ClientEvent);
            _api.triggerClientEventForAll(eventName, args);
        }

        public void SubscribeToServerEvent(string eventName, ServerEventHandle serverEventHandle)
        {
            _logger.Write("SubscribeToServerEvent " + eventName + " with " + serverEventHandle.Cab.Method.Name,
                LogCase.System);

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

                _logger.Write(eventName + " invoked by " + client.name + " with " +
                              JsonConvert.SerializeObject(argsDir), LogCase.ServerEvent);
            }
            else
            {
                _logger.Write(eventName + " invoked by " + client.name + " with " +
                              JsonConvert.SerializeObject(args), LogCase.ServerEvent);
            }

            if (_subscriberList.ContainsKey(eventName))
                foreach (ServerEventHandle serverEventHandle in _subscriberList.Get(eventName))
                    serverEventHandle.Cab.Invoke(client, eventName, args);
        }

        public string ModuleName { get; } = "EventHandler";
        public string ModuleDesc { get; } = "Wrapper for ClientEvents and ServerEvents";
        public string ModuleAuth { get; } = "Koka, Lukas";
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


