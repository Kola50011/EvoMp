using EvoMp.Module.EventHandler;
using EvoMp.Module.Logger;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.TestModule
{
  public class TestModule : ITestModule
  {
    public TestModule(API api, IEventHandler eventHandler, ILogger logger)
    {
    }
  }
}
