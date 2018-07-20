using EvoMp.Module.ClientHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using System.Collections.Generic;
using System.Linq;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class UserCommands
    {
        private readonly API api;
        private readonly IClientHandler clientHandler;

        public UserCommands(API api, IClientHandler clientHandler)
        {
            this.api = api;
            this.clientHandler = clientHandler;
        }

        [PlayerCommand("/skin")]
        public void SetSkin(Client sender, string skinName)
        {
            List<PedHash> possiblePeds = clientHandler.Utils.GetPedHashesByName(skinName);
            if (!possiblePeds.Any()) return;

            api.setPlayerSkin(sender, possiblePeds.First());
            api.sendChatMessageToPlayer(sender, $"Set skin to ~o~{possiblePeds.First()}~w~.");
            possiblePeds.RemoveAt(0);
            if (possiblePeds.Count > 0)
            {
                api.sendNotificationToPlayer(sender, $"Alternative skins: ~g~{string.Join(",", possiblePeds.First())}");
            }
        }

        [PlayerCommand("/points")]
        public void SetPoints(Client sender, int points)
        {
            if (points > 0)
            clientHandler.GetExtendetClient(sender).Properties.Points = points;
            api.sendChatMessageToPlayer(sender, $"your actual points {clientHandler.GetExtendetClient(sender).Properties.Points}");
        }
    }
}
