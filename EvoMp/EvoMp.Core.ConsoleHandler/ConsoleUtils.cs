using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using EvoMp.Core.ColorHandler;

namespace EvoMp.Core.ConsoleHandler
{
    public class ConsoleUtils
    {
        private static int _longestConsoleTypeLength;
        private static int _lastConsoleTop;
        internal static int ConsoleInputStartLeft;

        /// <summary>
        ///     Returns the propertys for the given ConsoleType
        /// </summary>
        /// <param name="consoleType">The requested console type</param>
        /// <returns></returns>
        public static ConsoleTypeProperties GetConsoleTypeProperties(ConsoleType consoleType)
        {
            MemberInfo[] memberInfo = consoleType.GetType().GetMember(consoleType.ToString());
            ConsoleTypeProperties attributes =
                (ConsoleTypeProperties) memberInfo[0].GetCustomAttribute(typeof(ConsoleTypeProperties), false);

            return attributes;
        }

        /// <summary>
        /// Switches the console output safe to original and back.
        /// </summary>
        /// <param name="action">Functionblock between switching</param>
        public static void SafeSystemConsoleUse(Action action)
        {
            if (ConsoleOutput.OriginalTextWriter != null)
                Console.SetOut(ConsoleOutput.OriginalTextWriter);

            try
            {
                action();
            }
            finally
            {
                // Reset output
                if (ConsoleOutput.NewTextWriter != null)
                    Console.SetOut(ConsoleOutput.NewTextWriter);

                // Set error
                if (ConsoleOutput.OriginalTextWriter != null)
                    Console.SetError(ConsoleOutput.OriginalTextWriter);
            }
        }

        /// <summary>
        ///     Writes the message final to the console
        /// </summary>
        /// <param name="message">Message wich should be written</param>
        public static void InternalConsoleWrite(string message)
        {
            SafeSystemConsoleUse(() =>
            {
                if (Console.BufferHeight - Console.WindowHeight > 0)
                {
                    // Last pos, clear line, write message & save top
                    Console.SetCursorPosition(0, _lastConsoleTop);
                    Console.Write("".PadRight(Console.WindowWidth));
                    Console.SetCursorPosition(0, _lastConsoleTop);
                }
                Console.Write(message);
                _lastConsoleTop = Console.CursorTop;

                // Console text fits in window -> return;
                //if (_lastConsoleTop <= Console.WindowHeight)
                if (Console.CursorTop < Console.WindowHeight)
                    return;

                // Write input field
                ConsoleTypeProperties conInProps = GetConsoleTypeProperties(ConsoleType.ConsoleInput);
                string inputLine =
                    $"~w~ │{conInProps.ColorCodeType} {conInProps.DisplayName}" +
                    $"{"".PadRight(_longestConsoleTypeLength - ColorUtils.CleanUpColorCodes(conInProps.DisplayName).Length)} ~;~~w~│";

                float multipler = (float) 0.011 * ConsoleOutput.CountSameTimestamp;
                multipler = multipler < 0.9 ? multipler : (float) 0.9;

                inputLine =
                    ColorUtils.DarkUpHexColors(ConsoleOutput.LastTimestamp, multipler) +
                    $"~w~ │" +
                    string.Empty.PadRight(_longestConsoleTypeLength + 2, '_') + "~w~│" +
                    "".PadRight(Console.WindowWidth
                                - ColorUtils.CleanUpColorCodes(inputLine).Length
                                - ColorUtils.CleanUpColorCodes(ConsoleOutput.LastTimestamp).Length, '_') +
                    "\n" +
                    ColorUtils.DarkUpHexColors(ConsoleOutput.LastTimestamp, (float) 0.011 + multipler) +
                    inputLine + "  > ";

                if (Console.CursorTop + 2 > Console.BufferHeight)
                    Console.BufferHeight++;

                Console.Write(ColorUtils.GenerateColoredString(inputLine));
                ConsoleInputStartLeft = Console.CursorLeft;
                Console.Write(ConsoleInput.CurrentConsoleInput);
            });
        }

        /// <summary>
        ///     Checks if a System.Console.* Message is a GtMp Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static bool IsGtmpConsoleMessage(string message)
        {
            string[] gtmpConsoleParts =
            {
                " | Debug | GameServer | ",
                " |  Info | Program |",
                " |  Info | GameServer |"
            };

            return gtmpConsoleParts.Any(message.Contains);
        }

