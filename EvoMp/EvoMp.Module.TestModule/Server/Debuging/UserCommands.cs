using EvoMp.Module.ClientHandler.Server;
using EvoMp.Module.ClientWrapper.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class UserCommands
    {
        private readonly API api;
        private readonly IClientHandler clientHandler;
        private readonly IMessageHandler messageHandler;
        private readonly IClientWrapper clientWrapper;
        private Vector3 pickupPos = new Vector3();

        public UserCommands(API api, IClientHandler clientHandler, IMessageHandler messageHandler, IClientWrapper clientWrapper)
        {
            this.messageHandler = messageHandler;
            this.api = api;
            this.clientHandler = clientHandler;
            this.clientWrapper = clientWrapper;
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

        [PlayerCommand("/n")]
        public void SendPlayerRandomNotification(Client sender)
        {
            messageHandler.PlayerMessage(sender, "test message to me", MessageType.Note);
            messageHandler.BroadcastMessage("hello from broadcast", MessageType.Warn);
        }

        [PlayerCommand("/sp")]
        public void setPosition(Client sender)
        {
            pickupPos = sender.position;
            api.sendChatMessageToPlayer(sender, "position saved");
        }

        [PlayerCommand("/sc")]
        public void takeScreenshots(Client sender)
        {

            ScreenCapturer sc = new ScreenCapturer();
            Bitmap bitmap;
            clientWrapper.Setter.SetEntityTransparency(sender, sender, 0);
            clientWrapper.Setter.SetCameraBehindPlayer(sender);
            api.freezePlayer(sender, true);
            clientWrapper.Setter.ToggleFirstPersonCam(sender, true);
            Pickup p;
            foreach (PickupHash ph in Enum.GetValues(typeof(PickupHash))) {
                    p = api.createPickup(ph, pickupPos, new Vector3(0,0,0), 0, 0);
                Thread.Sleep(200);
                bitmap = sc.Capture();
                bitmap.Save($"C:\\Users\\tilme\\Pictures\\gtmp\\{ph.ToString()}.jpg");
                api.deleteEntity(p);
            }
            api.sendChatMessageToPlayer(sender, "done with screen capturing");
        }
       

    }
}
