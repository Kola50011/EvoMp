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

        public void PlayerMessage(Client sender, string message, MessageType messageType = MessageType.Note)
        {
            _api.sendChatMessageToPlayer(sender, $"{BuildMessageTag(messageType)}{message}");
        }

        void IMessageHandler.BroadcastMessage(string message, MessageType messageType)
        {
            BroadcastMessage(message, messageType);
        }

        public static void BroadcastMessage(string message, MessageType messageType = MessageType.Note)
        {
            API.shared.sendChatMessageToAll($"{BuildMessageTag(messageType)}{message}");
        }

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

        private static MessageTypeAttribute GetMessageTypeAttribute(MessageType messageType)
        {
            MemberInfo[] memberInfo = messageType.GetType().GetMember(messageType.ToString());
            MessageTypeAttribute attributes =
                (MessageTypeAttribute) memberInfo[0].GetCustomAttribute(typeof(MessageTypeAttribute), false);

            return attributes;
        }
    }
}
