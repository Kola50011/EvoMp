using EvoMp.Module.EventHandler;
using EvoMp.Module.Logger;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.TestModule
{
  public class TestModule : ITestModule
  {
    public TestModule(API api, IEventHandler eventHandler, ILogger logger)
    {
      logger.Write("Console Message from TestModule", LogCase.Warn); //debug
    }

    public string ModuleName { get; } = "TestModule";
    public string ModuleDesc { get; } = "Model for testing purpose";
    public string ModuleAuth { get; } = "Ruffo, James";
  }
}
