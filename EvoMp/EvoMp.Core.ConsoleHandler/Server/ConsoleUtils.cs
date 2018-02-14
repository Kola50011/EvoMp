using System;
using System.IO;
using System.Linq;
using System.Reflection;
#if !__MonoCS__
using System.Drawing;
using System.Runtime.InteropServices;
#endif
using EvoMp.Core.ColorHandler.Server;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public class ConsoleUtils
    {
        internal static int LongestTypeLength;
        internal static int InputCursorLeftStart;
        public static bool OriginalWriterInUse { get; set; }

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
        ///     Switches the console output safe to original and back.
        /// </summary>
        /// <param name="action">Functionblock between switching</param>
        public static void SafeSystemConsoleUse(Action action)
        {
            OriginalWriterInUse = true;
            if (ConsoleOutput.OriginalTextWriter != null)
                Console.SetOut(ConsoleOutput.OriginalTextWriter);
            try
            {
                action.Invoke();
            }
            finally
            {
                // Reset output
                if (ConsoleOutput.NewTextWriter != null)
                    Console.SetOut(ConsoleOutput.NewTextWriter);

                /*// Set error
                if (ConsoleOutput.NewTextWriter != null)
                    Console.SetError(ConsoleOutput.NewTextWriter);*/
                OriginalWriterInUse = false;
            }
        }

        /// <summary>
        ///     Checks if a System.Console.* Message is a GtMp Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool IsGtmpConsoleMessage(string message)
        {
            string[] gtmpConsoleParts =
            {
                " | Debug | GameServer | ",
                " |  Info | Program |",
                " |  Info | GameServer |",
                " |  Info | ServerAPI |"
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

            string cleanedText = ColorUtils.CleanUp(text);

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
            if (LongestTypeLength != 0) return LongestTypeLength;

            // Search for longest console type
            foreach (ConsoleType consoleType in Enum.GetValues(typeof(ConsoleType)))
            {
                ConsoleTypeProperties consoleTypeProperties = GetConsoleTypeProperties(consoleType);
                if (consoleTypeProperties.TypeName != null)
                {
                    string displayName = ColorUtils.CleanUp(consoleTypeProperties.TypeName);
                    if (displayName.Length > LongestTypeLength)
                        LongestTypeLength = displayName.Length;
                }
                else if ($"{consoleType}".Length > LongestTypeLength)
                {
                    LongestTypeLength = $"{consoleType}".Length;
                }
            }

            return LongestTypeLength;
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
            Console.WindowHeight = heigth;
            Console.WindowWidth = width;

#if !__MonoCS__
            const int mfBycommand = 0x00000000;
            const int scMinimize = 0xF020;
            const int scMaximize = 0xF030;
            const int scSize = 0xF000;

            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), scMinimize, mfBycommand);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), scMaximize, mfBycommand);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), scSize, mfBycommand);
#endif
        }

        /// <summary>
        ///     Toggles the console fullscreen mode.
        ///     Internal by (ALT + enter)
        /// </summary>
        public static void ToggleConsoleFullscreenMode()
        {
            //TODO: Add Linux support
#if !__MonoCS__ // ::SendMessage(::GetConsoleWindow(), , , 0x20000000);
            SendMessage((int) GetConsoleWindow(), 0x0104, 0x0D, 0x20000000);
#endif
        }

#if !__MonoCS__
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
        internal static extern IntPtr GetConsoleWindow();

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern long GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

#endregion //Dll console imports

#endif
    }
}
