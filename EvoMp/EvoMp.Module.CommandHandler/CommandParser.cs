using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Module.CommandHandler.Attributes;

namespace EvoMp.Module.CommandHandler
{
    /// <summary>
    ///     Contains functions for parsing and inspection
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        ///     Gives the correct command for the given message.
        ///     Or null, if the message is no command
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
        ///     Inspects a class for Commands.
        /// </summary>
        /// <param name="moduleInstance"></param>
        internal static void InspectModule(object moduleInstance)
        {
            List<ICommand> validCommands = new List<ICommand>();
            List<ICommand> invalidCommands = new List<ICommand>();

            // Parse commands direct in module
            ParseCommands(moduleInstance);

            // Parse all field & Property infos
            foreach (FieldInfo fieldInfo in moduleInstance.GetType().GetFields())
                ParseMemberInfo(null, fieldInfo, moduleInstance);

            foreach (PropertyInfo propertyInfo in moduleInstance.GetType().GetProperties())
                ParseMemberInfo(propertyInfo, null, moduleInstance);

            // Check for invalid commands & write message if given
            ParseInvalidCommands();
            if (invalidCommands.Any())
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    "Command methods were found which could not be loaded correctly. " +
                    "Command methods ~w~~_~must be public~;~. " +
                    "In addition, the class where those methods are located " +
                    "~w~~_~must be instanced as a public field or property on module loading~;~." +
                    "\n\n" +
                    "The following methods were not loaded:");

                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "!"));
                foreach (ICommand invalidCommand in invalidCommands)
                    ConsoleOutput.WriteLine(ConsoleType.Warn,
                        $"{invalidCommand.Command} - ~c~{invalidCommand.MethodInfo.DeclaringType?.FullName}");
                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace("!", ">"));
            }

            // Register commands
            if (validCommands.Any())
            {
                //ConsoleOutput.WriteLine(ConsoleType.Command, $"Registered commands:");
                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "+"));
                foreach (ICommand command in validCommands)
                    if (CommandHandler.AddToCommands(command))
                        ConsoleOutput.WriteLine(ConsoleType.Command,
                            $"{command.Command}~;~ ~c~{command.MethodInfo.DeclaringType?.FullName}");
                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace("+", ">"));
            }

            void ParseInvalidCommands()
            {
                foreach (Type type in moduleInstance.GetType().Assembly.GetTypes())
                    foreach (MethodInfo methodInfo in type.GetMethods())
                    {
                        object[] attributes = methodInfo.GetCustomAttributes(typeof(ICommand), true);

                        if (attributes.Length <= 0)
                            continue;

                        foreach (object commandObject in attributes)
                        {
                            // Method is registered as valid -> next.
                            if (validCommands.Any(cmd => cmd.MethodInfo == methodInfo))
                                continue;

                            ICommand command = (ICommand)commandObject;

                            // Save MethodInfo and Class instance
                            command.MethodInfo = methodInfo;
                            invalidCommands.Add(command);
                        }
                    }
            }

            void ParseCommands(object instance)
            {
                foreach (MethodInfo methodInfo in instance.GetType().GetMethods())
                {
                    if(!methodInfo.IsPublic) continue;
                    if(methodInfo.IsConstructor) continue;

                    object[] attributes = methodInfo.GetCustomAttributes(typeof(ICommand), true);
                    if (attributes.Length > 0)
                        foreach (object commandObject in attributes)
                        {
                            ICommand command = (ICommand)commandObject;

                            // Save MethodInfo and Class instance
                            command.MethodInfo = methodInfo;
                            command.ClassInstance = instance;
                            validCommands.Add(command);
                        }
                }
            }

            void ParseMemberInfo(PropertyInfo propertyInfo, FieldInfo fieldInfo, object classInstance)
            {
                object instance = propertyInfo?.GetValue(classInstance) ?? fieldInfo?.GetValue(classInstance);

                if (instance == null || 
                    instance.GetType().Assembly != moduleInstance.GetType().Assembly || !instance.GetType().IsClass)
                    return;

                // Search for commands
                ParseCommands(instance);
                foreach (FieldInfo field in instance.GetType().GetFields())
                    ParseMemberInfo(null, field, instance);

                foreach (PropertyInfo property in instance.GetType().GetProperties())
                    ParseMemberInfo(property, null, instance);

            }
        }
    }
}