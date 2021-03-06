using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EvoMp.Core.ConsoleHandler.Properties;
using GrandTheftMultiplayer.Server.API;
#if !__MonoCS__
using System.Drawing;

#endif

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

#if !__MonoCS__
            // No display given -> Use current & message
            if (display == -1)
            {
                Point p = new Point();
                ConsoleUtils.GetWindowRect(ConsoleUtils.GetConsoleWindow(), ref p);
                display = Screen.AllScreens.ToList()
                    .FindIndex(screen => Equals(screen, Screen.FromPoint(new Point(p.X, p.Y))));
                ConsoleOutput.WriteLine(ConsoleType.Info,
                    $"No display given for fullscreen. Using the current display ~b~{display}~;~.");
            }
#endif

            // invalid display given -> Warning & return;
            if (Screen.AllScreens.Length - 1 < display)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    $"Invalid display ~o~{display}~;~. Available displays: 0 - {Screen.AllScreens.Length - 1}");
                return;
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
            //TODO: Linux support
#if __MonoCS__
            ConsoleOutput.WriteLine(ConsoleType.Debug, "Currently only supported on Windows. See #23");
#else
            Point hWndLocation = Settings.Default.ConsoleLocation;
            ConsoleUtils.GetWindowRect(ConsoleUtils.GetConsoleWindow(), ref hWndLocation);
            Settings.Default.ConsoleLocation = hWndLocation;
            Settings.Default.Save();
            ConsoleOutput.WriteLine(ConsoleType.Config,
                $"Saved the current console positon at {Settings.Default.ConsoleLocation}");
#endif
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

        [ConsoleCommand("/exit", new[] {"-e", "exit"},
            "Closes the Console", true)]
        public static void CloseConsole()
        {
            ConsoleOutput.WriteLine(ConsoleType.Core, "Shutting down!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }


        [ConsoleCommand("/say", new[] {"!", "."}, "Announces console input to every connected player.")]
        public static void SayToConsole(string message)
        {
            string outMessage = $"~w~[~r~SERVER~w~]~w~: ~r~{message}";
            API.shared.sendChatMessageToAll(outMessage);
            ConsoleOutput.WriteLine(ConsoleType.Core, outMessage);
        }
    }
}
