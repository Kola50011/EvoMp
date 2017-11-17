using System.Reflection;

namespace EvoMp.Module.CommandHandler.Attributes
{
    public interface ICommand
    {
        /// <summary>
        ///     The Command itself.
        /// </summary>
        string Command { get; set; }

        /// <summary>
        ///     Aliases for this command
        /// </summary>
        string[] CommandAliases { get; set; }

        /// <summary>
        ///     Player must only state for this command.
        ///     <see cref="PlayerOnlyState" />
        /// </summary>
        PlayerOnlyState PlayerOnlyState { get; }

        /// <summary>
        ///     Method information about the command method.
        /// </summary>
        MethodInfo MethodInfo { get; set; }

        /// <summary>
        ///     Instance of the command method, or null on static functions
        /// </summary>
        object ClassInstance { get; set; }

        string FullName();
    }
}