using System;
using System.IO;
using System.Text;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public class CustomTextWriter : StringWriter
    {
        public override void WriteLine(string message)
        {
            WriteHandler(message);
        }

        public override void Write(string message)
        {
            WriteHandler(message);
        }

        private void WriteHandler(string message)
        {
            bool gtMpMessage = ConsoleUtils.IsGtmpConsoleMessage(message);

            // Print Text as invalid console use.
            if (!gtMpMessage)
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    "Use ConsoleOutput.* for writing to console!");

            // Remove GtMp console tags
            if (gtMpMessage)
                message = message.Substring(message.LastIndexOf(" | ", StringComparison.Ordinal) + 3);

            if (!ConsoleUtils.OriginalWriterInUse)
            {
                // Write console line
                string[] newLines = message.Split('\n');
                foreach (string line in newLines)
                    ConsoleOutput.WriteLine(gtMpMessage ? ConsoleType.GtMp : ConsoleType.ConsoleOutput, line);
            }

            // Clear string Writer
            StringBuilder stringBuilder = GetStringBuilder();
            stringBuilder.Remove(0, stringBuilder.Length);
        }
    }
}