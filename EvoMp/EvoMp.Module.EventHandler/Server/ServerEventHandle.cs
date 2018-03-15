using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.EventHandler.Server
{
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
