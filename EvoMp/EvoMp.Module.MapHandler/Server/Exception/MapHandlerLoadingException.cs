using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Module.MapHandler.Server.Exception
{
    public class MapHandlerLoadingException : System.Exception
    {
        public MapHandlerLoadingException(string message) : base(message)
        {
        }
    }
}
