using System;
using System.IO;
using System.Text;
using EvoMp.Core.Shared.Server;

namespace EvoMp.Core.ConsoleHandler.Server
{
    public class CustomTextWriter : StringWriter
    {
        private bool _lastWasInvalid;

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

            // Startup not completed -> return;
            if (!SharedEvents.StartUpCompleted)
                return;

            // Print Text as invalid console use.
            if (!gtMpMessage)
            {
                if (!_lastWasInvalid)
                    ConsoleOutput.WriteLine(ConsoleType.Warn, $"Use ConsoleOutput.* for writing to console!");
                _lastWasInvalid = true;
            }

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
