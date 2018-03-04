using System.Reflection;
using EvoMp.Core.Module.Server;
using EvoMp.Module.MessageHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler.Server
{
    public class MessageHandler : BaseModule, IMessageHandler
    {
        private readonly API _api;

        public MessageHandler(API api)
        {
            _api = api;
        }

        /// <summary>
        /// Sends a message to sender.
        /// </summary>
        /// <param name="sender">The player for the message</param>
        /// <param name="message">The message</param>
        /// <param name="messageType">The type of the message</param>
        public void PlayerMessage(Client sender, string message, MessageType messageType = MessageType.Note)
        {
            _api.sendChatMessageToPlayer(sender, $"{BuildMessageTag(messageType)}{message}");
        }

        /// <inheritdoc />
        /// <summary>
        /// Sends the given message to all players
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="messageType">The type of the message</param>
        public void BroadcastMessage(string message, MessageType messageType)
        {
            _api.sendChatMessageToAll($"{BuildMessageTag(messageType)}{message}");
        }

        /// <summary>
        /// Builds the correct Tag for the given messageType
        /// </summary>
        /// <param name="messageType">The messageType</param>
        /// <returns>MessageType formated string</returns>
        private static string BuildMessageTag(MessageType messageType)
        {
            // No Tag -> return empty string
            if (messageType == MessageType.None)
                return "";

            MessageTypeAttribute typeAttribute = GetMessageTypeAttribute(messageType);
            //TODO: Translate TagDisplayName
            //TODO: Replace later with: │ (Cef based chat)
            return $"~w~| {typeAttribute.TagColorCode}{typeAttribute.TagDisplayName.PadRight(10)}~w~| ~;~";
        }

        /// <summary>
        /// Returns the MessageTypeAttribute for the MessageType enum
        /// </summary>
        /// <param name="messageType">MessageType</param>
        /// <returns>MessageTypeAttribute</returns>
        private static MessageTypeAttribute GetMessageTypeAttribute(MessageType messageType)
        {
            MemberInfo[] memberInfo = messageType.GetType().GetMember(messageType.ToString());
            MessageTypeAttribute attributes =
                (MessageTypeAttribute) memberInfo[0].GetCustomAttribute(typeof(MessageTypeAttribute), false);

            return attributes;
        }
    }
}
