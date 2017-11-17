using EvoMp.Core.Module;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler
{
    [ModuleProperties("shared", "Ruffo", "Handles player messages on the server.")]
    public interface IMessageHandler
    {
        void PlayerMessage(Client sender, string message);
    }
}
