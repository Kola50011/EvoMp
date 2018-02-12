using EvoMp.Core.Module.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;

namespace EvoMp.Module.CommandHandler.Server
{
    [ModuleProperties("shared", "Ruffo", "Handles the complete command usage.")]
    public interface ICommandHandler
    {
        ICommand GetCommand(string command);
    }
}
