using System;
using System.Drawing;
using EvoMp.Core.Shared.Server;
#if !__MonoCS__
using System.Linq;
using System.Windows.Forms;
using EvoMp.Core.ConsoleHandler.Properties;

#endif

namespace EvoMp.Core.ConsoleHandler.Server
{
    public static class ConsoleHandler
    {
#if !__MonoCS__
        internal static IntPtr ConsoleHandle = ConsoleUtils.GetStdHandle(-11);
#endif

        /// <summary>
        ///     Change the Windows console mode to support ANSI color strings
        ///     Sets the console size & position
        /// </summary>
        public static void PrepareConsole()
        {
#if __MonoCS__
            WindowWidth = 150;
            WindowHeight = 50;
#else
            // 0x0004 = Modify Console for color codes ( Windows only)
            // 
            ConsoleUtils.GetConsoleMode(ConsoleHandle, out int currentMode);
            ConsoleUtils.SetConsoleMode(ConsoleHandle, currentMode | 0x0004);
#endif

            ModifyConsoleWindow();

            SharedEvents.OnCoreStartupCompleted += () =>
            {
#if !__MonoCS__
                ConsoleInput.PrepareConsoleInput();
#endif

                // Register Console commands. (In core not automaticly)
                ConsoleOutput.WriteLine(ConsoleType.ConsoleCommand, "ConsoleHandler commands.");
                ConsoleOutput.AppendPrefix("\t > ~;~");
                ConsoleCommandHandler.InspectModule(new Commands());
                ConsoleOutput.ResetPrefix();
            };

#if !__MonoCS__ // Debug
            // Catch CTRL + C
            Console.CancelKeyPress += (sender, args) =>
            {
                args.Cancel = true;
                ConsoleOutput.WriteLine(ConsoleType.Info,
                    "Please shutdown with ~b~exit~;~ console command.");
            };
#endif
        }

        /// <summary>
        ///     Modifys the console window propertys
        /// </summary>
        private static void ModifyConsoleWindow()
        {
            //TODO: Linux support
#if !__MonoCS__ // Setting screen or primary screen
            int height;
            int width;

            // Fullscreen
            if (Settings.Default.ConsoleFullscreenMode)
            {
                Screen screen = Screen.AllScreens.ElementAt(Settings.Default.ConsoleFullscreenDisplay);

                // Fullscreen screen connected -> restore fullscreen on screen
                if (screen != null)
                {
                    // Move to wanted display
                    ConsoleUtils.SetWindowPos(ConsoleUtils.GetConsoleWindow(), 0, screen.WorkingArea.Left, screen.WorkingArea.Top, Console.LargestWindowWidth, Console.LargestWindowHeight, 1);
                    ConsoleUtils.ToggleConsoleFullscreenMode();
                }
                // else -> write message after server startup
                else
                {
                    SharedEvents.OnAfterCoreStartupCompleted += () => ConsoleOutput.WriteLine(ConsoleType.Warn,
                        "Can restore fullscreen console window. Saved fullscreen screen isn't connected. Using default console settings.");
                }

                height = Console.WindowHeight;
                width = Console.WindowWidth;
            }
            // Normal console window
            else
            {
                Point savedPosition = Settings.Default.ConsoleLocation;
                Size ConsoleSize = Settings.Default.ConsoleSize;

                // Console position saved -> check if valid after screen changes || set position
                if (savedPosition.X != -1 && savedPosition.Y != -1)
                    // Saved on not connected screen -> message after server startup
                    if (!Screen.AllScreens.Any(screen => screen.Bounds.Contains(savedPosition)))
                    {
                        ConsoleUtils.SetWindowPos(ConsoleUtils.GetConsoleWindow(), 0, 0, 0,
                            ConsoleSize.Width, ConsoleSize.Height, 1);
                        SharedEvents.OnAfterCoreStartupCompleted += () => ConsoleOutput.WriteLine(ConsoleType.Warn,
                            "Can't restore saved console location. Saved location was on disconnected screen. Console use default location instead.");
                    }
                    // Valid saved position -> restore
                    else
                        ConsoleUtils.SetWindowPos(ConsoleUtils.GetConsoleWindow(), 0, Settings.Default.ConsoleLocation.X, Settings.Default.ConsoleLocation.Y,
                            ConsoleSize.Width, ConsoleSize.Height, 1);
            }
#endif

            // Prepare submodules
            ConsoleOutput.PrepareConsoleOutput();
            ConsoleError.PrepareConsoleError();
            ConsoleCommandHandler.PrepareConsoleCommands();
        }
    }
}
