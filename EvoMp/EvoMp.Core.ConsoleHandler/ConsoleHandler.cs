using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace EvoMp.Core.ConsoleHandler
{
    public class ConsoleHandler
    {
        private static ConsoleHandler _instance;
        /// <summary>
        /// Used for console modifications, and 
        /// TODO: Catch default Console.Write and Console.WriteLine..
        /// </summary>
        private static readonly IntPtr ConsoleHandle = GetStdHandle(-11);

        private ConsoleHandler()
        {
            // Modify Console for color codes.
            GetConsoleMode(ConsoleHandle, out int currentMode);
            SetConsoleMode(ConsoleHandle, currentMode | 0x0004);
        }

        private static ConsoleHandler GetInstance()
        {
            return _instance ?? (_instance = new ConsoleHandler());
        }

        public static void Write(ConsoleType consoleType, string message)
        {
            // Get ConsoleHandler instance & write
            ConsoleHandler instance = GetInstance();
            instance.InternalWrite(consoleType, message);
        }

        public static void WriteLine(ConsoleType consoleType, string message)
        {
            // Get ConsoleHandler instance & write message + linebreak
            ConsoleHandler instance = GetInstance();
            instance.InternalWrite(consoleType, message + "\n");
        }

        private void InternalWrite(ConsoleType consoleType, string message)
        {
            // Format message output
            string writeMessage = $"~w~{new DateTime().ToString(CultureInfo.InvariantCulture)}" + " " +
                                      $"[{consoleType}]" + " " +
                                      $"{message}";

            // Get consoleType properties & parse message colors
            ConsoleTypeProperties consoleTypeProperties = ConsoleUtils.GetConsoleTypeProperties(consoleType);
            writeMessage = ConsoleUtils.GenerateColoredString(ConsoleUtils.GtMpColorToConsoleColor(writeMessage), writeMessage);

            // Optional set console background
            if(consoleTypeProperties.BackgroundColor > (ConsoleColor)(-1))
                Console.BackgroundColor = consoleTypeProperties.BackgroundColor;

            // Write message
            Console.Write(writeMessage);

            // Reset console colors
            Console.ResetColor();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);
    }

}
