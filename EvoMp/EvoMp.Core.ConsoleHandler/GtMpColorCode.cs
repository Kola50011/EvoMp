using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    public enum GtMpColorCode
    {
        [GtMpColorCodePropertie("~r~", ConsoleColor.Red)]
        Red,
        [GtMpColorCodePropertie("~b~", ConsoleColor.Blue)]
        Blue,
        [GtMpColorCodePropertie("~g~", ConsoleColor.Green)]
        Green,
        [GtMpColorCodePropertie("~y~", ConsoleColor.Yellow)]
        Yellow,
        [GtMpColorCodePropertie("~p~", ConsoleColor.DarkMagenta)]
        Purple,
        [GtMpColorCodePropertie("~q~", ConsoleColor.Magenta)]
        Pink,
        [GtMpColorCodePropertie("~o~", ConsoleColor.DarkYellow)]
        Orange,
        [GtMpColorCodePropertie("~c~", ConsoleColor.Gray)]
        Grey,
        [GtMpColorCodePropertie("~m~", ConsoleColor.DarkGray)]
        DarkerGrey,
        [GtMpColorCodePropertie("~u~", ConsoleColor.Black)]
        Black,
        [GtMpColorCodePropertie("~n~", (ConsoleColor)99)]
        NewLine,
        [GtMpColorCodePropertie("~s~", (ConsoleColor)999)]
        DefaultWhite,
        [GtMpColorCodePropertie("~w~", ConsoleColor.White)]
        White,
        [GtMpColorCodePropertie("~h~", (ConsoleColor)9999)]
        BoldText,
    }
}