        /// <summary>
        ///     Reset console colors
        /// </summary>
        internal static void ResetColor()
        {
            SafeSystemConsoleUse(Console.ResetColor);
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
            SafeSystemConsoleUse(Console.Clear);
        }

        /// <summary>
        ///     Fills up a string with needed spaces,
        ///     or centering a string into wanted length
        /// </summary>
        /// <param name="text">Tex text</param>
        /// <param name="wantedLength">The wanted string length</param>
        /// <param name="centered">Should the text be centered?</param>
        /// <returns></returns>
        public static string AlignText(string text, int wantedLength, bool centered = false)
        {
            // Text is wanted Length -> return;
            if (text.Length == wantedLength)
                return text;

            string cleanedText = ColorUtils.CleanUpColorCodes(text);

            // text is longer then lineLenght -> return text
            if (cleanedText.Length > wantedLength)
                return text;

            int restLength = wantedLength - cleanedText.Length;

            // Text should be centered
            if (centered)
                return string.Empty.PadRight(restLength / 2) +
                       text + (restLength % 2 == 0 ? "" : " ") +
                       string.Empty.PadRight(restLength / 2);

            // Or text is filled up
            return text + string.Empty.PadRight(restLength);
        }

        /// <summary>
        ///     Returns the length of the longest ConsoleType item.
        ///     DisplayName or EnumName
        /// </summary>
        /// <returns></returns>
        public static int GetLengthOfLongestConsoleType()
        {
            // Longest type alread getted -> return;
            if (_longestConsoleTypeLength != 0) return _longestConsoleTypeLength;

            // Search for longest console type
            foreach (ConsoleType consoleType in Enum.GetValues(typeof(ConsoleType)))
            {
                ConsoleTypeProperties consoleTypeProperties = GetConsoleTypeProperties(consoleType);
                if (consoleTypeProperties.DisplayName != null)
                {
                    string displayName = ColorUtils.CleanUpColorCodes(consoleTypeProperties.DisplayName);
                    if (displayName.Length > _longestConsoleTypeLength)
                        _longestConsoleTypeLength = displayName.Length;
                }
                else if ($"{consoleType}".Length > _longestConsoleTypeLength)
                {
                    _longestConsoleTypeLength = $"{consoleType}".Length;
                }
            }

            return _longestConsoleTypeLength;
        }


        /// <summary>
        ///     Parsing a file line by line to a new string.
        ///     Adds ~n~ after each line.
        /// </summary>
        /// <param name="path">Path to the textfile</param>
        /// <param name="marginTopLines">Extra empty lines in top of the text file</param>
        /// <param name="marginBottomLines">Extra empty lines after the text file</param>
        /// <returns></returns>
        public static string ParseTextFileForConsole(string path, int marginTopLines = 0, int marginBottomLines = 0)
        {
            // File does not exist -> message & return;
            if (!File.Exists(path))
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    $"Can't load the text file ~r~\"{path}\"~w~. File ignored.");
                return string.Empty;
            }

            string returnString = string.Empty;
            int longestLineLength = 0;

            // Read file line by line
            string currentLine;
            StreamReader streamReader = new StreamReader(path);
            while ((currentLine = streamReader.ReadLine()) != null)
            {
                returnString += currentLine + "~n~";
                if (currentLine.Length > longestLineLength)
                    longestLineLength = currentLine.Length;
            }

            // MarginTop
            for (var i = 0; i < marginTopLines; i++)
                returnString = string.Empty.PadRight(longestLineLength) + "~n~" + returnString;

            // MarginTop
            for (var i = 0; i < marginBottomLines; i++)
                returnString += string.Empty.PadRight(longestLineLength) + "~n~";

            streamReader.Close();

            return returnString;
        }

        /// <summary>
        ///     Sets the console height and width to fixed sizes.
        /// </summary>
        /// <param name="heigth"></param>
        /// <param name="width"></param>
        public static void SetConsoleFixedSize(int heigth, int width)
        {
            const int mfBycommand = 0x00000000;
            const int scMinimize = 0xF020;
            const int scMaximize = 0xF030;
            const int scSize = 0xF000;

            Console.WindowHeight = heigth;
            Console.WindowWidth = width;

            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), scMinimize, mfBycommand);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), scMaximize, mfBycommand);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), scSize, mfBycommand);
        }

        #region Dll console imports

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetStdHandle(int handle);

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        #endregion //Dll console imports
    }
}