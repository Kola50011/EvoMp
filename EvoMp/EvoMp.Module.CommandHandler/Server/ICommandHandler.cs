using EvoMp.Core.Module.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.CommandHandler.Server
{
    [ModuleProperties("shared", "Ruffo", "Handles the complete command usage.", 0)]
    public interface ICommandHandler
    {
        /// <summary>
        /// Returns the ICommand for the given command string
        /// </summary>
        /// <param name="command">The complete command string</param>
        /// <returns>ICommand or Null</returns>
        ICommand GetCommand(string command);

        /// <summary>
        ///     Runs the command from the command string for the sender
        ///     <para>
        ///         Sends automatic fail message to the player if parameters missing
        ///         or other conditions not correct.
        ///     </para>
        /// </summary>
        /// <param name="sender">The player who run the command</param>
        /// <param name="commandString">The full command string</param>
        /// <returns>False if command not found. Else true.</returns>
        bool EvalCommand(Client sender, string commandString);
    }
}
