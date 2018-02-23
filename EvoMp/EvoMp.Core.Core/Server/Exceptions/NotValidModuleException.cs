using System;
using System.Runtime.Serialization;

namespace EvoMp.Core.Core.Server.Exceptions
{
    public class NotValidModuleException : Exception
    {
        public NotValidModuleException()
        {
        }

        public NotValidModuleException(string message) : base(message)
        {
        }

        public NotValidModuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotValidModuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
