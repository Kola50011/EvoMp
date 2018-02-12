using EvoMp.Core.Module.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler.Server
{
    [ModuleProperties("shared", "Ruffo", "Handles player messages on the server.")]
    public interface IMessageHandler
    {
        void PlayerMessage(Client sender, string message, MessageType messageType = MessageType.Note);

        /// <summary>
        ///     Message to all players.
        /// </summary>
        void BroadcastMessage(string message, MessageType messageType = MessageType.Note);
    }
}
