using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Module.MapImporter.Server.Exceptions
{
    public class MapImporterFunctionException : Exception
    {
        public MapImporterFunctionException(string message) : base(message)
        {
        }
    }
}
