using System;
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
            // Modify Console for color codes.
            ConsoleUtils.GetConsoleMode(ConsoleHandle, out int currentMode);
            ConsoleUtils.SetConsoleMode(ConsoleHandle, currentMode | 0x0004);

            // Set console size fixed
            int height = Math.Min(Console.LargestWindowHeight, 50);
            int width = Math.Min(Console.LargestWindowWidth, 150);
            ConsoleUtils.SetConsoleFixedSize(height, width);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight + 1);
            WindowWidth = width;
            WindowHeight = height;

            // Prepare submodules
            ConsoleOutput.PrepareConsoleOutput();
            ConsoleError.PrepareConsoleError();
            Shared.OnCoreStartupCompleted += ConsoleInput.PrepareConsoleInput;

            // Catch CTRL + C
            Console.CancelKeyPress += (sender, args) =>
            {
                args.Cancel = true;
                ConsoleOutput.WriteLine(ConsoleType.Info,
                    $"Please shutdown with ~b~exit~;~ console command.");
            };
        }
    }
}