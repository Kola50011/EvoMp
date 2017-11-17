namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties("~#FFF~")] Core,
        [ConsoleTypeProperties("~#00FF00~")] Info,
        [ConsoleTypeProperties("~#ffa500~", "~#ffa500~~...~")] Warn,
        [ConsoleTypeProperties("~#ff3300~", "~#ff3300~~...~")] Error,
        [ConsoleTypeProperties("~_~~#FF0000~", "~#FFF~~_#B71C1C~~...~~-^-~~-v-~~>-<~")] Fatal,
        [ConsoleTypeProperties("~#999999~")] Note,
        [ConsoleTypeProperties("~#2E9AFE~", "~#FFF~~_#2E9AFE~")] Debug,
        [ConsoleTypeProperties("~#00ccff~", "", "DATA")] Database,
        [ConsoleTypeProperties("~#999999~", "", "----")] Line,
        [ConsoleTypeProperties("~#ff9672~", "~#fff~", "CONF")] Config,
        [ConsoleTypeProperties("~#999999~", "", "CON")] Console,
        [ConsoleTypeProperties("~#654d68~", "", "GTMP")] GtMp,
        [ConsoleTypeProperties("~#e1f585~", "")] Event,
        [ConsoleTypeProperties("~#7eb6b3~", "~#7eb6b3~", "CMD")] Command,

        /// <summary>
        ///     This type gives only the message to the console output.
        ///     No timestamp, no type text
        /// </summary>
        [ConsoleTypeProperties("")] Empty
    }
}