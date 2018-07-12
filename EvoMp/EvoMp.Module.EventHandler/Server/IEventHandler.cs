using System;
using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.EventHandler.Server
{
    [ModuleProperties("shared", "Koka, Lukas", "Wrapper for ClientEvents and ServerEvents")]
    public interface IEventHandler
    {
        void InvokeClientEvent(Client client, string eventName, params object[] args);

        void InvokeClientEvent(string eventName, params object[] args);

        /// <summary>
        ///     Invokes an client event for all clients, and wait until all sended clients send the feedback event back.
        /// </summary>
        /// <param name="eventName">The event to invoke on all clients</param>
        /// <param name="feedbackEventName">The eventname for the feedback wich comes from all clients</param>
        /// <param name="compareArgs">Compare args. To compare feedback event args1</param>
        /// <param name="feedbackSuccessAction">The action, wich is called after all feedbacks recived</param>
        /// <param name="args">Args for the invoke event</param>
        void InvokeClientEventWithCallback(string eventName, string feedbackEventName,
            object[] compareArgs, Action<List<Client>> feedbackSuccessAction, params object[] args);

        /// <summary>
        ///     Invokes an client event for all clients, and wait until all sended clients send the feedback event back.
        /// </summary>
        /// <param name="invokeClients">Clients to invoke</param>
        /// <param name="eventName">The event to invoke on all clients</param>
        /// <param name="feedbackEventName">The eventname for the feedback wich comes from all clients</param>
        /// <param name="compareArgs"></param>
        /// <param name="feedbackSuccessAction">The action, wich is called after all feedbacks recived</param>
        /// <param name="args">Args for the invoke event</param>
        void InvokeClientEventWithCallback(List<Client> invokeClients, string eventName,
            string feedbackEventName,
            object[] compareArgs, Action<List<Client>> feedbackSuccessAction, params object[] args);

        void SubscribeToServerEvent(string eventName, ServerEventHandle serverEventHandle);

        bool EventSubscribed(string eventName);

        void UnsubscribeToServerEvent(string eventName);

        void SetLogging(string eventName, bool logging);
    }
}
