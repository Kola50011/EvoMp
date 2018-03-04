using EvoMp.Core.Module.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler.Server
{
    [ModuleProperties("shared", "Ruffo", "Handles client messages.")]
    public interface IMessageHandler
    {
        /// <summary>
        /// Sends a message to sender.
        /// </summary>
        /// <param name="sender">The player for the message</param>
        /// <param name="message">The message</param>
        /// <param name="messageType">The type of the message</param>
        void PlayerMessage(Client sender, string message, MessageType messageType = MessageType.Note);

        /// <summary>
        /// Sends the given message to all players
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="messageType">The type of the message</param>
        void BroadcastMessage(string message, MessageType messageType = MessageType.Note);
    }
}
