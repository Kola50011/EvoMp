using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Module.CommandHandler.Attributes;

namespace EvoMp.Module.CommandHandler
{
    /// <summary>
    /// Contains functions for parsing and inspection
    /// </summary>
    public class CommandParse
    {
        /// <summary>
        /// Gives the correct command for the given message.
        /// Or null, if the message is no command
        /// </summary>
        /// <param name="message">The message wich should be checked</param>
        /// <returns>ICommand or null</returns>
        public static ICommand GetCommand(string message)
        {
            string commandStr = message;
            if (commandStr.Contains(" ")) commandStr = commandStr.Split(' ')[0];
            foreach (ICommand command in CommandHandler.Commands)
                if (commandStr.ToLower() == command.Command.ToLower() ||
                    command.CommandAliases.Contains(commandStr.ToLower()))
                    return command;

            return null;
        }

        /// <summary>
        /// Inspects a class for Commands.
        /// </summary>
        /// <param name="commandClass">The class wich should be inspected</param>
        /// <param name="moduleInstance"></param>
        public static void Inspect(Type commandClass, object moduleInstance)
        {
            //Search for all Methods in this commandClass
            IEnumerable<MethodInfo> methodInfos = commandClass.GetMethods();
            foreach (MethodInfo methodInfo in methodInfos)
            {
                object[] attributes = methodInfo.GetCustomAttributes(typeof(ICommand), true);
                if (attributes.Length > 0)
                {
                    ICommand playerCommand = (ICommand)attributes[0];
                    playerCommand.MethodInfo = methodInfo;
                    playerCommand.ClassInstance = moduleInstance;

                    //TODO: Passe ausgabe noch besser an
                    if (CommandHandler.AddToCommands(playerCommand))
                        ConsoleOutput.WriteLine(ConsoleType.Command, 
                            $"Registered command ~#a485f5~{playerCommand.Command}~;~.");
                }
            }
        }
    }
}
