using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler.Server
{
    [ModuleProperties("shared", "Ruffo", "Handles player messages on the server.")]
    public interface IMessageHandler
    {
        void PlayerMessage(Client sender, string message);
    }
}