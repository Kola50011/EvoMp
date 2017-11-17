using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EvoMp.Core.ConsoleHandler
{
    public static class ConsoleHandler
    {
        public static TextWriter OriginalTextWriter;
        public static StringWriter NewTextWriter;

        public static void PrepareConsole()
        {
            IntPtr consoleHandle = ConsoleUtils.GetStdHandle(-11);

            // Modify Console for color codes.
            ConsoleUtils.GetConsoleMode(consoleHandle, out int currentMode);
            ConsoleUtils.SetConsoleMode(consoleHandle, currentMode | 0x0004);

            // Set console size fixed
            int height = Math.Min(Console.LargestWindowHeight, 70);
            int width = Math.Min(Console.LargestWindowWidth, 150);
            ConsoleUtils.SetConsoleFixedSize(height, width);

            // Bind original Console.Out
            NewTextWriter = new StringWriter();
            OriginalTextWriter = Console.Out;
            Console.SetOut(NewTextWriter);

            // Start thread to fetch old ConsoleOutputs.
            new Thread(() =>
            {
                DateTime lastWarnSend = DateTime.MinValue;
                const int warnEachMs = 5 * 1000; // 5 seconds
                while (true)
                {
                    // Wait 10ms.
                    Thread.Sleep(10);

                    // Text didn't canged -> continue;
                    if (NewTextWriter.ToString() == "")
                        continue;

                    string message = NewTextWriter.ToString().Trim();
                    bool gtMpMessage = IsGtmpConsoleMessage(message);

                    // Print Text as invalid console use.
                    if (!gtMpMessage && lastWarnSend.AddMilliseconds(warnEachMs) < DateTime.Now)
                    {
                        ConsoleOutput.WriteLine(ConsoleType.Warn,
                            "Use ConsoleOutput.* for console output. " +
                            "Other console outputs get catched.");
                        lastWarnSend = DateTime.Now;
                    }

                    // Remove GtMp console tags
                    if (gtMpMessage)
                        message = message.Substring(message.LastIndexOf(" | ", StringComparison.Ordinal) + 3);
                        
                    // Write console line
                    string[] newLines = message.Split('\n');
                    foreach (string line in newLines)
                        ConsoleOutput.WriteLine(gtMpMessage ? ConsoleType.GtMp : ConsoleType.Console,
                            line);

                    // Clear string Writer
                    StringBuilder stringBuilder = NewTextWriter.GetStringBuilder();
                    stringBuilder.Remove(0, stringBuilder.Length);
                }
                // ReSharper disable once FunctionNeverReturns
            }).Start();
        }

        /// <summary>
        /// Checks if a System.Console.* Message is a GtMp Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static bool IsGtmpConsoleMessage(string message)
        {
            string[] gtmpConsoleParts = { " | Debug | GameServer | ",
                " |  Info | Program |",
                " |  Info | GameServer |"};

            return gtmpConsoleParts.Any(message.Contains);
        }
    }
}