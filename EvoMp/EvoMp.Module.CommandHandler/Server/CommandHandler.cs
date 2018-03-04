using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Core.Shared.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.CommandHandler.Server
{
    public class CommandHandler : BaseModule, ICommandHandler
    {
        internal readonly IMessageHandler MessageHandler;

        public CommandHandler(API api, IMessageHandler messageHandler)
        {
            MessageHandler = messageHandler;
            // Inspect each module for commands on load
            SharedEvents.OnModuleLoaded += SharedOnModuleLoaded;

            // api events for ingame command execute
            api.onChatMessage += ApiOnOnChatMessage;
            api.onChatCommand += ApiOnOnChatCommand;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Returns the ICommand for the given command string
        /// </summary>
        /// <param name="commandString">The complete command string</param>
        /// <returns>ICommand or Null</returns>
        public ICommand GetCommand(string commandString)
        {
            List<string> commandStringParts = commandString.Split(' ').ToList();

            foreach (ICommand command in CommandParser.Commands)
                // command string not command -> continue;
                if (command.Command.ToLower() == commandStringParts[0].ToLower()
                    || command.CommandAliases.Select(ca => ca.ToLower())
                        .Contains(commandStringParts[0].ToLower()))
                    return command;

            return null;
        }

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
        public bool EvalCommand(Client sender, string commandString)
        {
            List<string> commandStringParts = commandString.Split(' ').ToList();

            ICommand command = GetCommand(commandString);

            // No command found -> console output & return false;
            if (command == null)
            {
                // CommandString starts with possible command indicator -> write console message
                if (CommandParser.Commands.Any(command1 => command1.Command.StartsWith(commandString[0].ToString())
                                                           || command1.CommandAliases.Any(commandAlias =>
                                                               commandAlias.StartsWith(commandString[0].ToString()))))
                    ConsoleOutput.WriteLine(ConsoleType.Command,
                        $"~r~Unknown command~w~ - ~b~{sender.name} ~;~-> ~o~{commandString}~c~");

                return false;
            }

            // Failed PlayerCommand specifys -> return true;
            if (command is PlayerCommand playerCommand)
                if (!CheckPlayerCommand(sender, playerCommand))
                    return true;

            // Remove command
            string enteredCommand = commandStringParts[0];
            commandStringParts.Remove(enteredCommand);

            // Check for parameters
            List<object> parameterValues = new List<object>();
            ParameterInfo[] commandParameters = command.MethodInfo.GetParameters();

            string currentParameterString = string.Empty;
            parameterValues.Add(sender);
            for (int i = 1; i < commandParameters.Length; i++)
            {
                // No more string parameters -> break;
                if (commandStringParts.FirstOrDefault() == null)
                    break;

                // append or set string parameters
                currentParameterString += commandStringParts.FirstOrDefault();
                commandStringParts.Remove(currentParameterString);

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
                    // Barse boolean parameter for Convert functions
                    if (commandParameters[i].ParameterType == typeof(bool))
                        if (currentParameterString == "1")
                            currentParameterString = "true";
                        else if (currentParameterString == "0")
                            currentParameterString = "false";


                    object parameterValue =
                        Convert.ChangeType(currentParameterString, commandParameters[i].ParameterType);
                    currentParameterString = string.Empty;

                    if (parameterValue == null)
                        break;

                    parameterValues.Add(parameterValue);
                }
                catch (InvalidCastException)
                {
                    MessageHandler.PlayerMessage(sender,
                        $"The type ~w~{commandParameters[i].ParameterType}~;~ can't be used as command parameter!");
                    return true;
                }
                catch
                {
                    MessageHandler.PlayerMessage(sender,
                        $"Invalid type given for parameter {commandParameters[i].Name}.");
                    return true;
                }
            }

            // Not enough parameter values -> message & next;
            if (commandParameters.Count(info => !info.IsOptional) > parameterValues.Count)
            {
                MessageHandler.PlayerMessage(sender,
                    $"Incorrect parameter values for the command ~o~{enteredCommand}~;~. " +
                    $"Type ~b~\"/help {enteredCommand}\"~;~ for more information.");
                return true;
            }

            // Add optional parameters if not given, to parametersValues 
            if (commandParameters.Length != parameterValues.Count)
                for (int i = commandParameters.Length - parameterValues.Count; i < commandParameters.Length; i++)
                    parameterValues.Add(commandParameters[i].DefaultValue);

            // Invoke command
            command.MethodInfo.Invoke(command.ClassInstance, parameterValues.ToArray());

            ConsoleOutput.WriteLine(ConsoleType.Command,
                $"~b~{sender.name} ~;~-> ~o~{command.Command}~;~. ~c~(~w~{commandString}~c~)");
            return true;
        }

        /// <summary>
        ///     Called on module loaded
        /// </summary>
        /// <param name="moduleInstance">The module instance</param>
        private static void SharedOnModuleLoaded(object moduleInstance)
        {
            CommandParser.InspectModule(moduleInstance);
        }

        /// <summary>
        ///     Called on API.OnChatCommand.
        ///     Setting cancel.Cancel on true. To catch all other events.
        /// </summary>
        /// <param name="sender">The player</param>
        /// <param name="command">The chat message</param>
        /// <param name="cancel">The cancel event</param>
        private void ApiOnOnChatCommand(Client sender, string command, CancelEventArgs cancel)
        {
            cancel.Cancel = true;
            if (!EvalCommand(sender, command))
                MessageHandler.PlayerMessage(sender, $"Comand ~o~{command.Split(' ')[0]}~w~ not found.",
                    MessageType.Error);
        }

        /// <summary>
        ///     Called on API.OnChatMessage.
        ///     Would be cancel.Cancel = true, if message is a given command.
        /// </summary>
        /// <param name="sender">The player</param>
        /// <param name="message">The chat message</param>
        /// <param name="cancel">The cancel event</param>
        private void ApiOnOnChatMessage(Client sender, string message, CancelEventArgs cancel)
        {
            // Message is a command -> Set cancel
            cancel.Cancel = EvalCommand(sender, message);
        }

        /// <summary>
        ///     Checks command properties for a player command attribute
        /// </summary>
        /// <param name="sender">The Player to check</param>
        /// <param name="playerCommand">The player command wich should be checked.</param>
        /// <returns>bool</returns>
        private bool CheckPlayerCommand(Client sender, ICommand playerCommand)
        {
            switch (playerCommand.PlayerOnlyState)
            {
                case PlayerOnlyState.Any:
                {
                    break;
                }
                case PlayerOnlyState.OnlyOnFoot:
                {
                    if (!sender.isInVehicle && !sender.isParachuting)
                        break;

                    MessageHandler.PlayerMessage(sender, "You're not going on foot!", MessageType.Error);
                    return false;
                }
                case PlayerOnlyState.OnlyInVehicle:
                {
                    if (sender.isInVehicle)
                        break;
                    MessageHandler.PlayerMessage(sender, "You're not in any vehicle!", MessageType.Error);
                    return false;
                }
                case PlayerOnlyState.OnlyAsDriver:
                {
                    if (sender.isInVehicle && sender.vehicleSeat == -1)
                        break;

                    MessageHandler.PlayerMessage(sender, "You're not the vehicle driver!", MessageType.Error);
                    return false;
                }
                default:
                    return true;
            }

            return true;
        }
    }
}
