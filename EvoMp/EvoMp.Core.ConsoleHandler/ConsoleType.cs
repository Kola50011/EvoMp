using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    public enum ConsoleType
    {
        [ConsoleTypeProperties(ConsoleColor.White, ConsoleColor.DarkGray)]
        Core,
        [ConsoleTypeProperties(ConsoleColor.Green, ConsoleColor.DarkGray)]
        Info,
        [ConsoleTypeProperties(ConsoleColor.Yellow, ConsoleColor.DarkGray)]
        Warn,
        [ConsoleTypeProperties(ConsoleColor.Red, ConsoleColor.DarkGray)]
        Error,
        [ConsoleTypeProperties(ConsoleColor.DarkRed, ConsoleColor.White)]
        Fatal,
        [ConsoleTypeProperties(ConsoleColor.Gray, ConsoleColor.DarkGray)]
        Note,
        [ConsoleTypeProperties(ConsoleColor.Cyan, ConsoleColor.White)]
        Debug,
        [ConsoleTypeProperties(ConsoleColor.Blue, ConsoleColor.White)]
        Database,
    }
}
