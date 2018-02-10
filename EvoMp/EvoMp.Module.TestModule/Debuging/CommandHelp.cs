using System.Linq;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Debuging
{
    public class CommandHelp
    {
        private readonly API _api;
        private readonly ICommandHandler _commandHandler;

        public CommandHelp(API api, ICommandHandler commandHandler)
        {
            _api = api;
            _commandHandler = commandHandler;
        }

        [PlayerCommand("/help")]
        public void ViewHelpInformations(Client sender, string commandName)
        {
            ICommand command = _commandHandler.GetCommand(commandName);

            // Not command found -> message & return.
            if (command == null)
            {
                _api.sendChatMessageToPlayer(sender,
                    $"No command found for ~w~{commandName}~;~.");
                return;
            }

            // Show command help
            string commandParameter = string.Join(", ", command.MethodInfo.GetParameters().Select(info =>
                $"~m~{info.ParameterType.Name}~;~ {info.Name} " +
                $"~l~{(info.IsOptional ? $" = [{info.DefaultValue}] " : "")}~;~"));

            _api.sendChatMessageToPlayer(sender,
                $"Command: ~w~{command.Command}~;~\n" +
                $"Aliase: ~w~{string.Join(", ", command.CommandAliases)}\n" +
                $"Usage: ~w~{command.Command} {commandParameter}");
        }
    }
}
