using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class GetFunctions : IGetFunctions //: IGetFunctions
    {
        private const int WaitTimeoutMs = 1000; // 1 sec
        private Random randomHash = new Random();
        private readonly API _api;
        private readonly IEventHandler _eventHandler;

        public GetFunctions(API api, IEventHandler eventHandler)
        {
            _api = api;
            _eventHandler = eventHandler;
        }

        public async Task<string> GetStreetName(Client sender, Vector3 position)
        {
            return await GetFromClient<string>(sender, "ClientWrapper.Get.getStreetName", position);
        }

        /// <summary>
        /// Waiting for the return value of the client get function
        /// </summary>
        /// <typeparam name="T">Type of client function</typeparam>
        /// <param name="sender">Player</param>
        /// <param name="eventName">The event name</param>
        /// <param name="arguments">Event arguments</param>
        /// <exception cref="GetTimeoutException">Throws exception if timeout.</exception>
        /// <returns>Client return value</returns>
        private async Task<T> GetFromClient<T>(Client sender, string eventName, params object[] arguments)
        {
            T returnValue = default(T);
            bool recived = false;
            // Generate unique event name 
            string uniqueEventName = "";
            while (_eventHandler.EventSubscribed(uniqueEventName) || uniqueEventName == "")
                uniqueEventName = $"{eventName}{randomHash.Next(10000, 90000)}";

            // Bind recive event
            ServerEventHandle reciveServerEventHandle = new ServerEventHandle(OnReciveEventTriggered);
            _eventHandler.SubscribeToServerEvent(uniqueEventName, reciveServerEventHandle);

            // Trigger client event
            _eventHandler.InvokeClientEvent(sender, eventName, new object[] {uniqueEventName}.Concat(arguments).ToArray());

            void OnReciveEventTriggered(Client reciveSender, string reciveEventName, params object[] reciveArguments)
            {
                if (reciveEventName != uniqueEventName || !reciveArguments.Any() || !reciveSender.Equals(sender)) return;
                returnValue = (T) reciveArguments[0];
                recived = true;
            }

            return await Task.Run(() =>
            {
                DateTime startTimeoutCheck = DateTime.Now;
                while (startTimeoutCheck.AddMilliseconds(WaitTimeoutMs) > DateTime.Now && !recived)
                    Thread.Sleep(10);

                _eventHandler.UnsubscribeToServerEvent(uniqueEventName);

                // Throw Exception if timeout
                if (!recived)
                    throw new GetTimeoutException($"Timeout on ClientWrapper.Get event {uniqueEventName}");

                return returnValue;
            });
        }
    }
}
