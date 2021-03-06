using EvoMp.Core.Module.Server;

namespace EvoMp.Module.ClientWrapper.Server
{
    [ModuleProperties("shared", "Ruffo", "Client API server side wrapper.")]
    public interface IClientWrapper
    {
        ISetFunctions Setter { get; }
        IGetFunctions Getter { get; }
    }
}
