using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    public enum GtMpColorCode
    {
        [GtMpColorCodeProperties("~r~", ConsoleColor.Red)]
        Red,
        [GtMpColorCodeProperties("~b~", ConsoleColor.Blue)]
        Blue,
        [GtMpColorCodeProperties("~g~", ConsoleColor.Green)]
        Green,
        [GtMpColorCodeProperties("~y~", ConsoleColor.Yellow)]
        Yellow,
        [GtMpColorCodeProperties("~p~", ConsoleColor.DarkMagenta)]
        Purple,
        [GtMpColorCodeProperties("~q~", ConsoleColor.Magenta)]
        Pink,
        [GtMpColorCodeProperties("~o~", ConsoleColor.DarkYellow)]
        Orange,
        [GtMpColorCodeProperties("~c~", ConsoleColor.Gray)]
        Grey,
        [GtMpColorCodeProperties("~m~", ConsoleColor.DarkGray)]
        DarkerGrey,
        [GtMpColorCodeProperties("~u~", ConsoleColor.Black)]
        Black,
        [GtMpColorCodeProperties("~n~", (ConsoleColor)99)]
        NewLine,
        [GtMpColorCodeProperties("~s~", (ConsoleColor)999)]
        DefaultWhite,
        [GtMpColorCodeProperties("~w~", ConsoleColor.White)]
        White,
        [GtMpColorCodeProperties("~h~", (ConsoleColor)9999)]
        BoldText,
    }
}
