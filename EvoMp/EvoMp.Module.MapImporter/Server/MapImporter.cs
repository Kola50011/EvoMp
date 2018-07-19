using System;
using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using EvoMp.Module.MapImporter.Server.Exceptions;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.MapImporter.Server
{
    public class MapImporter : BaseModule, IMapImporter
    {
        private readonly List<Func<string, bool>> _importerFunctions = new List<Func<string, bool>>();

        public MapImporter()
        {
            // Init and register importer.
            SpoonerImporter spoonerImporter = new SpoonerImporter();
            RegisterImporterFunction(spoonerImporter.ImportMap);

        }

        public void RegisterImporterFunction(Func<string, bool> importerFunction)
        {
            // Function is alread registered -> exception.
            if(_importerFunctions.Contains(importerFunction))
                throw new MapImporterFunctionException($"The function {importerFunction.Method.GetType().FullName} is already a registered importer function.");

            _importerFunctions.Add(importerFunction);
        }

        public bool ImportMap(string path)
        {
            foreach (Func<string, bool> importerFunction in _importerFunctions)
                if (importerFunction(path))
                    return true;

            return false;
        }
    }
}
