using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.EventHandler.Server
{
    [ModuleProperties("shared", "Koka, Lukas", "Wrapper for ClientEvents and ServerEvents")]
    public interface IEventHandler
    {
        void InvokeClientEvent(Client client, string eventName, params object[] args);
        void InvokeClientEvent(string eventName, params object[] args);

        void SubscribeToServerEvent(string eventName, ServerEventHandle serverEventHandle);
        void InvokeServerEvent(Client player, string eventName, object[] args);
    }
}