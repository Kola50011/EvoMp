using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EvoMp.Core.ColorHandler;

namespace EvoMp.Core.ConsoleHandler
{
    public class ConsoleUtils
    {
        private static int _longestConsoleTypeLength;

        /// <summary>
        ///     Returns the propertys for the given ConsoleType
        /// </summary>
        /// <param name="consoleType">The requested console type</param>
        /// <returns></returns>
        public static ConsoleTypeProperties GetConsoleTypeProperties(ConsoleType consoleType)
        {
            MemberInfo[] memberInfo = consoleType.GetType().GetMember(consoleType.ToString());
            ConsoleTypeProperties attributes =
                (ConsoleTypeProperties)memberInfo[0].GetCustomAttribute(typeof(ConsoleTypeProperties), false);

            return attributes;
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
                    if (consoleTypeProperties.DisplayName.Length > _longestConsoleTypeLength)
                        _longestConsoleTypeLength = consoleTypeProperties.DisplayName.Length;
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