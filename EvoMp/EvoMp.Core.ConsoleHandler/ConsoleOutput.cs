using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EvoMp.Core.ColorHandler;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleOutput
    {
        private static string _lastTimestamp = string.Empty;
        private static int _countSameTimestamp;
        private static int _lastHeaderLength;
        private static string _prefix = string.Empty;

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
            int maxMessageWidth = Console.WindowWidth - _lastHeaderLength - _prefix.Length;

            // LineTop identifier avalible -> line top as first
            if (message.Contains(ColorUtils.GetColorCodePropertie(ColorCode.LineTop).Identifier))
                message = ColorUtils.GetColorCodePropertie(ColorCode.LineTop).Identifier +
                          message.Replace(ColorUtils.GetColorCodePropertie(ColorCode.LineTop).Identifier, "");

            // LineBottom identifier avalible -> line bottom as last
            if (message.Contains(ColorUtils.GetColorCodePropertie(ColorCode.LineBottom).Identifier))
                message = message.Replace(ColorUtils.GetColorCodePropertie(ColorCode.LineBottom).Identifier, "") +
                          ColorUtils.GetColorCodePropertie(ColorCode.LineBottom).Identifier;

            // Message shorter then max -> return;
            if (message.Length < maxMessageWidth)
                return new[] {message};

            List<string> returnList = new List<string>();
            List<string> words = message.Split(' ').ToList();

            // Save to message variants
            string cleanMessage = ColorUtils.CleanUpColorCodes(message);
            string dirtyMessage = message;

            // No spaces -> just cut at length
            if (words.Count == 1)
            {
                // Run until dirtyMessage < maxMessageWidth
                while (true)
                {
                    // Compare step by step
                    for (int i = 0; i < dirtyMessage.Length; i++)
                        if (ColorUtils.CleanUpColorCodes(dirtyMessage.Substring(0, i)) ==
                            ColorUtils.CleanUpColorCodes(cleanMessage).Substring(0, maxMessageWidth))
                        {
                            returnList.Add(dirtyMessage.Substring(0, i));
                            dirtyMessage = dirtyMessage.Substring(0, i);
                            cleanMessage = cleanMessage.Substring(0, maxMessageWidth);
                            // Jump out of the current for
                            break;
                        }

                    if (ColorUtils.CleanUpColorCodes(dirtyMessage).Length <= maxMessageWidth)
                    {
                        returnList.Add(dirtyMessage);
                        break;
                    }
                }
                return returnList.ToArray();
            }

            // Stack words and get smallest match
            string currentMessage = string.Empty;
            //while (string.Join(" ", words.ToArray()).Length > maxMessageWidth && words.Count != 0)
            for (var i = 0; i < words.Count; i++)
            {
                // stack message
                currentMessage += words[i];

                // Last word -> break; 
                if (words.Count == i + 1)
                    continue;

                if (words.Count == i)
                    break;

                currentMessage += " "; // Add Space

                // Next word makes the string to long -> start new
                if (ColorUtils.CleanUpColorCodes(currentMessage + " " + words[i + 1]).Length >
                    maxMessageWidth)
                {
                    returnList.Add(currentMessage);
                    currentMessage = "";
                }
            }

            if (currentMessage.Length != 0)
                returnList.Add(currentMessage);

            return returnList.ToArray();
        }

        public static void WriteLine(ConsoleType consoleType, string message, bool noWordWrap = false)
        {
            // Now word wrap -> output & return;
            if (noWordWrap)
            {
                InternalWrite(consoleType, message + "\n");
                return;
            }

            // Parse linebreaks for clear output
            string[] messages = message.Trim().Split(new[] {"\n", "~n~"}, StringSplitOptions.RemoveEmptyEntries);

            // Cut messages to fit in the console
            for (int i = 0; i < messages.Length; i++)
            {
                // wrapp messages if they are to long for the console space
                string[] wrappedMessages = WordWrapMessage(messages[i]);
                for (int b = 0; b < wrappedMessages.Length; b++)
                {
                    bool firstMessageOfSet = i == 0 && b == 0;
                    bool lastMessageOfSet = i == messages.Length - 1 && b == wrappedMessages.Length - 1;
                    InternalWrite(consoleType, _prefix + wrappedMessages[b] + "\n", false, "", firstMessageOfSet,
                        lastMessageOfSet);
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
            string[] messages = text.Split(new[] {"\n", "~n~"}, StringSplitOptions.RemoveEmptyEntries);

            // No text -> return;
            if (!messages.Any())
                return;

            //Make each line the same length
            int longestTextLine = messages.OrderBy(s => s.Length).First().Length;
            for (int i = 0; i < messages.Length; i++)
            {
                // wrapp messages if they are to long for the console space
                string[] wrappedMessages = WordWrapMessage(messages[i]);
                for (int b = 0; b < wrappedMessages.Length; b++)
                {
                    bool firstMessageOfSet = i == 0 && b == 0;
                    bool lastMessageOfSet = i == messages.Length - 1 && b == wrappedMessages.Length - 1;
                    InternalWrite(consoleType,
                        _prefix + ConsoleUtils.AlignText(wrappedMessages[b], longestTextLine, true), true, "\n",
                        firstMessageOfSet, lastMessageOfSet);
                }
            }
        }


        /// <summary>
        ///     Appends the prefix between message and messsage head for
        ///     each console message after this.
        ///     Until ResetPrefix() called
        /// </summary>
        /// <param name="prefix">The Prefix between the messages</param>
        public static void AppendPrefix(string prefix)
        {
            _prefix += prefix;
        }

        /// <summary>
        /// Sets the prefix for each message.
        /// </summary>
        /// <param name="prefix">New prefix</param>
        public static void SetPrefix(string prefix)
        {
            _prefix = prefix;
        }

        /// <summary>
        /// Returns the current prefix.
        /// </summary>
        /// <returns>Current message prefix</returns>
        public static string GetPrefix()
        {
            return _prefix;
        }

        /// <summary>
        ///     Resets the given prefix
        /// </summary>
        public static void ResetPrefix()
        {
            _prefix = string.Empty;
        }

        /// <summary>
        ///     The internal write function.
        ///     Handles each write subfunction
        /// </summary>
        /// <param name="consoleType">ConsoleType</param>
        /// <param name="message">The message with color codes</param>
        /// <param name="centered">Should the text be centered?</param>
        /// <param name="suffix">Message suffix?</param>
        /// <param name="firstMessageOfSet">The first message of a bunch of splitted messages?</param>
        /// <param name="lastMessageOfSet">The last message of a bunch of splitted messages?</param>
        private static void InternalWrite(ConsoleType consoleType, string message, bool centered = false,
            string suffix = "", bool firstMessageOfSet = true, bool lastMessageOfSet = true)
        {
            // Message empty -> return;
            if (string.IsNullOrEmpty(message?.Replace("\n", "")))
                return;

            // ColorCodes contains invalid code -> message & return;
            List<string> colorCodes = ColorUtils.ParseColorCodesSimple(message);
            if (colorCodes == null)
            {
                WriteLine(ConsoleType.Warn,
                    "Not closed or opened color code in message: \n" +
                    $"~w~\"{message.Replace("~", @"\~").Trim()}\"~;~.\n" +
                    "Message will be ignored. ~#0000FF~Escape tildes by using \"\\\\~code\\\\~\"~;~!");
                return;
            }

            // Format message output
            string writeMessage = string.Empty;

            // Save the color codes if the message starts with any
            // Used for mutiline control codes
            string firstMessageColorCodes = "";
            foreach (string colorCode in colorCodes)
                if (message.StartsWith($"{firstMessageColorCodes}{colorCode}"))
                    firstMessageColorCodes += colorCode;

            //ConsoleUtils.ParseColorCodesSimple(message);

            bool wasControlCodeLine = false;
            bool messageHasLinebreak = false;

            int maxInnerLineLength = Console.WindowWidth - _lastHeaderLength;

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
                    timestamp = ColorUtils.DarkUpHexColors(timestamp, (float) 0.011 * _countSameTimestamp);
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
                _lastHeaderLength = ColorUtils.CleanUpColorCodes(writeMessage).Replace("\t", "  ").Length;
                maxInnerLineLength = Console.WindowWidth - _lastHeaderLength;

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
                    {
                        int colorCodeLength = message.Length - ColorUtils.CleanUpColorCodes(message).Length;
                        string colorCode = message.Substring(0, colorCodeLength);
                        message = colorCode + message.Substring(_lastHeaderLength);
                    }
                }
            }

            #endregion //Prepare Head and lines

            // Get message color from type
            string consoleTypeTextColorCode = typeProperties.ColorCodeText;


            // Filter all control codes from the typetextcode to use it as reset code
            string harmlessTypeTextCode = consoleTypeTextColorCode;
            foreach (ColorCode colorCode in Enum.GetValues(typeof(ColorCode)))
            {
                ColorCodePropertie colorCodePropertie = ColorUtils.GetColorCodePropertie(colorCode);
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
                          ConsoleUtils.AlignText(message, maxInnerLineLength, true);
            }

            // Message is line and was by consoleTypeTextColorCode given ->
            // Replace again or endless loop
            if (wasControlCodeLine)
                consoleTypeTextColorCode = harmlessTypeTextCode;

            // Append message
            message = $"{consoleTypeTextColorCode}{message}";


            // React to some special control codes
            bool printLineBottom = false;

            // React to special control codes

            // Line Top
            if (firstMessageOfSet)
                if (message.Contains(ColorUtils.GetColorCodePropertie(ColorCode.LineTop).Identifier))
                    PrintLine("-", firstMessageColorCodes, consoleType);

            // Line bottom
            if (lastMessageOfSet)
                if (message.Contains(ColorUtils.GetColorCodePropertie(ColorCode.LineBottom).Identifier))
                    printLineBottom = true;

            // Append message to complete message
            writeMessage += message;

            // Add suffixs and possible linebreak
            writeMessage += suffix;

            if (messageHasLinebreak)
                writeMessage += "\n";

            // Replace reset controlcode with message defaultColor + resetControl
            string resetIdentifer = ColorUtils.GetColorCodePropertie(ColorCode.ResetColor).Identifier;
            if (writeMessage.Contains(resetIdentifer))
                writeMessage = writeMessage.Replace(resetIdentifer,
                    $"{resetIdentifer}{harmlessTypeTextCode}");

            // Parse color and control codes
            writeMessage = ColorUtils.GenerateColoredString(writeMessage);

            // Replace tab with spaces
            writeMessage = writeMessage.Replace("\t", "  ");

            // Write message
            Console.SetOut(ConsoleHandler.OriginalTextWriter);
            Console.Write(writeMessage);
            Console.SetOut(ConsoleHandler.NewTextWriter);

            // Print, if control code was given, bottom line
            if (printLineBottom)
                PrintLine("-", "", consoleType);

            // Reset console colors
            Console.SetOut(ConsoleHandler.OriginalTextWriter);
            Console.ResetColor();
            Console.SetOut(ConsoleHandler.NewTextWriter);
        }

        public static void WriteException(string message)
        {
            Exception exception = new Exception(message);
            message = $"Exception: ~o~{exception.Message}~;~\n" +
                      $"at: ~o~{exception.Source}~;~\n" +
                      $"{" ".PadRight(60, '-')}\n" +
                      $"{exception.StackTrace}";
            WriteLine(ConsoleType.Fatal, message);
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
            string returnString = colorCode;

            // Generate line
            for (var i = 0; i * linePattern.Length < Console.WindowWidth; i++)
                returnString += linePattern;

            // Optional cut line
            if (returnString.Length > Console.WindowWidth)
                returnString = returnString.Substring(0, Console.WindowWidth);

            if (consoleType != ConsoleType.Line)
                returnString = "~!--!~" + returnString;

            // Reset console colors
            Console.SetOut(ConsoleHandler.OriginalTextWriter);
            Console.ResetColor();
            Console.SetOut(ConsoleHandler.NewTextWriter);

            // Write line
            WriteLine(consoleType, returnString, true);
        }
    }
}