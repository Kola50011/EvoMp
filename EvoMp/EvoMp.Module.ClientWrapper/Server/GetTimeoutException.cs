using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
