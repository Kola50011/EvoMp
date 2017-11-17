using System;
using EvoMp.Core.ColorHandler;
using EvoMp.Core.Module;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler
{
    public class MessageHandler : IMessageHandler
    {
        private readonly API _api;

        //TODO: Rewrite functions. Core.MessageHandler.
        public MessageHandler(API api)
        {
            _api = api;
        }

        public void PlayerMessage(Client sender, string message)
        {
            _api.sendChatMessageToPlayer(sender, ColorUtils.CleanUpColorCodes(message));
        }
    }
}
