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
    class CommandParsing
    {
        /// <summary>
        /// Checks if the given message is a command call
        /// </summary>
        /// <param name="message">The message wich should be checked</param>
        /// <returns>True if message is command call. Otherwise false</returns>
        public static bool IsCommand(string message)
        {
            foreach (ICommand command in CommandManager.GetCommands())
                if (message.ToLower().StartsWith(command.Command.ToLower()))
                    return true;

            return false;
        }

        /// <summary>
        /// Inspects a class for Commands.
        /// </summary>
        /// <param name="commandClass">The class wich should be inspected</param>
        public static void Inspect(Type commandClass)
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
                    
                    if(CommandManager.AddToCommands(playerCommand))
                        ConsoleOutput.WriteLine(ConsoleType.Command, 
                            $"Command ~#a485f5~{playerCommand.Command}~;~ added.");
                }
            }
        }
    }
}
