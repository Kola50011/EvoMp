using System;
using System.Runtime.InteropServices;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleHandler
    {
        public static void PrepareConsole()
        {
            IntPtr consoleHandle = ConsoleUtils.GetStdHandle(-11);

            // Modify Console for color codes.
            ConsoleUtils.GetConsoleMode(consoleHandle, out int currentMode);
            ConsoleUtils.SetConsoleMode(consoleHandle, currentMode | 0x0004);

            // Set console size fixed
            int height = Math.Min(Console.LargestWindowHeight, 70);
            int width = Math.Min(Console.LargestWindowWidth, 150);
            ConsoleUtils.SetConsoleFixedSize(height, width); 
        }
    }
}