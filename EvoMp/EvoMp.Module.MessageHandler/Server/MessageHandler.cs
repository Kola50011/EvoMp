using EvoMp.Core.ColorHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.MessageHandler.Server
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
            _api.sendChatMessageToPlayer(sender, ColorUtils.CleanUp(message));
        }
    }
}