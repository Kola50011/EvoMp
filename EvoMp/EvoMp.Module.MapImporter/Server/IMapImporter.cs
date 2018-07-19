using System;
using EvoMp.Core.Module.Server;

namespace EvoMp.Module.MapImporter.Server
{
    [ModuleProperties("shared", "Ruffo, James", "Module to import maps.")]
    public interface IMapImporter
    {
        void RegisterImporterFunction(Func<string, bool> importerFunction);

        bool ImportMap(string path);
    }
}
