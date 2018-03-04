using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using EvoMp.Module.ClientHandler.Server;
using EvoMp.Module.ClientWrapper.Server;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.DbAccess.Server;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.BotHandler.Server
{
    public class BotHandler : BaseModule, IBotHandler
    {
        public readonly Commands Commands;
        public readonly Tracking Tracking;
        internal static IVehicleHandler VehicleHandler;
        internal static IClientHandler ClientHandler;
        internal static List<ExtendedBot> RecordingBots = new List<ExtendedBot>();
        internal static List<ExtendedBot> PlaybackBots = new List<ExtendedBot>();

        public BotHandler(API api, IDbAccess access, ICommandHandler commandHandler, IVehicleHandler vehicleHandler,
            IMessageHandler messageHandler, IClientWrapper clientWrapper, IEventHandler eventHandler, IClientHandler clientHandler)
        {
            VehicleHandler = vehicleHandler;
            ClientHandler = clientHandler;
            Commands = new Commands(messageHandler, vehicleHandler);
            Tracking = new Tracking(api, clientWrapper, eventHandler);
        }
    }
}
