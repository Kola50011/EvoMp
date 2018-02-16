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
        private readonly API _api;
        private readonly IEventHandler _eventHandler;

        public GetFunctions(API api, IEventHandler eventHandler)
        {
            _api = api;
            _eventHandler = eventHandler;
        }

        public async Task<string> GetStreetName(Client sender, Vector3 position)
        {
            return await GetFromClient(sender, "ClientWrapper.Get.getStreetName", "Unknown", position);
        }


        private async Task<T> GetFromClient<T>(Client sender, string eventName, T defaultValue,
            params object[] arguments)
        {
            T returnValue = defaultValue;

            // Bind recive event & trigger triggerEvent
            _api.onClientEventTrigger += OnReciveEventTriggered;
            _eventHandler.InvokeClientEvent(sender, eventName, arguments);

            void OnReciveEventTriggered(Client reciveSender, string reciveEventName, params object[] reciveArguments)
            {
                if (reciveEventName == eventName && reciveArguments.Any() && reciveSender.Equals(sender))
                    returnValue = (T)reciveArguments[0];
            }

            return await Task.Run(() =>
            {
                DateTime startTimeoutCheck = DateTime.Now;
                while (startTimeoutCheck.AddMilliseconds(WaitTimeoutMs) > DateTime.Now && returnValue.Equals(defaultValue))
                    Thread.Sleep(10);

                _api.onClientEventTrigger -= OnReciveEventTriggered;
                return returnValue;
            });
        }
    }
}
