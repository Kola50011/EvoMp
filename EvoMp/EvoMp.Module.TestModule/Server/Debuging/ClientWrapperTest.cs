using EvoMp.Module.ClientWrapper.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class ClientWrapperTest
    {
        private readonly IClientWrapper _clientWrapper;

        public ClientWrapperTest(IClientWrapper clientWrapper)
        {
            _clientWrapper = clientWrapper;
        }

        [PlayerCommand("/setTime")]
        public void TestSetTime(Client sender, int hours, int minutes)
        {
            _clientWrapper.Setter.SetTime(sender, hours, minutes);
        }
    }
}
