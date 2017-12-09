using System.Linq;

namespace EvoMp.Core.ConsoleHandler
{
    public class Commands
    {
        [ConsoleCommand("/help", new[] {"-h", "--help"})]
        public static void ViewHelpInformations(string commandName)
        {
            ConsoleCommand command = ConsoleCommandHandler.GetConsoleCommand(commandName);

            // Not command found -> message & return.
            if (command == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Help,
                    $"No console command found for ~w~{commandName}~;~.");
                return;
            }

            // Show command help
            string commandParameter = string.Join(", ", command.MethodInfo.GetParameters()
                .Select(info => $"~m~{info.ParameterType}~;~ {info.Name} " +
                                $"~l~{(info.IsOptional ? $" = [{info.DefaultValue}] " : "")}~;~"));

            ConsoleOutput.WriteLine(ConsoleType.Help,
                $"Command: ~w~{command.Command}~;~\n" +
                $"Aliase: ~w~{string.Join(", ", command.CommandAliases)}\n" +
                $"Usage: ~w~{command.Command} {commandParameter}");
        }


        [ConsoleCommand("/fullscreen", new[] {"-f",}, "Toggles the fullscreen mode für the GTMP console")]
        public static void Fullscreen(bool fullscreen, int display)
        {
            // Fullscreen disabled -> Save, message & return;
            if (!fullscreen)
            {
                ConsoleOutput.WriteLine(ConsoleType.Config, "Disabled fullscreen mode. Changes take effect on next Start.");

            }

        }
    }
}