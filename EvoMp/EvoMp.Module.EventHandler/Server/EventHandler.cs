using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using Newtonsoft.Json;

namespace EvoMp.Module.EventHandler.Server
{
    public class EventHandler : BaseModule, IEventHandler
    {
        private readonly API _api;

        private readonly List<string> _notLoggingEvents = new List<string>();

        //ServerEvents
        private readonly Dictionary<string, List<ServerEventHandle>> _subscriberList =
            new Dictionary<string, List<ServerEventHandle>>();

        public EventHandler(API api)
        {
            _api = api;
            _api.onClientEventTrigger += InvokeServerEvent;

            SubscribeToServerEvent("Debug", new ServerEventHandle(OnClientDebugEvent));
            SetLogging("Debug", false);
        }

        public void SetLogging(string eventName, bool logging)
        {
            // Logging enabled -> remove from list & return
            if (logging)
            {
                _notLoggingEvents.Remove(eventName);
                return;
            }

            // Add to ignore list
            if (!_notLoggingEvents.Contains(eventName))
                _notLoggingEvents.Add(eventName);
        }

        // ClientEvents
        public void InvokeClientEvent(Client client, string eventName, params object[] args)
        {
            if (!_notLoggingEvents.Contains(eventName))
                ConsoleOutput.WriteLine(ConsoleType.Event,
                    $" ~#85a7dd~{eventName}~;~ ~w~>> {client.name} ~c~{JsonConvert.SerializeObject(args)}");
            _api.triggerClientEvent(client, eventName, args);
        }

        public void InvokeClientEvent(string eventName, params object[] args)
        {
            if (!_notLoggingEvents.Contains(eventName))
                ConsoleOutput.WriteLine(ConsoleType.Event,
                    $"~#85a7dd~{eventName}~;~ ~w~>> ~w~everyone ~c~{JsonConvert.SerializeObject(args)}");

            _api.triggerClientEventForAll(eventName, args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SubscribeToServerEvent(string eventName, ServerEventHandle serverEventHandle)
        {
            ConsoleOutput.WriteLine(ConsoleType.Event,
                "Listen event ~#85a7dd~" + eventName + "~;~ in ~#85a7dd~" +
                (serverEventHandle.Cab.Method.DeclaringType != null
                    ? serverEventHandle.Cab.Method.DeclaringType.FullName
                    : "?." + serverEventHandle.Cab.Method.Name));

            List<ServerEventHandle> list = new List<ServerEventHandle>();

            if (_subscriberList.ContainsKey(eventName))
                list = _subscriberList.Get(eventName);

            list.Add(serverEventHandle);
            _subscriberList.Set(eventName, list);
        }

        public bool EventSubscribed(string eventName)
        {
            return _subscriberList.ContainsKey(eventName);
        }

        public void UnsubscribeToServerEvent(string eventName)
        {
            if (_subscriberList.Remove(eventName))
                ConsoleOutput.WriteLine(ConsoleType.Event, "Stop listen event ~#85a7dd~" + eventName + "~;~.");
        }

        private static void OnClientDebugEvent(Client user, string eventName, params object[] args)
        {
            if (args.Any())
                ConsoleOutput.WriteLine(ConsoleType.Debug, $"Client - [{user.name}] {args[0]}");
        }

        public void InvokeClientEvent(Client client, bool logging, string eventName, params object[] args)
        {
            if (!_notLoggingEvents.Contains(eventName))
                ConsoleOutput.WriteLine(ConsoleType.Event,
                    $" ~#85a7dd~{eventName}~;~ ~w~>> {client.name} ~c~{JsonConvert.SerializeObject(args)}");
            _api.triggerClientEvent(client, eventName, args);
        }

        private void InvokeServerEvent(Client client, string eventName, object[] args)
        {
            // Create emtpy object if null.
            if (args == null)
                args = new object[] { };

            if (!_notLoggingEvents.Contains(eventName))
                ConsoleOutput.WriteLine(ConsoleType.Event,
                    $"~w~{client.name} ~w~>> ~#85a7dd~{eventName}~;~ ~c~{JsonConvert.SerializeObject(args)}");

            if (!_subscriberList.ContainsKey(eventName))
                return;

            foreach (ServerEventHandle serverEventHandle in _subscriberList.Get(eventName))
                serverEventHandle.Cab.Invoke(client, eventName, args);
        }
    }
}
