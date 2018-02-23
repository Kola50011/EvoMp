using System;
using System.Runtime.Serialization;

namespace EvoMp.Module.BotHandler.Server.Exceptions
{
    public class PlaybackException : Exception
    {
        public PlaybackException()
        {
        }

        public PlaybackException(string message) : base(message)
        {
        }

        public PlaybackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlaybackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
