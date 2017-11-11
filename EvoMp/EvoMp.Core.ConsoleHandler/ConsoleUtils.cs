using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EvoMp.Core.ConsoleHandler
{
    public class ConsoleUtils
    {
        // Storage colorCodeProperties for better perfomance
        private static readonly IEnumerable<ColorCodePropertie> ColorCodeProperties =
            Enum.GetValues(typeof(ColorCode))
                .Cast<ColorCode>()
                .Where(code => code.HasFlag(code))
                .Select(code => typeof(ColorCode)
                    .GetField(code.ToString()))
                .Select(info => info.GetCustomAttribute(typeof(ColorCodePropertie), false))
                .Cast<ColorCodePropertie>();

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
        ///     Returns the propertys for the given color code
        /// </summary>
        /// <param name="colorCode">The requested color code</param>
        /// <returns></returns>
        public static ColorCodePropertie GetColorCodePropertie(ColorCode colorCode)
        {
            MemberInfo[] memberInfo = colorCode.GetType().GetMember(colorCode.ToString());
            ColorCodePropertie attributes =
                (ColorCodePropertie)memberInfo[0].GetCustomAttribute(typeof(ColorCodePropertie), false);

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

            string cleanedText = CleanUpColorCodes(text);

            // text is longer then lineLenght -> return text
            if (cleanedText.Length > wantedLength)
                return text;

            int restLength = wantedLength - cleanedText.Length;

            // Text should be centered
            if (centered)
                return string.Empty.PadRight((restLength - 1) / 2) +
                       text + (restLength % 2 == 0 ? "" : " ") +
                       string.Empty.PadRight((restLength - 1) / 2);

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
        ///     Gives the correct Color for a given colorTilde string
        /// </summary>
        /// <param name="colorCode">The colorCode string</param>
        /// <returns>Color or Color.Empty</returns>
        public static Color ColorTildeToColor(string colorCode)
        {
            Color ParseColorCode()
            {
                // Get the correct color code from the tilde & return it
                ColorCodePropertie colorCodePropertie =
                    ColorCodeProperties.FirstOrDefault(cc => cc.Identifier == $"~{colorCode}~");

                // Return color code, if not control code
                if (colorCodePropertie != null)
                    if (colorCodePropertie.ControlCodeAnsi == null)
                        return Color.FromKnownColor(colorCodePropertie.Color);

                return Color.Empty;
            }

            Color ParseHexColorCode()
            {
                if (colorCode.StartsWith("_#"))
                    colorCode = colorCode.Substring(1);

                // If only #fff given, make #ffffff
                if (colorCode.Length == 4)
                    colorCode = colorCode + colorCode.Substring(1);


                Color returnColor;
                // Try Get color from Hex String
                try
                {
                    returnColor = ColorTranslator.FromHtml(colorCode);
                }
                catch (Exception)
                {
                    returnColor = Color.FromArgb(55, 55, 55);
                    ConsoleOutput.WriteLine(ConsoleType.Warn, $"~w~Invalid Hex code ~o~{colorCode}~w~.");
                }

                return returnColor;
            }

            return colorCode.StartsWith("#") || colorCode.StartsWith("_#")
                ? ParseHexColorCode()
                : ParseColorCode();
        }


        /// <summary>
        ///     Creates a Dictionary wich contains the gtmp color code
        ///     and the matching console color for the gtmp font color string.
        /// </summary>
        /// <param name="message">The gtMp colored string</param>
        /// <returns> </returns>
        public static Dictionary<int, Color> ColorCodeToConsoleColor(string message)
        {
            Dictionary<int, Color> returnConsoleColors = new Dictionary<int, Color>();

            List<string> colorCodes = ParseColorCodesSimple(message);

            // Remember last length for correct position
            int lastMessageLength = 0;

            // Get all ~*~ color codes
            foreach (string colorCode in colorCodes)
            {
                // Get equal of color code for console
                Color equalConsoleColor = ColorTildeToColor(colorCode);

                // Check for invalid color string
                if (equalConsoleColor == Color.Empty &&
                    ColorCodeProperties.All(propertie => propertie.Identifier != $"~{colorCode}~"))
                    ConsoleOutput.WriteLine(ConsoleType.Warn,
                        $"~o~Unknown ~;~color string ~b~\"\\~{colorCode}\\~\"~;~!\n" +
                        $"Message: ~b~{CleanUpColorCodes(message)}~r~.");

                // Parse position
                int colorCodePosition = message.IndexOf($"~{colorCode}~", StringComparison.Ordinal)
                                        + colorCode.Length + 2;

                // Cut message, for next tilde parse
                message = message.Substring(colorCodePosition);

                // Add postion and ConsoleColor to dictionary
                returnConsoleColors.Add(lastMessageLength + colorCodePosition, equalConsoleColor);
                lastMessageLength += colorCodePosition;
            }

            // Return parsed positions and colors
            return returnConsoleColors;
        }

        /// <summary>
        ///     Generates a colored string from the position/colors dictionary
        /// </summary>
        /// <param name="colorsWithPosition">The position/color dictionary</param>
        /// <param name="message">The message with the color strings</param>
        /// <returns>Colored string</returns>
        public static string GenerateColoredString(Dictionary<int, Color> colorsWithPosition, string message)
        {
            string orignalMessage = message;
            bool codeParsingDisabled = false;

            //Remove possible \n at end first (added later again)
            if (message.EndsWith("\n"))
                message = message.Substring(0, message.Length - "\n".Length);

            // Save string length with added color codes 
            // for set correct position in modified message
            int completeColorCodesLength = 0;

            // Set current foreground color (Default: white)
            Color foregroundColor = Color.White;

            string asd;
            if (message.Contains("Fatal"))
                   asd = String.Empty + "asd";

            // Replace color code 
            foreach (KeyValuePair<int, Color> currentCode in colorsWithPosition)
            {
                string colorCode = string.Empty;

                void BuildColorString()
                {
                    // Single color code is foreground
                    if (colorCode.Length == 1 || colorCode.StartsWith("#"))
                        foregroundColor = currentCode.Value;

                    // Build color strings
                    string foregroundColorString =
                        $"\x1B[38;2;{foregroundColor.R};{foregroundColor.G};{foregroundColor.B}";

                    string backgroundColorString =
                        colorCode.Length > 1 && !colorCode.StartsWith("#") || colorCode.StartsWith("_#")
                            ? $";48;2;{currentCode.Value.R};{currentCode.Value.G};{currentCode.Value.B}"
                            : "";

                    // Rebuild message
                    message = $"{message.Substring(0, currentCode.Key + completeColorCodesLength)}" +
                              $"{foregroundColorString}{backgroundColorString}m" +
                              $"{message.Substring(currentCode.Key + completeColorCodesLength)}";

                    // Add colorstring length for calculate next positions
                    completeColorCodesLength += foregroundColorString.Length + backgroundColorString.Length + 1; // "m"
                }

                void BuildControlString()
                {
                    string suffix = string.Empty;
                    string ansiString = ColorCodeProperties.First(cc => cc.Identifier == $"~{colorCode}~")
                        .ControlCodeAnsi;

                    // Progress extra controls
                    switch (ansiString)
                    {
                        // FillLineWithSpaces
                        case "...":
                            ansiString = ""; //~...~
                                             // Fill line only if text is not to big
                                             //if (CleanUpColorCodes(orignalMessage).Length < Console.WindowWidth)
                            suffix = string.Empty.PadRight(
                                    Console.WindowWidth - CleanUpColorCodes(orignalMessage.Replace("\n", "")).Length);
                            break;
                        case "!00!": // Turn Code Parsing off
                            codeParsingDisabled = true;
                            return;
                        case "!01!": // Turn Code Parsing off
                            codeParsingDisabled = false;
                            return;
                    }

                    message = $"{message.Substring(0, currentCode.Key + completeColorCodesLength)}" +
                              ansiString +
                              $"{message.Substring(currentCode.Key + completeColorCodesLength)}" +
                              suffix;

                    completeColorCodesLength += ansiString.Length + suffix.Length;
                }

                // Parse color code
                for (int i = currentCode.Key + completeColorCodesLength - 1; i > 0; i--)
                    if (message[i] != '~')
                        colorCode = message[i] + colorCode;
                    else if (i != currentCode.Key + completeColorCodesLength - 1)
                        break;

                // Color code is Control code -> Build Control String
                if (ColorCodeProperties.Any(cc => cc.Identifier == $"~{colorCode}~" && cc.ControlCodeAnsi != null
                                                  && (!codeParsingDisabled || cc.IgnoresParsingDisabled)))
                    BuildControlString();
                else if (!codeParsingDisabled)
                    BuildColorString();
            }

            // Re add linebreak if existed
            if (orignalMessage.EndsWith("\n"))
                message += "\n";

            // Remove color identifiers & escape quotes
            message = CleanUpColorCodes(message);

            return message;
        }

        /// <summary>
        ///     Cleans all color codes from a given message
        /// </summary>
        /// <param name="message">The message wich should be cleaned</param>
        /// <returns></returns>
        public static string CleanUpColorCodes(string message)
        {
            List<string> colorCodes = ParseColorCodesSimple(message);

            return colorCodes.Aggregate(message,
                    (current, colorCode) => new Regex(Regex.Escape($"~{colorCode}~")).Replace(current, "", 1))
                .Replace(@"\~", "");
        }

        /// <summary>
        ///     Gives the correct cut positin for a uncleaned string, based on a cleaned string
        /// </summary>
        /// <param name="uncleanedMessage">The uncleaned message with colorcodes</param>
        /// <param name="cleanedCutLength">Position of the cleaned final message cut</param>
        /// <returns></returns>
        public static int CleanedMessagePostionToUnCleanedMessagePositon(string uncleanedMessage, int cleanedCutLength)
        {
            string fullCleanedString = CleanUpColorCodes(uncleanedMessage);
            int position = cleanedCutLength;

            List<string> colorCodes = ParseColorCodesSimple(uncleanedMessage);


            // Get best possible postion 
            for (int i = 0; i < uncleanedMessage.Length; i++)
                if (CleanUpColorCodes(uncleanedMessage.Substring(0, i)) ==
                    fullCleanedString.Substring(0, cleanedCutLength))
                {
                    position = i;
                    break;
                }

            bool brokenColorCodes = true;

            while (brokenColorCodes)
            {
                brokenColorCodes = false;
                // Left and right side of the new cutten text
                string uncleanedTestMessageLeft = uncleanedMessage.Substring(0, position);
                string uncleanedTestMessageRight = uncleanedMessage.Substring(position);

                // Check now each colorCodes and each side of new string
                foreach (string colorCode in colorCodes)
                {
                    if (uncleanedTestMessageLeft.Contains($"~{colorCode}~"))
                    {
                        uncleanedTestMessageLeft =
                            new Regex(Regex.Escape($"~{colorCode}~")).Replace(uncleanedTestMessageLeft, "", 1);
                        continue;
                    }
                    if (uncleanedTestMessageRight.Contains($"~{colorCode}~"))
                    {
                        uncleanedTestMessageRight =
                            new Regex(Regex.Escape($"~{colorCode}~")).Replace(uncleanedTestMessageRight, "", 1);
                        continue;
                    }


                    // Colorcode can't found in left or right side -> broken.
                    brokenColorCodes = true;

                    // Go backwards, try with spaces
                    if (uncleanedMessage.Substring(0, position).Contains(" "))
                    {
                        position = uncleanedMessage.Substring(0, position).LastIndexOf(" ", StringComparison.Ordinal);

                        if (position != 1)
                            position--;
                    }
                    else // Otherwhite find any position where cut is possible without destroying a colorCode
                    {
                        position--;
                    }
                    break;
                }
            }

            return position;
        }


        /// <summary>
        ///     Parsing a message for all given text codes
        /// </summary>
        /// <param name="message">The message wich should be parsed</param>
        /// <returns>List of text codes, orderd by position in message</returns>
        public static List<string> ParseColorCodesSimple(string message)
        {
            List<string> colorCodes = new List<string>();

            // Check tilde count
            int countTilde = message.Count(c => c == '~');
            int countEscapedTilde = new Regex(Regex.Escape(@"\~")).Matches(message).Count;
            if ((countTilde - countEscapedTilde) % 2 != 0)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    $"Not closed or opened color code in message \n" +
                    $"~o~\"{message}\"~;~.\n" +
                    $"Message would not parsed. Escape tildes by using ~b~\"\\~\"~;~.");
                return colorCodes;
            }

            // Parse color codes
            bool openTilde = false;
            string currentCode = string.Empty;
            bool parsing = true;
            bool lastWasEscape = false;
            foreach (char messageChar in message)
            {
                if (messageChar == '\\')
                {
                    lastWasEscape = true;
                    continue;
                }

                if (messageChar == '~')
                {
                    if (lastWasEscape)
                    {
                        lastWasEscape = false;
                        continue;
                    }

                    if (openTilde)
                    {
                        openTilde = false;

                        // Get possible code
                        ColorCodePropertie colorCodePropertie =
                            ColorCodeProperties.FirstOrDefault(ccp => ccp.Identifier == $"~{currentCode}~");

                        // Add if parsing active
                        if (parsing || colorCodePropertie != null && colorCodePropertie.IgnoresParsingDisabled)
                            colorCodes.Add(currentCode);

                        if (colorCodePropertie != null)
                        {
                            // Change parsing state if needed
                            if (colorCodePropertie.ControlCodeAnsi == "!00!")
                                parsing = false;

                            if (colorCodePropertie.ControlCodeAnsi == "!01!")
                                parsing = true;
                        }

                        currentCode = string.Empty;
                    }
                    else
                    {
                        openTilde = true;
                    }
                }
                else if (openTilde)
                {
                    currentCode += messageChar;
                }

                // Reset escape bool
                lastWasEscape = false;
            }

            return colorCodes;
        }

        /// <summary>
        ///     Function, wich darks up the hex codes in a given string.
        ///     #000 -> #555
        /// </summary>
        /// <param name="message"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static string DarkUpHexColors(string message, float percentage)
        {
            List<string> colorCodes = ParseColorCodesSimple(message);

            // Darkdown & replace color codes
            foreach (string colorCode in colorCodes)
            {
                // No Hex color code -> continue
                if (!colorCode.StartsWith("#") && !colorCode.StartsWith("_#"))
                    continue;

                // Remove background identifer
                string oldColorCode = colorCode.Replace("_", "");

                // If only #fff given, make #ffffff
                if (oldColorCode.Length < 7)
                    oldColorCode = colorCode + colorCode.Substring(1);

                Color htmlColor = ColorTranslator.FromHtml(oldColorCode);
                htmlColor = ControlPaint.Dark(htmlColor, percentage);

                string newColorCode = ColorTranslator.ToHtml(htmlColor);
                message = new Regex(Regex.Escape(colorCode.Replace("_", ""))).Replace(message, newColorCode, 1);
            }
            return message;
        }

        /// <summary>
        ///     Parsing a file line by line to a new string.
        ///     Adds ~n~ after each line.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ParseTextFileForConsole(string path)
        {
            // File does not exist -> message & return;
            if (!File.Exists(path))
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    $"Can't load the text file ~o~\"path\"~w~. File ignored.");
                return string.Empty;
            }

            string returnString = string.Empty;

            // Read file line by line
            string currentLine;
            StreamReader streamReader = new StreamReader(path);
            while ((currentLine = streamReader.ReadLine()) != null)
                returnString += currentLine + "~n~";

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