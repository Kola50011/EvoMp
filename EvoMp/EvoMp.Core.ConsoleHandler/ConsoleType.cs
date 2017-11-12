namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties("~#FFF~")] Core,
        [ConsoleTypeProperties("~#00FF00~")] Info,
        [ConsoleTypeProperties("~#ffa500~", "~#21201e~~_#fa984a~~...~")] Warn,
        [ConsoleTypeProperties("~#ff3300~", "~#21201e~~_#d23c3c~~...~")] Error,
        [ConsoleTypeProperties("~_~~#FF0000~", "~#FFF~~_#B71C1C~~...~~-^-~~-v-~~>-<~")] Fatal,
        [ConsoleTypeProperties("~#999999~")] Note,
        [ConsoleTypeProperties("~#696969~", "~#FFF~~_#2E9AFE~~-^-~~-v-~~>-<~")] Debug,
        [ConsoleTypeProperties("~#00ccff~", "", "DATA")] Database,
        [ConsoleTypeProperties("~#999999~", "", "----")] Line,
        [ConsoleTypeProperties("~#ff9672~", "~#fff~", "CONF")] Config,

        /// <summary>
        ///     This type gives only the message to the console output.
        ///     So no timestamp, no type text
        /// </summary>
        [ConsoleTypeProperties("")] Empty
    }
}