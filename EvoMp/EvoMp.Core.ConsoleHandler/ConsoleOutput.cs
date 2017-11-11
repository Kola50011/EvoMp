using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleOutput
    {
        private static string _lastTimestamp = string.Empty;
        private static int _countSameTimestamp;
        private static int _lastHeaderLength;


        /// <summary>
        ///     Writes a empty line
        /// </summary>
        public static void WriteEmptyLine()
        {
            Console.WriteLine(new string(' ', Console.WindowWidth * 3));
        }

        /// <summary>
        ///     Splits a long colored message into a few messages wich fits in the console.
        /// </summary>
        /// <param name="message">The long colored message wich should be splitten</param>
        /// <returns></returns>
        private static string[] WordWrapMessage(string message)
        {
            List<string> returnList = new List<string>();
            string restMessage = message;

            // No last header length given -> just return
            if (_lastHeaderLength == 0)
            {
                returnList.Add(message);
                return returnList.ToArray();
            }

            //ConsoleUtils.CleanUpColorCodes(restMessage).LastIndexOf(" ", StringComparison.Ordinal) != -1 ? ConsoleUtils.CleanUpColorCodes(restMessage).LastIndexOf(" ", StringComparison.Ordinal) : 
            string cleanedRestMessage = ConsoleUtils.CleanUpColorCodes(restMessage);

            int cutLength = cleanedRestMessage.Length;
            while (cutLength > Console.WindowWidth - _lastHeaderLength)
            {
                //cutLength = ConsoleUtils.CleanUpColorCodes(restMessage).Length;

                int unCleanMessageCutPos = ConsoleUtils.CleanedMessagePostionToUnCleanedMessagePositon(
                    restMessage, cutLength);
                returnList.Add(restMessage.Substring(0, unCleanMessageCutPos));
                restMessage = restMessage.Substring(unCleanMessageCutPos);

                // Try to cut next on a free space.
                cutLength =
                    cleanedRestMessage.LastIndexOf(" ", StringComparison.Ordinal) != -1
                        ? cleanedRestMessage.LastIndexOf(" ", StringComparison.Ordinal)
                        : cleanedRestMessage.Length; ;
            }


            // Add rest string to message
            returnList.Add(restMessage);

            return returnList.ToArray();
        }

        /// <summary>
        ///     Writes a console entry. With automatic word wrap.
        /// </summary>
        /// <param name="consoleType"></param>
        /// <param name="message"></param>
        public static void Write(ConsoleType consoleType, string message)
        {
            // Parse linebreaks for clear output
            string[] messages = message.Split(new[] { "\n", "~n~" }, StringSplitOptions.RemoveEmptyEntries);

            // Cut messages to fit in the console
            for (var i = 0; i < messages.Length; i++)
            {
                //    InternalWrite(consoleType, messages[i] + (i != message.Length ? "\n" : ""));
                // wrapp messages if they are to long for the console space
                string[] wrappedMessages = WordWrapMessage(messages[i]);
                for (var b = 0; b < wrappedMessages.Length; b++)
                {
                    InternalWrite(consoleType,
                        wrappedMessages[b] + (i == messages.Length && b == wrappedMessages.Length ? "" : "\n"));
                }
            }
        }

        public static void WriteLine(ConsoleType consoleType, string message)
        {
            // Parse linebreaks for clear output
            string[] messages = message.Split(new[] { "\n", "~n~" }, StringSplitOptions.RemoveEmptyEntries);
            /*
            // Cut messages to fit in the console
            for (var i = 0; i < messages.Length; i++)
                InternalWrite(consoleType, messages[i] + "\n");*/
            // Cut messages to fit in the console
            for (int i = 0; i < messages.Length; i++)
            {
                //    InternalWrite(consoleType, messages[i] + (i != message.Length ? "\n" : ""));
                // wrapp messages if they are to long for the console space
                string[] wrappedMessages = WordWrapMessage(messages[i]);
                for (int b = 0; b < wrappedMessages.Length; b++)
                {
                    InternalWrite(consoleType, wrappedMessages[b] + "\n");
                }
            }
        }


        /// <summary>
        ///     Writes a full centred Text in the Console.
        /// </summary>
        /// <param name="consoleType"></param>
        /// <param name="text"></param>
        public static void WriteCentredText(ConsoleType consoleType, string text)
        {
            // Parse linebreaks for clear output
            string[] messages = text.Split(new[] { "\n", "~n~" }, StringSplitOptions.RemoveEmptyEntries);

            int longestTextLine = messages.OrderBy(s => s.Length).First().Length;
            foreach (string singleMessage in messages)
                InternalWrite(consoleType, ConsoleUtils.AlignText(singleMessage, longestTextLine, true), true, "\n");
        }

        private static void InternalWrite(ConsoleType consoleType, string message, bool centered = false,
            string suffix = "")
        {
            // Message empty -> return;
            if (string.IsNullOrEmpty(message))
                return;

            // Format message output
            string writeMessage = string.Empty;
            bool wasControlCodeLine = false;
            bool messageHasLinebreak = false;

            // Prepare message.
            if (message.EndsWith("\n"))
            {
                messageHasLinebreak = true;
                message = message.Substring(0, message.Length - "\n".Length);
            }
            message = message.Replace("\t", "  ");

            // Get consoleType properties & parse message colors
            ConsoleTypeProperties typeProperties = ConsoleUtils.GetConsoleTypeProperties(consoleType);

            #region Prepare Head and lines

            if (consoleType != ConsoleType.Empty)
            {
                string timestamp = $"~#cccccc~{DateTime.Now.ToString(CultureInfo.CurrentUICulture)}";

                // Timestamp didn't changed -> dark it up
                if (_lastTimestamp == timestamp)
                {
                    _countSameTimestamp++;
                    timestamp = ConsoleUtils.DarkUpHexColors(timestamp, (float)0.011 * _countSameTimestamp);
                }
                else
                {
                    _lastTimestamp = timestamp;
                    _countSameTimestamp = 0;
                }

                // Write log type information
                string typeDisplayName = typeProperties.DisplayName?.ToUpper() ?? $"{consoleType}".ToUpper();
                writeMessage = timestamp + "~w~ │ " +
                               ConsoleUtils.AlignText(typeProperties.ColorCodeType + typeDisplayName + "~|~",
                                   ConsoleUtils.GetLengthOfLongestConsoleType());

                // Vertical line
                writeMessage = writeMessage + " ~w~│ ";

                // Save header length for calculation
                _lastHeaderLength = ConsoleUtils.CleanUpColorCodes(writeMessage).Replace("\t", "  ").Length;

                // Trim ConsoleType.Line for fit in console window
                // Or Lines with other ConsoleType
                if (consoleType == ConsoleType.Line || message.StartsWith("~!--!~"))
                {
                    // Cut special line switch
                    if (message.StartsWith("~!--!~"))
                    {
                        message = message.Substring("~!--!~".Length);
                        wasControlCodeLine = true;
                    }

                    if (_lastHeaderLength < message.Length)
                        message = message.Substring(_lastHeaderLength);
                }
            }

            #endregion //Prepare Head and lines

            // Get message color from type
            string consoleTypeTextColorCode = typeProperties.ColorCodeText;


            // Filter all control codes from the typetextcode to use it as reset code
            string harmlessTypeTextCode = consoleTypeTextColorCode;
            foreach (ColorCode colorCode in Enum.GetValues(typeof(ColorCode)))
            {
                ColorCodePropertie colorCodePropertie = ConsoleUtils.GetColorCodePropertie(colorCode);
                if (colorCodePropertie.HasSpecialLogic)
                    harmlessTypeTextCode = harmlessTypeTextCode.Replace(colorCodePropertie.Identifier, "");
            }

            // Center text if it should full centered, 
            // or if control key (~>-<~) given. But not if message is a control coded line
            if (centered || consoleTypeTextColorCode.Contains("~>-<~") && !wasControlCodeLine)
            {
                if (consoleTypeTextColorCode.Contains("~>-<~"))
                    consoleTypeTextColorCode = consoleTypeTextColorCode.Replace("~>-<~", "");

                message = harmlessTypeTextCode +
                          ConsoleUtils.AlignText(message, Console.WindowWidth - _lastHeaderLength, true);
            }


            // Message is line and was by consoleTypeTextColorCode given ->
            // Replace again or endless loop
            if (wasControlCodeLine)
                consoleTypeTextColorCode = harmlessTypeTextCode;

            // Append message
            message = $"{consoleTypeTextColorCode}{message}";


            // React to some special control codes
            bool printLineBottom = false;

            #region React to special control codes

            if (message.Contains("~-^-~")) // Line Top
            {
                PrintLine("-", "", consoleType);
                message = message.Replace("~-^-~", "");
            }
            if (message.Contains("~-v-~")) // Line bottom
            {
                printLineBottom = true;
                message = message.Replace("~-v-~", "");
            }

            #endregion

            // Append message to complete message
            writeMessage += message;

            // Add suffixs and possible linebreak
            writeMessage += suffix;

            if (messageHasLinebreak)
                writeMessage += "\n";

            // Replace reset controlcode with message defaultColor + resetControl
            string resetIdentifer = ConsoleUtils.GetColorCodePropertie(ColorCode.ResetColor).Identifier;
            if (writeMessage.Contains(resetIdentifer))
                writeMessage = writeMessage.Replace(resetIdentifer, $"{resetIdentifer}{harmlessTypeTextCode}");

            // Parse color and control codes
            writeMessage =
                ConsoleUtils.GenerateColoredString(ConsoleUtils.ColorCodeToConsoleColor(writeMessage), writeMessage);

            // Replace tab with spaces
            writeMessage = writeMessage.Replace("\t", "  ");

            // Write message
            Console.Write(writeMessage);

            // Print, if control code was given, bottom line
            if (printLineBottom)
                PrintLine("-", "", consoleType);

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
        ///     Prints a line that fits perfectly to the window width
        /// </summary>
        /// <param name="linePattern">The pattern for the line</param>
        /// <param name="colorCode">Extra color code for the line (optional)</param>
        /// <param name="consoleType">Should extra console Type used?</param>
        public static void PrintLine(string linePattern, string colorCode = "",
            ConsoleType consoleType = ConsoleType.Line)
        {
            string returnString = string.Empty;

            // Generate line
            for (var i = 0; i * linePattern.Length < Console.WindowWidth; i++)
                returnString += linePattern;

            // Optional cut line
            if (returnString.Length > Console.WindowWidth)
                returnString = returnString.Substring(0, Console.WindowWidth);

            if (consoleType != ConsoleType.Line)
                colorCode = "~!--!~" + colorCode;

            // Reset console colors
            Console.ResetColor();

            // Write line
            WriteLine(consoleType, colorCode + returnString);
        }
    }
}