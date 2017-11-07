using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EvoMp.Core.ConsoleHandler
{
    internal class ConsoleUtils
    {
        public static ConsoleTypeProperties GetConsoleTypeProperties(ConsoleType consoleType)
        {
            MemberInfo[] memberInfo = consoleType.GetType().GetMember(consoleType.ToString());
            ConsoleTypeProperties attributes =
                (ConsoleTypeProperties) memberInfo[0].GetCustomAttribute(typeof(ConsoleTypeProperties), false);

            return attributes;
        }

        /// <summary>
        ///     Gives the correct KnownColor for a given colorTilde string
        /// </summary>
        /// <param name="colorCode"></param>
        /// <returns>KnownColor or casted -2 as unknown</returns>
        public static KnownColor ColorTildeToKnownColor(string colorCode)
        {
            // Get all color codes
            IEnumerable<ColorCodePropertie> colorCodes = Enum.GetValues(typeof(ColorCodes))
                .Cast<ColorCodes>()
                .Where(code => code.HasFlag(code))
                .Select(code => typeof(ColorCodes)
                    .GetField(code.ToString()))
                .Select(info => info.GetCustomAttribute(typeof(ColorCodePropertie), false))
                .Cast<ColorCodePropertie>();

            // Get the correct color code from the tilde & return it
            ColorCodePropertie colorCodePropertie =
                colorCodes.FirstOrDefault(cc => cc.Identifier == $"~{colorCode}~");
            return colorCodePropertie?.Color ?? (KnownColor) (-2);
        }


        /// <summary>
        ///     Creates a Dictionary wich contains the gtmp color code
        ///     and the matching console color for the gtmp font color string.
        /// </summary>
        /// <param name="message">The gtMp colored string</param>
        /// <returns> </returns>
        public static Dictionary<int, KnownColor> GtMpColorToConsoleColor(string message)
        {
            Dictionary<int, KnownColor> returnConsoleColors = new Dictionary<int, KnownColor>();

            // Split string to gtmp colors
            string[] colors = message.Split('~', '~');

            // Remember last length for correct position
            int lastMessageLength = 0;

            // Get all ~*~ color codes
            for (var i = 0; i < colors.Length; i++)
            {
                // Last tilde -> continue;
                if (colors.Length < i + 2)
                    continue;

                // string can't be color code -> continue;
                if (colors[i].Length > 2 || string.IsNullOrWhiteSpace(colors[i]))
                    continue;

                // Thing between two "~g~[~b~"
                if(i != 0 && colors[i-1].Length <= 2 && colors[i+1].Length <= 2)
                    continue;

                // Get equal of GtMp color for console
                KnownColor equalConsoleColor = ColorTildeToKnownColor(colors[i]);

                // Check for invalid color string
                if (equalConsoleColor == (KnownColor) (-2))
                    ConsoleHandler.WriteLine(ConsoleType.Warn, $"~o~Invalid ~w~color string ~b~\"{colors[i]}\"~w~!");

                // Parse position
                int colorCodePosition = message.IndexOf($"~{colors[i]}~", StringComparison.Ordinal)
                                        + colors[i].Length + 2;

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
        public static string GenerateColoredString(Dictionary<int, KnownColor> colorsWithPosition, string message)
        {
            // Save original message for parsing the color codes correctly
            string originalMessage = message;

            // Save string length with added color codes 
            // for set correct position in modified message
            int completeColorCodesLength = 0;

            // Set current foreground color (Default: white)
            Color foregroundColor = Color.White;

            // Replace color code 
            foreach (KeyValuePair<int, KnownColor> currentCode in colorsWithPosition)
            {
                void BuildColorString()
                {
                    // Get correct Color from enum name
                    Color color = Color.FromName(Enum.GetName(typeof(KnownColor), currentCode.Value) ??
                                                 throw new InvalidOperationException(
                                                     $"Unknown color code used! \"{currentCode.Value}\""));

                    // Parse color code
                    string colorCode =
                        originalMessage.Substring(currentCode.Key - 3 == 0
                            ? currentCode.Key - 3
                            : currentCode.Key - 4);
                    colorCode = colorCode.Substring(colorCode.IndexOf("~", StringComparison.Ordinal) + 1);
                    colorCode = colorCode.Substring(0, colorCode.IndexOf("~", StringComparison.Ordinal));

                    // Single color code is foreground
                    if (colorCode.Length == 1)
                        foregroundColor = color;

                    // Build color strings
                    string foregroundColorString =
                        $"\x1B[38;2;{foregroundColor.R};{foregroundColor.G};{foregroundColor.B}";
                    string backgroundColorString = colorCode.Length > 1 ? $";48;2;{color.R};{color.G};{color.B}" : "";

                    // Rebuild message
                    message = $"{message.Substring(0, currentCode.Key + completeColorCodesLength)}" +
                              $"{foregroundColorString}{backgroundColorString}m" +
                              $"{message.Substring(currentCode.Key + completeColorCodesLength)}";

                    // Add colorstring length for calculate next positions
                    completeColorCodesLength += foregroundColorString.Length + backgroundColorString.Length + 1; // "m"
                }

                void BuildControlString()
                {
                    // Define ansi strings
                    const string underline = "\x1B[4m";
                    const string underlineOff = "\x1B[24m";
                    const string bold = "\x1B[1m";
                    const string reset = "\x1B[0m";
                    const string newLine = "\n";

                    string ansiString = string.Empty;

                    // Select wanted ansi string
                    switch ((int) currentCode.Value)
                    {
                        case -3:
                            ansiString = newLine;
                            break;
                        case -4:
                            ansiString = reset;
                            break;
                        case -5:
                            ansiString = bold;
                            break;
                        case -6:
                            ansiString = underline;
                            break;
                        case -7:
                            ansiString = underlineOff;
                            break;
                    }

                    message = $"{message.Substring(0, currentCode.Key + completeColorCodesLength)}" +
                              ansiString +
                              $"{message.Substring(currentCode.Key + completeColorCodesLength)}";

                    completeColorCodesLength += ansiString.Length;
                }

                // current code contains control char -> Build control string
                if (currentCode.Value < 0)
                    BuildControlString();
                else // Otherwise build color string
                    BuildColorString();
            }

            // Remove color identifiers
            message = Regex.Replace(message, "~.~", "");
            message = Regex.Replace(message, "~..~", "");

            return message;
        }
    }
}