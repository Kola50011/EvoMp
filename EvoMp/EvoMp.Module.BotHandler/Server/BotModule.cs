using EvoMp.Module.DbAccess.Server;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.BotHandler.Server
{
    public class BotModule : IBotModule
    {
        private readonly API _api;
        private readonly IMessageHandler _messageHandler;
        private readonly IVehicleHandler _vehicleHandler;
        public Commands Commands;

        public BotModule(API api, IDbAccess dbAcess, IVehicleHandler vehicleHandler,
            IMessageHandler messageHandler)
        {
            _api = api;
            _vehicleHandler = vehicleHandler;
            _messageHandler = messageHandler;

            Commands = new Commands(messageHandler, vehicleHandler);
        }
    }
}
