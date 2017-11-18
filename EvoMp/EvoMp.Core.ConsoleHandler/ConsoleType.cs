namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties("~#FFF~", "Core")] Core,
        [ConsoleTypeProperties("~#00FF00~", "Info")] Info,
        [ConsoleTypeProperties("~#ffa500~", "Warn", "~#ffa500~~...~")] Warn,
        [ConsoleTypeProperties("~#ff3300~", "Error", "~#ff3300~~...~")] Error,
        [ConsoleTypeProperties("~_~~#FF0000~", "Fatal", "~#FFF~~_#B71C1C~~...~~-^-~~-v-~~>-<~")] Fatal,
        [ConsoleTypeProperties("~#999999~", "Note")] Note,
        [ConsoleTypeProperties("~#2E9AFE~", "Debug", "~#FFF~~_#2E9AFE~")] Debug,
        [ConsoleTypeProperties("~#00ccff~", "DATA")] Database,
        [ConsoleTypeProperties("~#999999~", "----")] Line,
        [ConsoleTypeProperties("~#ff9672~", "CONF")] Config,
        [ConsoleTypeProperties("~#654d68~", "GTMP")] GtMp,
        [ConsoleTypeProperties("~#e1f585~", "Event")] Event,
        [ConsoleTypeProperties("~#7eb6b3~", "CMD")] Command,
        [ConsoleTypeProperties("~#FFF~~_#2f5776~", "CCMD")] ConsoleCommand,
        [ConsoleTypeProperties("~#FFF~~_#2f5776~", "COUT")] ConsoleOutput,
        [ConsoleTypeProperties("~#FFF~~_#2f5776~", "CIN")] ConsoleInput,
        [ConsoleTypeProperties("~#009cff~", "Help", "~#009cff~")] Help,

        /// <summary>
        ///     This type gives only the message to the console output.
        ///     No timestamp, no type text
        /// </summary>
        [ConsoleTypeProperties("", "")] Empty
    }
}