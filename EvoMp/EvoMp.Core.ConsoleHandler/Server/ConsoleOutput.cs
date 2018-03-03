using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using EvoMp.Core.ColorHandler.Server;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public static class ConsoleOutput
    {
        internal static string LastTimestamp = string.Empty;
        internal static int CountSameTimestamp = -1;
        internal static int LastHeaderLength;
        private static int _lastConsoleTop;
        private static string _prefix = string.Empty;
        internal static int PrefixLength;


        public static TextWriter OriginalTextWriter;
        public static StringWriter NewTextWriter;

        /// <summary>
        ///     Prepares the ConsoleOutput.
        ///     Mostly setup fetch other console inputs.
        /// </summary>
        internal static void PrepareConsoleOutput()
        {
            ConsoleUtils.GetLengthOfLongestConsoleType();
            // Bind original Console.Out
            NewTextWriter = new CustomTextWriter();
            OriginalTextWriter = Console.Out;
            //Console.SetError(Console.Out);

            Console.SetOut(NewTextWriter);
        }

        /// <summary>
        ///     Splits a long colored message into a few messages wich fits in the console.
        /// </summary>
        /// <param name="message">The long colored message wich should be splitten</param>
        /// <returns></returns>
        private static string[] WordWrapMessage(string message)
        {
            var maxMessageWidth = ConsoleHandler.WindowWidth - LastHeaderLength - ColorUtils.CleanUp(_prefix).Length;

            // InsertLineAbove identifier avalible -> line top as first
            if (message.Contains(ColorUtils.GetColorCodeProperty(ColorCode.InsertLineAbove).Identifier))
                message = ColorUtils.GetColorCodeProperty(ColorCode.InsertLineAbove).Identifier +
                          message.Replace(ColorUtils.GetColorCodeProperty(ColorCode.InsertLineAbove).Identifier, "");

            // InsertLineBelow identifier avalible -> line bottom as last
            if (message.Contains(ColorUtils.GetColorCodeProperty(ColorCode.InsertLineBelow).Identifier))
                message = message.Replace(ColorUtils.GetColorCodeProperty(ColorCode.InsertLineBelow).Identifier, "") +
                          ColorUtils.GetColorCodeProperty(ColorCode.InsertLineBelow).Identifier;

            // Message shorter then max -> return;
            if (message.Length < maxMessageWidth)
                return new[] {message};

            var returnList = new List<string>();

            while (message.Length > maxMessageWidth)
            {
                var space = message.LastIndexOf(" ", Math.Max(Math.Min(maxMessageWidth, message.Length), 0),
                    StringComparison.Ordinal);
                if (space == -1)
                {
                    returnList.Add(message.Substring(0, Math.Max(Math.Min(maxMessageWidth, message.Length), 0)));
                    message = message.Substring(Math.Max(Math.Min(maxMessageWidth, message.Length), 0)).Trim();
                }
                else
                {
                    returnList.Add(message.Substring(0, space));
                    message = message.Substring(space).Trim();
                }
            }

            returnList.Add(message);

            return returnList.ToArray();
        }

        public static void WriteLine(ConsoleType consoleType, string message, bool noWordWrap = false)
        {
            // No word wrap -> output & return;
            if (noWordWrap)
            {
                InternalWrite(consoleType, message + "\n");
                return;
            }

            // Parse linebreaks for clear output
            var messages = message.Split(new[] {"\n", "~n~"}, StringSplitOptions.RemoveEmptyEntries);
            var messageStartColorCode = "";

            // Search for message starting color code. Used to add same color code to splitted lines
            if (messages.Any())
            {
                var messageColorCodes = ColorUtils.ParseColorCodesSimple(messages[0]);
                if (messageColorCodes.Any())
                    messageStartColorCode = "~" + messageColorCodes[0] + "~";
            }

            // Cut messages to fit in the console
            for (var i = 0; i < messages.Length; i++)
            {
                // wrap messages if they are too long for the console space
                var wrappedMessages = WordWrapMessage(messages[i]);
                for (var b = 0; b < wrappedMessages.Length; b++)
                {
                    var firstMessageOfSet = i == 0 && b == 0;
                    var lastMessageOfSet = i == messages.Length - 1 && b == wrappedMessages.Length - 1;
                    InternalWrite(consoleType, messageStartColorCode + _prefix + wrappedMessages[b] + "\n", false, "",
                        firstMessageOfSet,
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
            var messages = text.Split(new[] {"\n", "~n~"}, StringSplitOptions.RemoveEmptyEntries);

            // No text -> return;
            if (!messages.Any())
                return;

            //Make each line the same length
            var longestTextLine = messages.OrderBy(s => s.Length).First().Length;
            for (var i = 0; i < messages.Length; i++)
            {
                // wrapp messages if they are to long for the console space
                var wrappedMessages = WordWrapMessage(messages[i]);
                for (var b = 0; b < wrappedMessages.Length; b++)
                {
                    var firstMessageOfSet = i == 0 && b == 0;
                    var lastMessageOfSet = i == messages.Length - 1 && b == wrappedMessages.Length - 1;
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
            PrefixLength = ColorUtils.CleanUp(_prefix).Length;
        }

        /// <summary>
        ///     Sets the prefix for each message.
        /// </summary>
        /// <param name="prefix">New prefix</param>
        public static void SetPrefix(string prefix)
        {
            _prefix = prefix;
            PrefixLength = ColorUtils.CleanUp(_prefix).Length;
        }

        /// <summary>
        ///     Returns the current prefix.
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
            PrefixLength = 0;
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

            message = message.Replace("\r\n", "\n");

            var colorCodes = ColorUtils.ParseColorCodesSimple(message);

            // Format message output
            var writeMessage = string.Empty;

            // Save the color codes if the message starts with any
            // Used for mutiline control codes
            var firstMessageColorCodes = "";
            foreach (var colorCode in colorCodes)
                if (message.StartsWith($"{firstMessageColorCodes}{colorCode}"))
                    firstMessageColorCodes += colorCode;

            //ConsoleUtils.ParseColorCodesSimple(message);

            var wasControlCodeLine = false;
            var messageHasLinebreak = false;

            var maxInnerLineLength = ConsoleHandler.WindowWidth - LastHeaderLength - PrefixLength;

            // Prepare message.
            if (message.EndsWith("\n"))
            {
                messageHasLinebreak = true;
                message = message.Substring(0, message.Length - "\n".Length);
            }

            message = message.Replace("\t", "  ");

            // Get consoleType properties & parse message colors
            var typeProperties = ConsoleUtils.GetConsoleTypeProperties(consoleType);

            #region Prepare Head and lines

            if (consoleType != ConsoleType.Empty)
            {
                var timestamp = $"~#FFFFFF~{DateTime.Now.ToString(CultureInfo.CurrentUICulture)}";

                // Timestamp didn't changed -> dark it up
                if (LastTimestamp != timestamp)
                    CountSameTimestamp = -1;

                LastTimestamp = timestamp;
                CountSameTimestamp++;
                var multiplier = (float) 0.011 * CountSameTimestamp;
                timestamp = ColorUtils.DarkUpHexColors(timestamp, multiplier < 0.9 ? multiplier : (float) 0.9);


                // Write log type information
                writeMessage =
                    $"{timestamp}~w~ │{typeProperties.TypeText(' ', " ")} ~;~~w~│ ";

                // Save header length for calculation
                LastHeaderLength = ColorUtils.CleanUp(writeMessage).Replace("\t", "  ").Length;
                maxInnerLineLength = ConsoleHandler.WindowWidth - LastHeaderLength - PrefixLength;

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

                    if (LastHeaderLength < message.Length)
                    {
                        var colorCodeLength = message.Length - ColorUtils.CleanUp(message).Length;
                        var colorCode = message.Substring(0, colorCodeLength);
                        message = colorCode + message.Substring(LastHeaderLength);
                    }
                }
            }

            #endregion //Prepare Head and lines

            // Get message color from type
            var consoleTypeTextColorCode = typeProperties.TextCode;


            // Filter all control codes from the typetextcode to use it as reset code
            var harmlessTypeTextCode = consoleTypeTextColorCode;
            foreach (ColorCode colorCode in Enum.GetValues(typeof(ColorCode)))
            {
                var colorCodeProperty = ColorUtils.GetColorCodeProperty(colorCode);
                if (colorCodeProperty.HasSpecialLogic)
                    harmlessTypeTextCode = harmlessTypeTextCode.Replace(colorCodeProperty.Identifier, "");
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
            message = $"{consoleTypeTextColorCode}{message}~|~";


            // React to some special control codes
            var printLineBottom = false;

            // Line Above
            if (firstMessageOfSet)
                if (message.Contains(ColorUtils.GetColorCodeProperty(ColorCode.InsertLineAbove).Identifier))
                    PrintLine("-", firstMessageColorCodes, consoleType);

            // Line Below
            if (lastMessageOfSet)
                if (message.Contains(ColorUtils.GetColorCodeProperty(ColorCode.InsertLineBelow).Identifier))
                    printLineBottom = true;

            // Append message to complete message
            writeMessage += message;

            var fillUpLength = ConsoleHandler.WindowWidth -
                               ColorUtils.CleanUp(writeMessage + suffix).Replace("\n", "").Length;
            var fillUpString = "".PadRight(fillUpLength > 0 ? fillUpLength : 0);

            // Add suffixs and possible linebreak
            writeMessage += "~;~" + fillUpString + suffix;

            if (messageHasLinebreak)
                writeMessage += "\n";

            // Replace reset controlcode with message defaultColor + resetControl
            var resetIdentifer = ColorUtils.GetColorCodeProperty(ColorCode.ResetColor).Identifier;
            if (writeMessage.Contains(resetIdentifer))
                writeMessage = writeMessage.Replace(resetIdentifer,
                    $"{resetIdentifer}{harmlessTypeTextCode}");

            // Parse color and control codes
            FinalConsoleWrite(writeMessage);

            // Print, if control code was given, bottom line
            if (printLineBottom)
                PrintLine("-", "", consoleType);

            //ConsoleUtils.ResetColor();
        }

        /// <summary>
        ///     Writes the message final to the console
        /// </summary>
        /// <param name="message">Message wich should be written</param>
        /// <param name="simpeWriteLine">MEssage should only be printed with a simple Console.WriteLine?</param>
        public static void FinalConsoleWrite(string message, bool simpeWriteLine = false)
        {
            WriteMessage();
            WriteInput();

            void WriteMessage()
            {
                ConsoleUtils.SafeSystemConsoleUse(() =>
                {
                    if (simpeWriteLine)
                    {
                        Console.WriteLine(ColorUtils.ColorizeAscii(message));
                        return;
                    }

                    // left and top must be positive and below the buffer width.
                    //var setLeft = 0;
                    var setTop = _lastConsoleTop;
                    Console.WriteLine($"{setTop}");
                    Console.CursorLeft = 0;
                    if (setTop >= 0 && setTop < Console.BufferHeight) //Console.CursorTop = setTop;
                        Console.SetCursorPosition(0, setTop);
                    //if (setLeft >= 0 && setLeft < Console.BufferWidth) Console.CursorLeft = setLeft;

                    Console.Write(ColorUtils.ColorizeAscii(message));

                    // Remember cursor pos
                    _lastConsoleTop = Console.CursorTop;
#if __MonoCS__
                    if (_lastConsoleTop < Console.BufferHeight - 1)
                        _lastConsoleTop -= 1;
#else
                    if (_lastConsoleTop == Console.BufferHeight - 1)
                        _lastConsoleTop = Console.BufferHeight - 2;

                    // Make positive to avoid errors
                    if (_lastConsoleTop < 0) _lastConsoleTop = 0;
                    // Make buffer free for input box
                    if (Console.CursorTop + 3 > Console.BufferHeight)
                        Console.BufferHeight++;
#endif
                });
            }

            void WriteInput()
            {
                var cInProps = ConsoleUtils.GetConsoleTypeProperties(ConsoleType.ConsoleInput);
                var multipler = (float) 0.011 * CountSameTimestamp;
                multipler = multipler < 0.9 ? multipler : (float) 0.9;

                var timestampStr = ColorUtils.DarkUpHexColors(LastTimestamp, multipler);

                // Middle (input) line
                var inputLine =
                    $"{timestampStr}~w~ │{cInProps.TypeText(' ', " ")} ~;~~w~│ > {ConsoleInput.CurrentConsoleInput}";

                // Input cursor position & fill up input
                ConsoleUtils.InputCursorLeftStart =
                    ColorUtils.CleanUp(inputLine).Length - ConsoleInput.CurrentConsoleInput.Length;
                inputLine = inputLine + "".PadRight(ConsoleHandler.WindowWidth -
                                                    ColorUtils.CleanUp(inputLine).Length);
                ConsoleUtils.SafeSystemConsoleUse(() =>
                {
                    // Set cursor left.
                    Console.CursorLeft = 0;
                    var cursorInputTop = Console.CursorTop;
                    Console.Write(ColorUtils.ColorizeAscii($"{inputLine}\n"));
#if __MonoCS__
                    cursorInputTop -= 1;
                    _lastConsoleTop
 -= 1;
#endif
                    Console.CursorTop = cursorInputTop;
                    // Cursor inside input
                    if (Console.CursorTop == Console.BufferHeight - 1)
                        Console.CursorTop = Console.BufferHeight - 2;
                    Console.CursorLeft = ConsoleUtils.InputCursorLeftStart + ConsoleInput.CurrentConsoleInput.Length;
                });
            }

            //Thread.Sleep(50); // Debug
        }


        public static void WriteException(string message)
        {
            var exception = new Exception(message);
            message = $"Exception: ~o~{exception.Message}~;~\n" +
                      $"at: ~o~{exception.Source}~;~\n" +
                      $"{" ".PadRight(60, '-')}\n" +
                      $"{exception.StackTrace}";
            WriteLine(ConsoleType.Fatal, message);
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
            var returnString = colorCode;

            // Generate line
            for (var i = 0;
                i * linePattern.Length < ConsoleHandler.WindowWidth;
                i++)
                returnString += linePattern;

            // Optional cut line
            if (returnString.Length > ConsoleHandler.WindowWidth)
                returnString = returnString.Substring(0, ConsoleHandler.WindowWidth);
            if (consoleType != ConsoleType.Line)
                returnString = "~!--!~" + returnString;
            ConsoleUtils.ResetColor();

            // Write line
            WriteLine(consoleType, returnString, true);
        }
    }
}
