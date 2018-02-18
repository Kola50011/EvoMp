using System;
using System.Runtime.Serialization;

namespace EvoMp.Module.ClientWrapper.Server
{
    public class GetTimeoutException : Exception
    {
        public GetTimeoutException()
        {
        }

        public GetTimeoutException(string message) : base(message)
        {
        }

        public GetTimeoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GetTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
