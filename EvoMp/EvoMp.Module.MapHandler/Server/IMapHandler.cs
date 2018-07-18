using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using EvoMp.Module.MapHandler.Server.Entity;

namespace EvoMp.Module.MapHandler.Server
{
    [ModuleProperties("shared", "James, Ruffo", "Module to handle maps.")]
    public interface IMapHandler
    {
        MapDto CreateAndSaveNewMap(string mapName, int dimension, List<MapObjectDto> mapObjects, bool active = true);

        int UnloadMap(MapDto map);
        int UnloadMap(int mapId);

        int LoadMap(MapDto map);
        int LoadMap(int mapId);
    }
}
