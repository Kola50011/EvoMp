using System;
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

            modifyConsoleWindow();

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

        private static void modifyConsoleWindow()
        {
            int height;
            int width;

            //TODO: in progress
            // Fullscreen
            //if (Settings.Default.ConsoleFullscreenMode)
            //{
            //    // Setting screen or primary screen
            //    Screen screen = Screen.AllScreens.ElementAt(Settings.Default.ConsoleFullscreenDisplay) ??
            //                    Screen.PrimaryScreen;
            //    IntPtr ptr = ConsoleUtils.GetConsoleWindow();

            //    ConsoleUtils.MoveWindow(ptr, screen.WorkingArea.Left, screen.WorkingArea.Top, 1000, 400, true);

            //    // Alt + Enter
            //    SendKeys.Send("%~");

            //    height = Math.Min(Console.LargestWindowHeight, 50);
            //    width = Math.Min(Console.LargestWindowWidth, 150);
            //}
            //else
            //{
            height = Math.Min(Console.LargestWindowHeight, 50);
            width = Math.Min(Console.LargestWindowWidth, 150);
            ConsoleUtils.SetConsoleFixedSize(height, width);
            //}
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