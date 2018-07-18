using System.Collections.Generic;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Core.Shared.Server;
using EvoMp.Module.MapHandler.Server.Entity;
using EvoMp.Module.MapHandler.Server.Exception;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.MapHandler.Server
{
    public class MapHandler : BaseModule, IMapHandler
    {
        private readonly API _api;
        private readonly List<MapObjectDto> _loadedMapObjects;

        public MapHandler(API api)
        {
            _api = api;
            _loadedMapObjects = new List<MapObjectDto>();
            SharedEvents.OnAfterCoreStartupCompleted += OnAfterCoreStartupCompleted;
        }

        public MapDto CreateAndSaveNewMap(string mapName, int dimension, List<MapObjectDto> mapObjects,
            bool active = true)
        {
            MapDto newMap;
            using (MapContext mapContext = MapRepository.GetMapContext())
            {
                // Add new map.
                newMap = mapContext.Maps.Add(new MapDto
                {
                    Dimension = dimension,
                    Name = mapName,
                    Active = active
                });

                // Save map.
                mapContext.SaveChanges();

                // Add new map objects.
                mapObjects.ForEach(dto =>
                {
                    dto.MapId = newMap.MapId;
                    dto.Map = newMap;
                    mapContext.MapObjects.Add(dto);
                });

                // Save map objects.
                mapContext.SaveChanges();
            }

            return newMap;
        }

        public int LoadMap(int mapId)
        {
            using (MapContext mapContext = MapRepository.GetMapContext())
            {
                MapDto map = mapContext.Maps.FirstOrDefault(dto => dto.MapId == mapId);
                if (map == null)
                    throw new MapHandlerLoadingException($"There is no map with id \"{mapId}\".");

                return LoadMap(map);
            }
        }

        public int LoadMap(MapDto map)
        {
            // Map = null -> exception;
            if (map == null)
                throw new MapHandlerLoadingException($"Can't load map with value \"null\".");

            // Get map objects
            List<MapObjectDto> mapObjects = new List<MapObjectDto>();
            using (MapContext mapContext = MapRepository.GetMapContext())
            {
                mapObjects.AddRange(mapContext.MapObjects.Where(dto => dto.MapId == map.MapId));
            }

            // Create map objects in real world
            int loadedObjects = 0;
            foreach (MapObjectDto mapObject in mapObjects)
            {
                mapObject.Object =
                    _api.createObject(mapObject.Hash, mapObject.Position, mapObject.Rotation, map.Dimension);
                loadedObjects++;
            }

            _loadedMapObjects.AddRange(mapObjects);
            return loadedObjects;
        }

        public int UnloadMap(MapDto map)
        {
            // Map = null -> exception;
            if (map == null)
                throw new MapHandlerLoadingException($"Can't unload map with value \"null\".");

            return UnloadMap(map.MapId);
        }

        public int UnloadMap(int mapId)
        {
            List<MapObjectDto> removeMapObjects = new List<MapObjectDto>();
            foreach (MapObjectDto mapObject in _loadedMapObjects)
                if (mapObject.MapId == mapId)
                {
                    _api.deleteEntity(mapObject.Object);
                    removeMapObjects.Add(mapObject);
                }

            foreach (MapObjectDto removedMapObject in removeMapObjects)
                _loadedMapObjects.Remove(removedMapObject);

            return removeMapObjects.Count;
        }

        private void OnAfterCoreStartupCompleted()
        {
            using (MapContext mapContext = MapRepository.GetMapContext())
            {
                foreach (MapDto mapDto in mapContext.Maps.Where(dto => dto.Active))
                {
                    LoadMap(mapDto);
                    ConsoleOutput.WriteLine(ConsoleType.Note, $"Map {mapDto.Name} loaded.");
                }
            }
        }
    }
}
