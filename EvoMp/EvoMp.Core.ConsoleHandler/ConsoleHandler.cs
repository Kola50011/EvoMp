using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EvoMp.Core.ConsoleHandler.Properties;
using EvoMp.Core.Module;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleHandler
    {
        internal static IntPtr ConsoleHandle = ConsoleUtils.GetStdHandle(-11);

        internal static int WindowWidth;
        internal static int WindowHeight;

        public static void PrepareConsole()
        {
            // Modify Console for color codes
            ConsoleUtils.GetConsoleMode(ConsoleHandle, out int currentMode);
            ConsoleUtils.SetConsoleMode(ConsoleHandle, currentMode | 0x0004);

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
        /// Modifys the console window propertys
        /// </summary>
        private static void ModifyConsoleWindow()
        {
            int height;
            int width;

            // Fullscreen
            if (Settings.Default.ConsoleFullscreenMode)
            {
                // Setting screen or primary screen
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
                ConsoleUtils.SetConsoleFixedSize(height, width);
            }
            // Set console size fixed
            WindowWidth = width;
            WindowHeight = height;
            Console.SetBufferSize(WindowWidth, WindowHeight + 3); // later resetting on the fly

            // Prepare submodules
            ConsoleOutput.PrepareConsoleOutput();
            ConsoleError.PrepareConsoleError();
            ConsoleCommandHandler.PrepareConsoleCommands();
        }
    }
}