using System;
#if !__MonoCS__
using System.Linq;
using System.Windows.Forms;
using EvoMp.Core.ConsoleHandler.Properties;
#endif
using EvoMp.Core.Module.Server;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public static class ConsoleHandler
    {
#if !__MonoCS__
        internal static IntPtr ConsoleHandle = ConsoleUtils.GetStdHandle(-11);
#endif

        internal static int WindowWidth;
        internal static int WindowHeight;

        public static void PrepareConsole()
        {
#if __MonoCS__
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
#else
            // Modify Console for color codes ( Windows only)
            ConsoleUtils.GetConsoleMode(ConsoleHandle, out int currentMode);
            ConsoleUtils.SetConsoleMode(ConsoleHandle, currentMode | 0x0004);
#endif

            ModifyConsoleWindow();

            Shared.OnCoreStartupCompleted += () =>
            {
                ConsoleInput.PrepareConsoleInput();

                // Register Console commands. (In core not automaticly)
                ConsoleOutput.WriteLine(ConsoleType.ConsoleCommand, "ConsoleHandler commands.");
                ConsoleOutput.AppendPrefix("\t > ~;~");
                ConsoleCommandHandler.InspectModule(new Commands());
                ConsoleOutput.ResetPrefix();
            };


            // Catch CTRL + C
            Console.CancelKeyPress += (sender, args) =>
            {
                args.Cancel = true;
                ConsoleOutput.WriteLine(ConsoleType.Info,
                    $"Please shutdown with ~b~exit~;~ console command.");
            };
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
                Screen screen = Screen.AllScreens.ElementAt(Settings.Default.ConsoleFullscreenDisplay) ??
                                Screen.PrimaryScreen;
                IntPtr ptr = ConsoleUtils.GetConsoleWindow();

                // Move to wanted display
                ConsoleUtils.MoveWindow(ptr, screen.WorkingArea.Left, screen.WorkingArea.Top,
                    Console.LargestWindowWidth, Console.LargestWindowHeight, true);

                ConsoleUtils.ToggleConsoleFullscreenMode();
                height = Console.WindowHeight;
                width = Console.WindowWidth;
            }
            else
            {
                height = Math.Min(Console.LargestWindowHeight, 50);
                width = Math.Min(Console.LargestWindowWidth, 150);
                if (Settings.Default.ConsolePosition.X != -1 && Settings.Default.ConsolePosition.Y != -1)
                    ConsoleUtils.MoveWindow(ConsoleUtils.GetConsoleWindow(),
                        Settings.Default.ConsolePosition.X, Settings.Default.ConsolePosition.Y,
                        width, height + 3, true);

                ConsoleUtils.SetConsoleFixedSize(height, width);
            }
            // Set console size fixed
            WindowWidth = width;
            WindowHeight = height;
            Console.SetBufferSize(WindowWidth, WindowHeight + 3); // later resetting on the fly
#endif

            // Prepare submodules
            ConsoleOutput.PrepareConsoleOutput();
            ConsoleError.PrepareConsoleError();
            ConsoleCommandHandler.PrepareConsoleCommands();
        }
    }
}
