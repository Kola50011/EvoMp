using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleOutput
    {
        private static string _lastMessageBegin = String.Empty;

        /// <summary>
        ///     Used for console modifications, and
        ///     TODO: Catch default Console.Write and Console.WriteLine
        /// </summary>
        private static readonly IntPtr ConsoleHandle = GetStdHandle(-11);

        public static void InitConsoleHandler()
        {
            // Modify Console for color codes.
            GetConsoleMode(ConsoleHandle, out int currentMode);
            SetConsoleMode(ConsoleHandle, currentMode | 0x0004);
        }

        /// <summary>
        ///     Writes a empty line
        /// </summary>
        public static void WriteEmptyLine()
        {
            Console.WriteLine(new string(' ', Console.WindowWidth * 3));
        }

        public static void Write(ConsoleType consoleType, string message)
        {
            // Parse linebreaks for clear output
            string[] messages = message.Split(new[] { "\n", "~n~" }, StringSplitOptions.RemoveEmptyEntries);
            if (messages.Length == 1)
                InternalWrite(consoleType, message);
            else
                foreach (string singleMessage in messages)
                    InternalWrite(consoleType, singleMessage + "\n");
        }

        public static void WriteLine(ConsoleType consoleType, string message)
        {
            // Parse linebreaks for clear output
            string[] messages = message.Split(new[] { "\n", "~n~" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string singleMessage in messages)
                InternalWrite(consoleType, singleMessage + "\n");
        }

        private static void InternalWrite(ConsoleType consoleType, string message)
        {
            message = message.Replace("\t", "  ");

            // Get consoleType properties & parse message colors
            ConsoleTypeProperties typeProperties = ConsoleUtils.GetConsoleTypeProperties(consoleType);

            // Format message output
            string writeMessage = $"~w~[~c~{DateTime.Now.ToString(CultureInfo.CurrentUICulture)}~w~]" + " " +
                                  $"~w~[{typeProperties.ColorCodeType}" +
                                  $"{typeProperties.DisplayName ?? $"{consoleType}"}" +
                                  "~w~]";

            // save last message begin
            if (_lastMessageBegin == writeMessage)
                writeMessage = Regex.Replace(Regex.Replace(Regex.Replace(writeMessage, "~.~", ""),
                    "~..~", "").Replace("\t", "  "), ".", " ");
            else
                _lastMessageBegin = writeMessage;

            // Vertical line
            writeMessage = writeMessage + " | ";

            // Trim ConsoleType.Line for fit in console window
            if (consoleType == ConsoleType.Line)
                message = message.Substring(Regex.Replace(Regex.Replace(writeMessage, "~.~", ""),
                    "~..~", "").Replace("\t", "  ").Length);


            writeMessage += $"{typeProperties.ColorCodeText}{message}";

            writeMessage = ConsoleUtils.GenerateColoredString(
                ConsoleUtils.GtMpColorToConsoleColor(writeMessage),
                writeMessage);

            // Replace tab with spaces
            writeMessage = writeMessage.Replace("\t", "  ");

            // Write message
            Console.Write(writeMessage);

            // Reset console colors
            Console.ResetColor();
        }

        /// <summary>
        ///     Sets the console title
        /// </summary>
        /// <param name="title">New console title</param>
        public static void SetConsoleTitle(string title)
        {
            Console.Title = title;
        }

        /// <summary>
        ///     Clears the console window
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        ///     Prints a line wich fits perfectly to the window width
        /// </summary>
        /// <param name="linePattern">The pattern for the line</param>
        /// <param name="colorCode">Extra color code for the line (optional)</param>
        public static void PrintLine(string linePattern, string colorCode = "")
        {
            string returnString = string.Empty;

            // Generate line
            for (var i = 0; i * linePattern.Length < Console.WindowWidth; i++)
                returnString += linePattern;

            // Optional cut line
            if (returnString.Length > Console.WindowWidth)
                returnString = returnString.Substring(0, Console.WindowWidth);

            // Write line
            WriteLine(ConsoleType.Line, colorCode + returnString);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handle);
    }
}