using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.Notifications.Server
{
    public class Notifications : BaseModule, INotifications
    {
        private readonly API _api;

        public Notifications(API api)
        {
            _api = api;
        }
    }
}
