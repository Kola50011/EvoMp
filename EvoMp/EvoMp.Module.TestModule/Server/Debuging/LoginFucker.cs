using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class LoginFucker
    {
        private readonly API _api;
        private readonly IMessageHandler _messageHandler;

        public LoginFucker(API api, IMessageHandler messageHandler)
        {
            _api = api;
            _messageHandler = messageHandler;
            api.onPlayerConnected += OnPlayerConnected;
        }

        private void OnPlayerConnected(Client sender)
        {
            _messageHandler.PlayerMessage(sender, "Do ~b~/fl~w~ for fake login..", MessageType.Help);
        }


        [PlayerCommand("/fakeLogin", new[] {"/fl"})]
        public void TestCommand(Client sender)
        {
            _api.setEntityInvincible(sender, false);
            _api.freezePlayer(sender, false);
            _api.setEntityTransparency(sender, 255);
            _api.setEntityCollisionless(sender, false);
            _messageHandler.PlayerMessage(sender, "~o~Ping. ~g~Pong. ~o~Wuusch!", MessageType.Debug);
        }
    }
}
