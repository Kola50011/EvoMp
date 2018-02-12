using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;

namespace EvoMp.Module.CommandHandler.Server
{
    /// <summary>
    ///     Contains functions for parsing and inspection
    /// </summary>
    public class CommandParser
    {
        internal static readonly List<ICommand> Commands = new List<ICommand>();
        private static bool _commandUsageSend;

        /// <summary>
        ///     Adding new command to the existings commands.
        ///     Checks all command attributes, to get no duplicates.
        /// </summary>
        /// <param name="newCommand">The new command</param>
        /// <returns>true if new command is unique, else false (with console message)</returns>
        internal static bool AddToCommands(ICommand newCommand)
        {
            bool returnValue = true;
            string oldPrefix = ConsoleOutput.GetPrefix();
            ConsoleOutput.SetPrefix(oldPrefix.Replace("> ", "\t"));
            try
            {
                // Already used command string -> message
                ICommand blockingCommand = Commands.FirstOrDefault(cmd =>
                    cmd.Command.ToLower() == newCommand.Command.ToLower());

                if (blockingCommand != null)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Warn,
                        $"Command duplicate: ~c~{blockingCommand.FullName()}");
                    returnValue = false;
                }

                // Already used alias command string -> message
                blockingCommand = Commands.FirstOrDefault(cmd => cmd.CommandAliases.Contains(newCommand.Command) ||
                                                                 cmd.CommandAliases.Any(sa => newCommand.CommandAliases
                                                                     .Select(s => s.ToLower()).Contains(sa)));
                if (blockingCommand != null)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Warn,
                        $"Alias duplicate: ~c~{blockingCommand.FullName()}");
                    returnValue = false;
                }

                Commands.Add(newCommand);
                return returnValue;
            }
            finally
            {
                ConsoleOutput.SetPrefix(oldPrefix);
            }
        }

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
            foreach (ICommand command in Commands)
                if (commandStr.ToLower() == command.Command.ToLower() ||
                    command.CommandAliases.Contains(commandStr.ToLower()))
                    return command;

            return null;
        }

        /// <summary>
        ///     Inspects a class for Commands.
        /// </summary>
        /// <param name="moduleInstance">The instance of the module wich should be inspected.</param>
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

            // Parse static commands 
            ParseStaticCommands();

            // Check for invalid commands & write message if given
            ParseInvalidCommands();
            if (invalidCommands.Any())
            {
                if (!_commandUsageSend)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Warn,
                        "Command methods were found which could not be loaded correctly. " +
                        "~w~~_~Any~;~ command method ~w~~_~must be public~;~. " +
                        "In addition, the class where those methods are located " +
                        "~w~~_~must be instanced as a public field or property~;~.\n" +
                        "Except: ~w~~_~Static command functions - can be public only~;~.\n" +
                        "See ~r~!~;~ for affected commands.");
                    _commandUsageSend = true;
                }

                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "~r~!"));

                foreach (ICommand invalidCommand in invalidCommands)
                    ConsoleOutput.WriteLine(ConsoleType.Command,
                        "~r~" + invalidCommand.Command + "~c~ " + invalidCommand.FullName());

                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace("~r~!", ">"));
            }

            // Register commands
            if (validCommands.Any())
                foreach (ICommand command in validCommands)
                {
                    if (AddToCommands(command))
                    {
                        ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "~g~+"));
                        ConsoleOutput.WriteLine(ConsoleType.Command,
                            "~g~" + command.Command + "~c~ " + command.FullName());
                    }
                    else
                    {
                        ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "~o~?"));
                        ConsoleOutput.WriteLine(ConsoleType.Command,
                            "~o~" + command.Command + "~c~ " + command.FullName());
                    }

                    ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace("~g~+", ">").Replace("~o~?", ">"));
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

                        ICommand command = (ICommand) commandObject;

                        // Save MethodInfo and Class instance
                        command.MethodInfo = methodInfo;
                        invalidCommands.Add(command);
                    }
                }
            }

            void ParseStaticCommands()
            {
                foreach (Type type in moduleInstance.GetType().Assembly.GetTypes())
                foreach (MethodInfo methodInfo in type.GetMethods()
                    .Where(info => info.IsStatic && info.IsPublic && !info.IsConstructor))
                {
                    object[] attributes = methodInfo.GetCustomAttributes(typeof(ICommand), true);

                    if (attributes.Length <= 0)
                        continue;

                    foreach (object commandObject in attributes)
                    {
                        ICommand command = (ICommand) commandObject;

                        // Save MethodInfo and Class instance
                        command.MethodInfo = methodInfo;
                        command.ClassInstance = null;
                        validCommands.Add(command);
                    }
                }
            }

            void ParseCommands(object instance)
            {
                foreach (MethodInfo methodInfo in instance.GetType().GetMethods()
                    .Where(info => !info.IsStatic && info.IsPublic && !info.IsConstructor))
                {
                    object[] attributes = methodInfo.GetCustomAttributes(typeof(ICommand), true);

                    if (attributes.Length <= 0)
                        continue;

                    foreach (object commandObject in attributes)
                    {
                        ICommand command = (ICommand) commandObject;

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
