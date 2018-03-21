using System;
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

        /// <inheritdoc />
        /// <summary>
        ///     Invokes an client event for all clients, and wait until all sended clients send the feedback event back.
        /// </summary>
        /// <param name="eventName">The event to invoke on all clients</param>
        /// <param name="feedbackEventName">The eventname for the feedback wich comes from all clients</param>
        /// <param name="compareArgs"></param>
        /// <param name="feedbackSuccessAction">The action, wich is called after all feedbacks recived</param>
        /// <param name="args">Args for the invoke event</param>
        /// <returns>List of invoked clients</returns>
        public void InvokeClientEventWithCallback(string eventName, string feedbackEventName,
            object[] compareArgs, Action<List<Client>> feedbackSuccessAction, params object[] args)
        {
            InvokeClientEventWithCallback(_api.getAllPlayers(), eventName, feedbackEventName, compareArgs,
                feedbackSuccessAction, args);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Invokes an client event for all clients, and wait until all sended clients send the feedback event back.
        /// </summary>
        /// <param name="invokeClients">Clients to invoke</param>
        /// <param name="eventName">The event to invoke on all clients</param>
        /// <param name="feedbackEventName">The eventname for the feedback wich comes from all clients</param>
        /// <param name="compareArgs"></param>
        /// <param name="feedbackSuccessAction">The action, wich is called after all feedbacks recived</param>
        /// <param name="args">Args for the invoke event</param>
        /// <returns>List of invoked clients</returns>
        public void InvokeClientEventWithCallback(List<Client> invokeClients, string eventName, string feedbackEventName,
            object[] compareArgs, Action<List<Client>> feedbackSuccessAction,  params object[] args)
        {
            // Clients wich got invoked
            List<Client> invokedClients = invokeClients.Where(client => !client.IsNull).ToList();

            // Function to register dissconnects or event feedbacks
            void RegisterFeedback(Client client)
            {
                // Remove client from invoked clients
                invokedClients.Remove(client);

                // Not all clients done -> return;
                if (invokedClients.Any())
                    return;

                // Unsubscribe events, call feedback action
                _api.onPlayerDisconnected -= OnPlayerDisconnected;
                UnsubscribeToServerEvent(feedbackEventName);
                feedbackSuccessAction(invokedClients);
            }

            // Function to register dissconnects to the feedback
            void OnPlayerDisconnected(Client client, string reason)
            {
                RegisterFeedback(client);
            }

            // Listen to relevant events
            _api.onPlayerDisconnected += OnPlayerDisconnected;
            SubscribeToServerEvent(feedbackEventName, new ServerEventHandle((client, name, objects) =>
            {
                // Feedback don't match to compareArgs -> return;
                for (int i = 0; i < compareArgs.Length; i++)
                    if (objects[i] != args[i])
                        return;

                RegisterFeedback(client);
            }));

            // Invoke client events
            foreach (Client client in invokedClients)
                InvokeClientEvent(client, eventName, args);
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
