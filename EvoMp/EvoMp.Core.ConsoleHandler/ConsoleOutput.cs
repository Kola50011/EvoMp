using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvoMp.Core.ColorHandler;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleOutput
    {
        internal static string LastTimestamp = String.Empty;
        internal static int CountSameTimestamp = -1;
        internal static int LastHeaderLength;
        private static int _lastConsoleTop;
        private static string _prefix = String.Empty;
        internal static int PrefixLength = 0;


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
            NewTextWriter = new StringWriter();
            OriginalTextWriter = Console.Out;
            //Console.SetError(Console.Out);

            Console.SetOut(NewTextWriter);

            // Start thread to fetch old ConsoleOutputs.
            new Thread(SystemConsoleWatcher).Start();
        }

        private static void SystemConsoleWatcher()
        {
            DateTime lastWarnSend = DateTime.MinValue;
            const int warnEachMs = 5 * 1000; // 5 seconds
            while (true)
            {
                // Wait 100ms.
                Thread.Sleep(100);

                // Text didn't canged -> continue;
                if (NewTextWriter.ToString().Trim() == "")
                    continue;

                string message = NewTextWriter.ToString();
                bool gtMpMessage = ConsoleUtils.IsGtmpConsoleMessage(message);

                // Print Text as invalid console use.
                if (!gtMpMessage && lastWarnSend.AddMilliseconds(warnEachMs) < DateTime.Now)
                {
                    WriteLine(ConsoleType.Warn,
                        "Use ConsoleOutput.* for console output. " + "Other console outputs get catched.");
                    lastWarnSend = DateTime.Now;
                }

                // Remove GtMp console tags
                if (gtMpMessage)
                    message = message.Substring(message.LastIndexOf(" | ", StringComparison.Ordinal) + 3);

                // Write console line
                string[] newLines = message.Split('\n');
                foreach (string line in newLines)
                    WriteLine(gtMpMessage ? ConsoleType.GtMp : ConsoleType.ConsoleOutput, line);

                // Clear string Writer
                StringBuilder stringBuilder = NewTextWriter.GetStringBuilder();
                stringBuilder.Remove(0, stringBuilder.Length);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        ///     Writes a empty line
        /// </summary>
        public static void WriteEmptyLine()
        {
            Console.WriteLine(new string(' ', ConsoleHandler.WindowWidth * 3));
        }

        /// <summary>
        ///     Splits a long colored message into a few messages wich fits in the console.
        /// </summary>
        /// <param name="message">The long colored message wich should be splitten</param>
        /// <returns></returns>
        private static string[] WordWrapMessage(string message)
        {
            int maxMessageWidth = ConsoleHandler.WindowWidth - LastHeaderLength - ColorUtils.CleanUp(_prefix).Length;

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
            string cleanMessage = ColorUtils.CleanUp(message);
            string dirtyMessage = message;

            // No spaces -> just cut at length
            if (words.Count == 1)
            {
                // Run until dirtyMessage < maxMessageWidth
                while (true)
                {
                    // Compare step by step
                    for (int i = 0; i < dirtyMessage.Length; i++)
                        if (ColorUtils.CleanUp(dirtyMessage.Substring(0, i)) ==
                            ColorUtils.CleanUp(cleanMessage).Substring(0, maxMessageWidth))
                        {
                            returnList.Add(dirtyMessage.Substring(0, i));
                            dirtyMessage = dirtyMessage.Substring(0, i);
                            cleanMessage = cleanMessage.Substring(0, maxMessageWidth);
                            // Jump out of the current for
                            break;
                        }

                    if (ColorUtils.CleanUp(dirtyMessage).Length <= maxMessageWidth)
                    {
                        returnList.Add(dirtyMessage);
                        break;
                    }
                }
                return returnList.ToArray();
            }

            // Stack words and get smallest match
            string currentMessage = String.Empty;
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
                if (ColorUtils.CleanUp(currentMessage + " " + words[i + 1]).Length >
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
            string[] messages = message.Split(new[] {"\n", "~n~"}, StringSplitOptions.RemoveEmptyEntries);

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
            _prefix = String.Empty;
            PrefixLength = ColorUtils.CleanUp(_prefix).Length;
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
            if (String.IsNullOrEmpty(message?.Replace("\n", "")))
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
            string writeMessage = String.Empty;

            // Save the color codes if the message starts with any
            // Used for mutiline control codes
            string firstMessageColorCodes = "";
            foreach (string colorCode in colorCodes)
                if (message.StartsWith($"{firstMessageColorCodes}{colorCode}"))
                    firstMessageColorCodes += colorCode;

            //ConsoleUtils.ParseColorCodesSimple(message);

            bool wasControlCodeLine = false;
            bool messageHasLinebreak = false;

            int maxInnerLineLength = ConsoleHandler.WindowWidth - LastHeaderLength - PrefixLength;

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
                string timestamp = $"~#FFFFFF~{DateTime.Now.ToString(CultureInfo.CurrentUICulture)}";

                // Timestamp didn't changed -> dark it up
                if (LastTimestamp != timestamp)
                    CountSameTimestamp = -1;

                LastTimestamp = timestamp;
                CountSameTimestamp++;
                float multipler = (float) 0.011 * CountSameTimestamp;
                timestamp = ColorUtils.DarkUpHexColors(timestamp, multipler < 0.9 ? multipler : (float) 0.9);


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
                        int colorCodeLength = message.Length - ColorUtils.CleanUp(message).Length;
                        string colorCode = message.Substring(0, colorCodeLength);
                        message = colorCode + message.Substring(LastHeaderLength);
                    }
                }
            }

            #endregion //Prepare Head and lines

            // Get message color from type
            string consoleTypeTextColorCode = typeProperties.TextCode;


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

            string fillUpString =
                "".PadRight(ConsoleHandler.WindowWidth - ColorUtils.CleanUp(writeMessage + suffix).Replace("\n", "").Length);

            // Add suffixs and possible linebreak
            writeMessage += fillUpString + suffix;

            if (messageHasLinebreak)
                writeMessage += "\n";

            // Replace reset controlcode with message defaultColor + resetControl
            string resetIdentifer = ColorUtils.GetColorCodePropertie(ColorCode.ResetColor).Identifier;
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
            const char horizontalBar = '─';
            //const char bottomBar = '_';
            //const char topBar = '‾';

            ConsoleUtils.SafeSystemConsoleUse(() =>
            {
                if (simpeWriteLine)
                {
                    Console.WriteLine(ColorUtils.ColorizeAscii(message));
                    return;
                }

                // Cleanup & write
                if (Console.BufferHeight - ConsoleHandler.WindowHeight > 0)
                {
                    // Last pos, clear line, write message & save top
                    Console.SetCursorPosition(0, _lastConsoleTop);
                    Console.Write("".PadRight(ConsoleHandler.WindowWidth));
                    //if(_lastConsoleTop + 1 < ConsoleHandler.WindowWidth)
                    //Console.SetCursorPosition(0, _lastConsoleTop + 1);
                    //Console.Write("".PadRight(ConsoleHandler.WindowWidth));
                }
                Console.SetCursorPosition(0, _lastConsoleTop);

                Console.Write(ColorUtils.ColorizeAscii(message));

                // Remember cursor pos
                _lastConsoleTop = Console.CursorTop;

                // Make buffer free for input box
                if (Console.CursorTop + 3 > Console.BufferHeight)
                    Console.BufferHeight++;

                WriteInput();

               // Thread.Sleep(50); // Debug

                void WriteInput()
                {
                    ConsoleTypeProperties cInProps = ConsoleUtils.GetConsoleTypeProperties(ConsoleType.ConsoleInput);
                    float multipler = (float) 0.011 * CountSameTimestamp;
                    multipler = multipler < 0.9 ? multipler : (float) 0.9;

                    string lineHead =
                        $"~w~ │{String.Empty.PadRight(ConsoleUtils.LongestTypeLength + 2, horizontalBar)}~;~~w~│ ";
                    int lineWidth = ConsoleHandler.WindowWidth - LastHeaderLength - ColorUtils.CleanUp(_prefix).Length;


                    // Empty line
                    string timestampStr = ColorUtils.DarkUpHexColors(LastTimestamp, multipler);
                    string emptyLine = $"{timestampStr}{lineHead.Replace(horizontalBar, ' ')}{"".PadRight(lineWidth)}";

                    // Top Line
                    string topLine = $"{timestampStr}{lineHead}{"".PadRight(lineWidth, horizontalBar)}";

                    // Middle (input) line
                    string inputLine =
                        $"{timestampStr}~w~ │{cInProps.TypeText(' ', " ")} ~;~~w~│ > {ConsoleInput.CurrentConsoleInput}";

                    // Input cursor position & fill up input
                    ConsoleUtils.InputCursorLeftStart = ColorUtils.CleanUp(inputLine).Length - ConsoleInput.CurrentConsoleInput.Length;
                    inputLine = inputLine + "".PadRight(ConsoleHandler.WindowWidth -
                                                        ColorUtils.CleanUp(inputLine).Length);

                    // Footer line
                    string footerLine = $"{timestampStr}{lineHead}{"".PadRight(lineWidth, horizontalBar)}";

                    // Set cursor left.
                    Console.CursorLeft = 0;

                    // Write lines
                    Console.Write(ColorUtils.ColorizeAscii($"{topLine}\n"));
                    int cursorInputTop = Console.CursorTop;
                    Console.Write(ColorUtils.ColorizeAscii($"{inputLine}\n"));
                    Console.Write(ColorUtils.ColorizeAscii($"{footerLine}"));


                    // Cursor inside input
                    Console.CursorTop = cursorInputTop;
                    Console.CursorLeft = ConsoleUtils.InputCursorLeftStart + ConsoleInput.CurrentConsoleInput.Length;
                }
            });
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
            for (var i = 0; i * linePattern.Length < ConsoleHandler.WindowWidth; i++)
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