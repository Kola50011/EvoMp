using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Module.BotHandler.Server
{
    public class RecordingException : Exception
    {
        public RecordingException()
        {
        }

        public RecordingException(string message) : base(message)
        {
        }

        public RecordingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecordingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
