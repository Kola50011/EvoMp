using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Core.Module;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Ninject;
using Ninject.Modules;

namespace EvoMp.Module.CommandHandler
{
    public class CommandHandler : ICommandHandler
    {
        public CommandHandler(API api)
        {
            // Bind event
            api.onChatMessage += ApiOnOnChatMessage;
            api.onChatCommand += ApiOnOnChatCommand;
            Shared.OnAssemblyLoaded += SharedOnOnModuleLoaded;
        }

        /// <summary>
        /// Called on module loaded
        /// </summary>
        /// <param name="loadedClasses"></param>
        private void SharedOnOnModuleLoaded(Type[] loadedClasses)
        {
            foreach (Type type in loadedClasses)
                CommandParsing.Inspect(type);
        }

        /// <summary>
        /// Called on API.OnChatCommand.
        /// Setting cancel.Cancel on true. To catch all other events.
        /// </summary>
        /// <param name="sender">The player</param>
        /// <param name="command">The chat message</param>
        /// <param name="cancel">The cancel event</param>
        private void ApiOnOnChatCommand(Client sender, string command, CancelEventArgs cancel)
        {
            cancel.Cancel = true;
        }

        /// <summary>
        /// Called on API.OnChatMessage.
        /// Would be cancel.Cancel = true, if message is a given command.
        /// </summary>
        /// <param name="sender">The player</param>
        /// <param name="message">The chat message</param>
        /// <param name="cancel">The cancel event</param>
        private void ApiOnOnChatMessage(Client sender, string message, CancelEventArgs cancel)
        {
            // Message is not a command -> return;
            if (!CommandParsing.IsCommand(message))
                return;
            
            // Message is a command -> Set cancel
            cancel.Cancel = true;
        }
    }
}
