using System;
using System.Collections.Generic;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Core.Module;
using EvoMp.Module.CommandHandler.Attributes;
using EvoMp.Module.MessageHandler;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.CommandHandler
{
    public class CommandHandler : ICommandHandler
    {
        public static readonly List<ICommand> Commands = new List<ICommand>();
        private readonly IMessageHandler _messageHandler;

        public CommandHandler(API api, IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
            // Inspect each module for commands on load
            Shared.OnModuleLoaded += SharedOnModuleLoaded;

            // api events for ingame command execute
            api.onChatMessage += ApiOnOnChatMessage;
            api.onChatCommand += ApiOnOnChatCommand;
        }

        /// <summary>
        ///     Adding new command to the existings commands.
        ///     Checks all command attributes, to get no duplicates.
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
        ///     Called on module loaded
        /// </summary>
        /// <param name="moduleInstance">The module instance</param>
        private void SharedOnModuleLoaded(object moduleInstance)
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
            EvalCommand(sender, command);
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
            // Message is not a command -> return;
            if (CommandParser.GetCommand(message) == null)
                return;

            // Message is a command -> Set cancel
            cancel.Cancel = true;

            // Eval command
            EvalCommand(sender, message);
        }

        public bool EvalCommand(Client sender, string message)
        {
            ICommand command = CommandParser.GetCommand(message);
            // Message is not a command -> message & return;
            if (command == null)
            {
                _messageHandler.PlayerMessage(sender, $"Invalid command ~o~\"{message}\"~;~!");
                return false;
            }

            //TODO: Add parameter parsing
            List<object> methodParams = new List<object> {sender};
            try
            {
                command.MethodInfo.Invoke(command.ClassInstance, methodParams.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            ConsoleOutput.WriteLine(ConsoleType.Command,
                $"~b~{sender.name} ~;~-> ~o~{command.Command}~;~.");

            return true;
        }
    }
}