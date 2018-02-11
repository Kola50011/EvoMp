using System;

namespace EvoMp.Module.MessageHandler.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MessageTypeAttribute : Attribute
    {
        public string TagColorCode { get; }

        public string TagDisplayName { get; }

        /// <inheritdoc />
        /// <summary>
        /// Attribute for MessageType Enum
        /// </summary>
        /// <param name="tagColorCode">The color code of the message type tag</param>
        /// <param name="tagDisplayName">The display name of the tag</param>
        public MessageTypeAttribute(string tagColorCode, string tagDisplayName)
        {
            TagColorCode = tagColorCode;
            TagDisplayName = tagDisplayName;
        }
    }
}
