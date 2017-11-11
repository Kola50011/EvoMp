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
            ConsoleUtils.SetConsoleFixedSize(60, 160);
        }
    }
}