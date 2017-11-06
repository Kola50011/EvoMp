using System;

namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties(ConsoleColor.White, (ConsoleColor)(-1))]
        Core,
        [ConsoleTypeProperties(ConsoleColor.Green, (ConsoleColor)(-1))]
        Info,
        [ConsoleTypeProperties(ConsoleColor.DarkYellow, ConsoleColor.White)]
        Warn,
        [ConsoleTypeProperties(ConsoleColor.Red, ConsoleColor.White)]
        Error,
        [ConsoleTypeProperties(ConsoleColor.DarkRed, ConsoleColor.White)]
        Fatal,
        [ConsoleTypeProperties(ConsoleColor.Gray, (ConsoleColor)(-1))]
        Note,
        [ConsoleTypeProperties(ConsoleColor.White, ConsoleColor.DarkCyan)]
        Debug,
        [ConsoleTypeProperties(ConsoleColor.Blue, ConsoleColor.White)]
        Database,
    }
}
