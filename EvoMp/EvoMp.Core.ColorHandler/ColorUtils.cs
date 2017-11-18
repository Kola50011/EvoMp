using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EvoMp.Core.ColorHandler
{
    public class ColorUtils
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
                    ColorCodeProperties.FirstOrDefault(cc => cc.Identifier.ToLower() == $"~{colorCode.ToLower()}~");

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
                    Console.Error.WriteLine($"~w~Invalid Hex code ~o~{colorCode}~w~.");
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
                    ColorCodeProperties.All(propertie => propertie.Identifier.ToLower() != $"~{colorCode.ToLower()}~"))
                    Console.Error.WriteLine(
                        $"~o~Unknown ~;~color string ~b~\"\\~{colorCode.ToLower()}\\~\"~;~!\n" +
                        $"Message: ~b~{CleanUp(message)}~r~.");

                // Parse position
                int colorCodePosition = message.IndexOf($"~{colorCode}~", StringComparison.Ordinal)
                                        + colorCode.Length + 2; // 2 = "~ ~"

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
        ///     Compares two colors by contrast and gives the difference
        /// </summary>
        /// <param name="color1">Color 1</param>
        /// <param name="color2">Color 2</param>
        /// <returns></returns>
        public static int CompareColorsContrast(Color color1, Color color2)
        {
            return Math.Abs(((299 * color1.R + 587 * color1.G + 114 * color1.B) /
                            1000) - ((299 * color2.R + 587 * color2.G +
                                              114 * color2.B) / 1000));

        }

        /// <summary>
        ///     Generates a colored string from the position/colors dictionary
        /// </summary>
        /// <param name="message">The message with the color strings</param>
        /// <returns>Colored string</returns>
        public static string ColorizeAscii(string message)
        {
            // Parse colors from each code with position
            Dictionary<int, Color> colorsWithPosition = ColorCodeToConsoleColor(message);

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
            string suffix = string.Empty;

            Color currentBackground = Color.Empty;
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

                    string backgroundColorString = "";
                    if (colorCode.Length > 1 && !colorCode.StartsWith("#") || colorCode.StartsWith("_#"))
                    {
                        backgroundColorString =
                            $";48;2;{currentCode.Value.R};{currentCode.Value.G};{currentCode.Value.B}";
                        currentBackground = currentCode.Value;
                    }

                    // Hint if background and foreground is similar
                    if (currentBackground != Color.Empty)
                        //if(Math.Abs(foregroundColor.GetHue() - currentBackground.GetHue()) <= 5)
                        // if (foregroundColor.CompareColorsRgb(foregroundColor, currentBackground) < 110)
                        if (CompareColorsContrast(foregroundColor, currentBackground) < 10)
                            Console.Error.WriteLine($"Please correct next message. " +
                                $"Sure you can read the text ~_~fine~|~ on this background?\n");

                    // Rebuild message
                    message = $"{message.Substring(0, currentCode.Key + completeColorCodesLength)}" +
                              $"{foregroundColorString}{backgroundColorString}m" +
                              $"{message.Substring(currentCode.Key + completeColorCodesLength)}";

                    // Add colorstring length for calculate next positions
                    completeColorCodesLength += foregroundColorString.Length + backgroundColorString.Length + 1; // "m"
                }

                void BuildControlString()
                {
                    string ansiString = ColorCodeProperties.First(cc => cc.Identifier.ToLower() == $"~{colorCode.ToLower()}~")
                        .ControlCodeAnsi;

                    // Is reset code -> reset last background
                    if (ansiString == GetColorCodePropertie(ColorCode.ResetColor).ControlCodeAnsi)
                        currentBackground = Color.Empty;


                    // Progress extra controls
                    switch (ansiString)
                    {
                        case "...": // FillLineWithSpaces
                            ansiString = "";
                            // full suffix added later
                            suffix += string.Empty.PadRight(
                                Console.WindowWidth - CleanUp(orignalMessage.Replace("\n", "")).Length);
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
                              $"{message.Substring(currentCode.Key + completeColorCodesLength)}";

                    completeColorCodesLength += ansiString.Length;
                }

                // Parse color code
                for (int i = currentCode.Key + completeColorCodesLength - 1; i > 0; i--)
                    if (message[i] != '~')
                        colorCode = message[i] + colorCode;
                    else if (i != currentCode.Key + completeColorCodesLength - 1)
                        break;

                // Color code is Control code -> Build Control String
                if (ColorCodeProperties.Any(cc => cc.Identifier.ToLower() == $"~{colorCode.ToLower()}~" && cc.ControlCodeAnsi != null
                                                  && (!codeParsingDisabled || cc.IgnoresParsingDisabled)))
                    BuildControlString();
                else if (!codeParsingDisabled)
                    BuildColorString();
            }

            // Add Suffix
            message += suffix;

            // Re add linebreak if existed
            if (orignalMessage.EndsWith("\n"))
                message += "\n";

            // Remove color identifiers & escape quotes
            message = CleanUp(message);

            return message;
        }

        /// <summary>
        ///     Cleans all color codes from a given message.
        ///     If the given message is invalid, each ~ gets escaped
        /// </summary>
        /// <param name="message">The message wich should be cleaned</param>
        /// <param name="onlyEscape">Only escape each tilde?</param>
        /// <returns></returns>
        public static string CleanUp(string message, bool onlyEscape = false)
        {
            List<string> colorCodes = ParseColorCodesSimple(message);

            // invalid message -> return complete escaped
            if (colorCodes == null || onlyEscape)
                return message.Replace("\\~", "~").Replace("~", "\\~");

            string result = message;
            foreach (var code in colorCodes)
                result = new Regex(Regex.Escape($"~{code}~")).Replace(result, "", 1);

            return result.Replace("\\~", "~");
        }


        /// <summary>
        ///     Gives the correct cut positin for a uncleaned string, based on a cleaned string
        /// </summary>
        /// <param name="uncleanedMessage">The uncleaned message with colorcodes</param>
        /// <param name="cleanedCutLength">Position of the cleaned final message cut</param>
        /// <returns></returns>
        public static int CleanedMessagePostionToUnCleanedMessagePositon(string uncleanedMessage, int cleanedCutLength)
        {
            string fullCleanedString = CleanUp(uncleanedMessage);
            int position = cleanedCutLength;

            List<string> colorCodes = ParseColorCodesSimple(uncleanedMessage).ToList();


            // Get best possible postion 
            for (int i = 0; i < uncleanedMessage.Length; i++)
                if (CleanUp(uncleanedMessage.Substring(0, i)) ==
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
                    if (uncleanedTestMessageLeft.ToLower().Contains($"~{colorCode.ToLower()}~"))
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
            string tildeMessage = message;
            int countTilde = tildeMessage.Count(c => c == '~');
            tildeMessage = tildeMessage.Replace(@"\~", "");
            int countEscapedTilde = countTilde - tildeMessage.Count(c => c == '~');
            countTilde = tildeMessage.Count(c => c == '~');

            // For easyer math (escaped tildes doesn't matter)
            if (countEscapedTilde % 2 != 0)
                countEscapedTilde++;

            // Open color codes exist -> return null;
            if ((countTilde - countEscapedTilde) % 2 != 0)
                return null;


            // Parse color codes
            bool openTilde = false;
            string currentCode = string.Empty;
            bool parsing = true;
            bool lastWasEscape = false;
            foreach (char messageChar in message)
            {
                // Escape char -> notice & next
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
    }
}
