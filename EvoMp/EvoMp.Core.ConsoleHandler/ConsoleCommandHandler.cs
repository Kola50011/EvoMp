using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using EvoMp.Core.Module;

namespace EvoMp.Core.ConsoleHandler
{
    internal class ConsoleCommandHandler
    {
        private static readonly List<ConsoleCommand> Commands = new List<ConsoleCommand>();

        /// <summary>
        ///     Prepares the console comand routine.
        ///     Binding events.. etc.
        /// </summary>
        public static void PrepareConsoleCommands()
        {
            Shared.OnModuleLoaded += InspectModule;
            ConsoleInput.OnConsoleString += ParseConsoleString;
        }

        /// <summary>
        /// Returns the ConsoleCommand object for the given commandString.
        /// Returns null if no ConsoleCommand found.
        /// </summary>
        /// <param name="commandString">ConsoleCommand command string</param>
        /// <returns>ConsoleCommand or null</returns>
        internal static ConsoleCommand GetConsoleCommand(string commandString)

        {
            return Commands.FirstOrDefault(command => command.Command.ToLower() == commandString.ToLower()
                                                      || command.CommandAliases.Select(ca => ca.ToLower())
                                                          .Contains(commandString.ToLower()));
        }

        private static void ParseConsoleString(string consoleString, CancelEventArgs cancelEventArgs)
        {
            List<string> consoleStringParts = consoleString.Split(' ').ToList();

            foreach (ConsoleCommand command in Commands)
            {
                // console string not command -> continue;
                if (command.Command.ToLower() != consoleStringParts[0].ToLower()
                    && !command.CommandAliases.Select(ca => ca.ToLower())
                        .Contains(consoleStringParts[0].ToLower()))
                    continue;

                // Cancle event
                cancelEventArgs.Cancel = true;

                // Remove command
                string enteredCommand = consoleStringParts[0];
                consoleStringParts.Remove(enteredCommand);

                // Check for parameters
                List<object> parameterValues = new List<object>();
                ParameterInfo[] commandParameters = command.MethodInfo.GetParameters();

                string currentParameterString = String.Empty;
                for (int i = 0; i < commandParameters.Length; i++)
                {
                    // No more string parameters -> break;
                    if (consoleStringParts.FirstOrDefault() == null)
                        break;

                    // append or set string parameters
                    currentParameterString += consoleStringParts.FirstOrDefault();
                    consoleStringParts.Remove(currentParameterString);

                    // String argument with quote -> wait for end quote.
                    if (currentParameterString.StartsWith("\""))
                    {
                        if (!currentParameterString.EndsWith("\""))
                        {
                            i--;
                            continue;
                        }

                        // Remove quotes
                        currentParameterString = currentParameterString
                            .Remove(currentParameterString.Length - 1, 1)
                            .Remove(0, 1);
                    }

                    // Try parse & reset string
                    try
                    {
                        object parameterValue =
                            Convert.ChangeType(currentParameterString, commandParameters[i].ParameterType);
                        currentParameterString = String.Empty;

                        if (parameterValue == null)
                            break;

                        parameterValues.Add(parameterValue);
                    }
                    catch (InvalidCastException)
                    {
                        ConsoleOutput.WriteLine(ConsoleType.Error,
                            $"The type ~w~{commandParameters[i].ParameterType}~;~ can't be used as command parameter!");
                        return;
                    }
                }

                // Not enough parameter values -> message & next;
                if (commandParameters.Count(info => !info.IsOptional) != parameterValues.Count)
                {
                    ConsoleOutput.WriteLine(ConsoleType.ConsoleCommand,
                        $"Incorrect parameter values for the command ~o~{enteredCommand}~;~. " +
                        $"Type ~b~\"/help {enteredCommand}\"~;~ for more information.");
                    return;
                }

                //TODO: check for optional parameters needed

                // Invoke command
                command.MethodInfo.Invoke(command.ClassInstance, parameterValues.ToArray());
                return;
            }
        }


        /// <summary>
        ///     Adding new command to the existings commands.
        ///     Checks all command attributes, and give warns on duplicates.
        /// </summary>
        /// <param name="newCommand">The new command</param>
        /// <returns>true if new command is unique, else false (with console message)</returns>
        internal static bool AddToCommands(ConsoleCommand newCommand)
        {
            bool returnValue = true;
            string oldPrefix = ConsoleOutput.GetPrefix();
            ConsoleOutput.SetPrefix(oldPrefix.Replace("> ", "\t"));
            try
            {
                // Already used command string -> message
                ConsoleCommand blockingCommand = Commands.FirstOrDefault(cmd =>
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
        ///     Inspects a class for Commands.
        /// </summary>
        /// <param name="moduleInstance">The instance of the module wich should be inspected.</param>
        internal static void InspectModule(object moduleInstance)
        {
            List<ConsoleCommand> validCommands = new List<ConsoleCommand>();
            List<ConsoleCommand> invalidCommands = new List<ConsoleCommand>();

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
                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "~r~!"));

                foreach (ConsoleCommand invalidCommand in invalidCommands)
                    ConsoleOutput.WriteLine(ConsoleType.ConsoleCommand,
                        "~r~" + invalidCommand.Command + "~c~ " + invalidCommand.FullName());

                ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace("~r~!", ">"));
            }

            // Register commands
            if (validCommands.Any())
                foreach (ConsoleCommand command in validCommands)
                {
                    if (AddToCommands(command))
                    {
                        ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "~g~+"));
                        ConsoleOutput.WriteLine(ConsoleType.ConsoleCommand,
                            "~g~" + command.Command + "~c~ " + command.FullName());
                    }
                    else
                    {
                        ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace(">", "~o~?"));
                        ConsoleOutput.WriteLine(ConsoleType.ConsoleCommand,
                            "~o~" + command.Command + "~c~ " + command.FullName());
                    }

                    ConsoleOutput.SetPrefix(ConsoleOutput.GetPrefix().Replace("~g~+", ">").Replace("~o~?", ">"));
                }

            void ParseInvalidCommands()
            {
                foreach (Type type in moduleInstance.GetType().Assembly.GetTypes())
                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    object[] attributes = methodInfo.GetCustomAttributes(typeof(ConsoleCommand), true);

                    if (attributes.Length <= 0)
                        continue;

                    foreach (object commandObject in attributes)
                    {
                        // Method is registered as valid -> next.
                        if (validCommands.Any(cmd => cmd.MethodInfo == methodInfo))
                            continue;

                        ConsoleCommand command = (ConsoleCommand) commandObject;

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
                    object[] attributes = methodInfo.GetCustomAttributes(typeof(ConsoleCommand), true);

                    if (attributes.Length <= 0)
                        continue;

                    foreach (object commandObject in attributes)
                    {
                        ConsoleCommand command = (ConsoleCommand) commandObject;

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
                    object[] attributes = methodInfo.GetCustomAttributes(typeof(ConsoleCommand), true);

                    if (attributes.Length <= 0)
                        continue;

                    foreach (object commandObject in attributes)
                    {
                        ConsoleCommand command = (ConsoleCommand) commandObject;

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