
using System.Reflection;

namespace EvoMp.Module.CommandHandler.Attributes
{
    public interface ICommand
    {
        string Command { get; }

        string[] CommandAliases { get;}

        PlayerOnlyState PlayerOnlyState { get; }
        MethodInfo MethodInfo { get; set; }
    }
}
