using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EvoMp.Core.ConsoleHandler.Properties;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public class Commands
    {
        [ConsoleCommand("/help", new[] {"-h", "--help"}, "Shows information for any console command.")]
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


        [ConsoleCommand("/fullscreen", new[] {"-f"},
            "Toggles server fullscreen mode. ~n~" +
            "No display given: Primary display used.", true)]
        public static void Fullscreen(bool fullscreen, int display = -1)
        {
            // Fullscreen disabled -> Save, message & return;
            if (!fullscreen)
            {
                // Save settings
                Settings.Default.ConsoleFullscreenDisplay = -1;
                Settings.Default.ConsoleFullscreenMode = false;
                Settings.Default.Save();

                ConsoleOutput.WriteLine(ConsoleType.Config,
                    "Disabled fullscreen mode. ~b~Changes take effect on next Start.");
                return;
            }
            // invalid display given -> Warning & return;
            if (display < 0 || Screen.AllScreens.Length - 1 < display)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    $"Invalid display ~o~{display}~;~. Available displays: 0 - {Screen.AllScreens.Length - 1}");
                return;
            }

            // No display given -> select primary display & message
            if (display == -1)
            {
                display = Screen.AllScreens.ToList().FindIndex(screen => screen.Primary);
                ConsoleOutput.WriteLine(ConsoleType.Note,
                    $"No display given. Using display {display} (primary).");
            }

            // Save settings message
            Settings.Default.ConsoleFullscreenDisplay = display;
            Settings.Default.ConsoleFullscreenMode = true;
            Settings.Default.Save();
            ConsoleOutput.WriteLine(ConsoleType.Config,
                $"Enabled fullscreen mode for display ~b~{display}~;~.  " +
                $"~b~Changes take effect on next Start.");
        }

        [ConsoleCommand("/SaveConsolePos", new[] {"-scw"},
            "Save the console window position for future starts.~n~" +
            "~b~Fullscreen mode ignores saved positions.", true)]
        public static void SaveConsolePos()
        {
            Rectangle rect = new Rectangle();
            ConsoleUtils.GetWindowRect(ConsoleUtils.GetConsoleWindow(), ref rect);
            Settings.Default.ConsolePosition = new Point(rect.X, rect.Y);
            Settings.Default.Save();
            ConsoleOutput.WriteLine(ConsoleType.Config, "Saved the current console positon.");
        }

        [ConsoleCommand("/resetconsole", new[] {"-rc"},
            "Reset all console propertys. ~n~" +
            "~b~Changes take effect on next Start.", true)]
        public static void ResetConsoleSettings()
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            ConsoleOutput.WriteLine(ConsoleType.Config, "Console propertys reseted to default.");
        }
    }
}