namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties("~#FFF~")] Core,
        [ConsoleTypeProperties("~#00FF00~")] Info,
        [ConsoleTypeProperties("~#ffa500~", "~#000~~_#FFCC80~~...~")] Warn,
        [ConsoleTypeProperties("~#ff3300~", "~#FFF~~_#E57373~~...~")] Error,
        [ConsoleTypeProperties("~_~~#FF0000~", "~#FFF~~_#B71C1C~~...~" + "~-^-~~-v-~" + "~>-<~")] Fatal, // ~-^-~~-v-~
        [ConsoleTypeProperties("~#999999~")] Note,
        [ConsoleTypeProperties("~#696969~", "~#696969~~_#fff~")] Debug,
        [ConsoleTypeProperties("~#00ccff~", "", "DATA")] Database,
        [ConsoleTypeProperties("~#999999~", "", "----")] Line,
        [ConsoleTypeProperties("~#ff9672~")] Config,

        /// <summary>
        ///     This type gives only the message to the console output.
        ///     So no timestamp, no type text
        /// </summary>
        [ConsoleTypeProperties("")] Empty
    }
}