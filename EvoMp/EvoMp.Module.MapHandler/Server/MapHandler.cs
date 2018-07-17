using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.MapHandler.Server
{
    public class MapHandler : BaseModule, IMapHandler
    {
        private readonly API _api;

        public MapHandler(API api)
        {
            _api = api;
            using (MapContext context = MapRepository.GetMapContext())
            {
                if(context.Maps.Any(dto => true))
                    ConsoleOutput.WriteLine(ConsoleType.Debug, "YAY");
            }
        }
    }
}
