using System;
using System.Linq;
using EvoMp.Module.CommandHandler;
using EvoMp.Module.CommandHandler.Server.Attributes;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.TestModule.Debuging
{
    public class LoginFucker
    {
        private readonly API _api;
        private readonly ICommandHandler _commandHandler;

        public LoginFucker(API api, ICommandHandler commandHandler)
        {
            _api = api;
            _commandHandler = commandHandler;
            api.onPlayerConnected += OnPlayerConnected;
        }

        private void OnPlayerConnected(Client sender)
        {
            _api.sendChatMessageToPlayer(sender, "Do ~b~/fl~w~ for fake login..");
        }


        [PlayerCommand("/fakeLogin", new[] {"/fl"})]
        public void TestCommand(Client sender)
        {
            _api.setEntityInvincible(sender, false);
            _api.freezePlayer(sender, false);
            _api.setEntityTransparency(sender, 255);
            _api.setEntityCollisionless(sender, false);
            _api.sendChatMessageToPlayer(sender, "Ping. Pong. Wuusch!");
        }

        [PlayerCommand("/help")]
        public void ViewHelpInformations(Client sender, string commandName)
        {
            ICommand command = _commandHandler.GetCommand(commandName);

            // Not command found -> message & return.
            if (command == null)
            {
                _api.sendChatMessageToPlayer(sender,
                    $"No console command found for ~w~{commandName}~;~.");
                return;
            }

            // Show command help
            string commandParameter = string.Join(", ", command.MethodInfo.GetParameters().Select(info =>
                $"~m~{info.ParameterType}~;~ {info.Name} " +
                $"~l~{(info.IsOptional ? $" = [{info.DefaultValue}] " : "")}~;~"));

            _api.sendChatMessageToPlayer(sender,
                $"Command: ~w~{command.Command}~;~\n" +
                $"Aliase: ~w~{string.Join(", ", command.CommandAliases)}\n" +
                $"Usage: ~w~{command.Command} {commandParameter}");
        }
    }
}
