using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.VehicleHandler.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.BotHandler.Server
{
    public class Commands
    {
        private readonly IMessageHandler _messageHandler;
        private readonly IVehicleHandler _vehicleHandler;

        public Commands(IMessageHandler messageHandler, IVehicleHandler vehicleHandler)
        {
            _messageHandler = messageHandler;
            _vehicleHandler = vehicleHandler;
        }

        [PlayerCommand("/RecordBot", new[] {"/rbot"}, PlayerOnlyState.OnlyAsDriver)]
        public void RecordNewBot(Client sender, string botName)
        {

        }
    }
}
