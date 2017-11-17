using System.Collections.Generic;
using EvoMp.Module.CommandHandler.Attributes;

namespace EvoMp.Module.CommandHandler
{
    public class CommandManager
    {
        private static readonly List<ICommand> Commands = new List<ICommand>();

        /// <summary>
        /// Adding new command to the existings commands.
        /// Checks all command attributes, to get no duplicates.
        /// </summary>
        /// <param name="command">The new command</param>
        /// <returns>true if new command is unique, else false (with console message)</returns>
        internal static bool AddToCommands(ICommand command)
        {
            //TODO: Compare each existing command, to get no duplicates
            Commands.Add(command);
            return true;
        }

        /// <summary>
        /// Returns all registered commands.
        /// </summary>
        /// <returns>All registered commands</returns>
        public static List<ICommand> GetCommands()
        {
            return Commands;
        }
    }
}