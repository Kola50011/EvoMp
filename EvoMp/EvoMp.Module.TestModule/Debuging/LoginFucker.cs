using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Debuging
{
    public class LoginFucker
    {
        private readonly API _api;

        public LoginFucker(API api)
        {
            _api = api;
            api.onPlayerConnected += OnPlayerConnected;
        }

        private void OnPlayerConnected(Client sender)
        {
            _api.sendChatMessageToPlayer(sender, "Do ~b~/fl~w~ for fake login..");
        }


        [PlayerCommand("/fakeLogin", new[] {"/fl"})]
        public void TestCommand(Client sender)
        {
            _api.setEntityInvincible(sender, false);
            _api.freezePlayer(sender, false);
            _api.setEntityTransparency(sender, 255);
            _api.setEntityCollisionless(sender, false);
            _api.sendChatMessageToPlayer(sender, "~o~Ping. ~g~Pong. ~o~Wuusch!");
        }
    }
}
