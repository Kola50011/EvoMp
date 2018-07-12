using System.Drawing;

namespace EvoMp.Core.ColorHandler.Server
{
    /// <summary>
    ///     Avalible stringcolor codes.
    ///     Important: Colors can only be one char long!
    /// </summary>
    public enum ColorCode
    {
        // Foreground colors
        [ColorCodeProperty("~r~", KnownColor.Red)] Red,

        [ColorCodeProperty("~b~", KnownColor.LightBlue)] Blue,

        [ColorCodeProperty("~g~", KnownColor.LimeGreen)] Green,

        [ColorCodeProperty("~y~", KnownColor.Yellow)] Yellow,

        [ColorCodeProperty("~p~", KnownColor.Purple)] Purple,

        [ColorCodeProperty("~q~", KnownColor.Pink)] Pink,

        [ColorCodeProperty("~o~", KnownColor.Orange)] Orange,

        [ColorCodeProperty("~c~", KnownColor.Gray)] Grey,

        [ColorCodeProperty("~m~", KnownColor.DarkGray)] DarkerGrey,

        [ColorCodeProperty("~l~", KnownColor.LightGray)] LigthGrey,

        [ColorCodeProperty("~u~", KnownColor.Black)] Black,

        [ColorCodeProperty("~w~", KnownColor.White)] White,

        // Background colors
        [ColorCodeProperty("~br~", KnownColor.Red)] BackgroundRed,

        [ColorCodeProperty("~bb~", KnownColor.Blue)] BackgroundBlue,

        [ColorCodeProperty("~bg~", KnownColor.Green)] BackgroundGreen,

        [ColorCodeProperty("~by~", KnownColor.Yellow)] BackgroundYellow,

        [ColorCodeProperty("~bp~", KnownColor.Purple)] BackgroundPurple,

        [ColorCodeProperty("~bq~", KnownColor.Pink)] BackgroundPink,

        [ColorCodeProperty("~bo~", KnownColor.Orange)] BackgroundOrange,

        [ColorCodeProperty("~bc~", KnownColor.Gray)] BackgroundGrey,

        [ColorCodeProperty("~bm~", KnownColor.DarkGray)] BackgroundDarkerGrey,

        [ColorCodeProperty("~bu~", KnownColor.Black)] BackgroundBlack,

        [ColorCodeProperty("~bw~", KnownColor.White)] BackgroundWhite,

        // Control codes
        [ColorCodeProperty("~n~", 0, "\n")] NewLine,

        [ColorCodeProperty("~h~", 0, "\x1B[1m")] BoldText,

        [ColorCodeProperty("~_~", 0, "\x1B[4m")] UnderlineText,

        [ColorCodeProperty("~|~", 0, "\x1B[24m")] UnderlineReset,

        // Special Control codes
        // Taking affect in InternalWrite function
        [ColorCodeProperty("~...~", 0, "...", false, true)] FillLineWithSpaces,

        [ColorCodeProperty("~;~", 0, "\x1B[0m", false, true)] ResetColor,

        //TODO: Wozu ist das da?
        [ColorCodeProperty("~;;~", 0, "\x1B[0m", false, true)] ResetToConsole,

        [ColorCodeProperty("~-^-~", 0, "", false, true)] InsertLineAbove,

        [ColorCodeProperty("~-v-~", 0, "", false, true)] InsertLineBelow,

        [ColorCodeProperty("~>-<~", 0, "", false, true)] Centered,

        [ColorCodeProperty("~!-!~", 0, "!00!", true, true)] CodeParsingOff,

        [ColorCodeProperty("~!|!~", 0, "!01!", true, true)] CodeParsingOn
    }
}
