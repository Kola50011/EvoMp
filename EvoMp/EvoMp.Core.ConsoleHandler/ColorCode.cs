using System.Drawing;

namespace EvoMp.Core.ConsoleHandler
{
    /// <summary>
    ///     Avalible stringcolor codes.
    ///     Important: Colors can only be one char long!
    /// </summary>
    public enum ColorCode
    {
        // Foreground colors
        [ColorCodePropertie("~r~", KnownColor.Red)] Red,
        [ColorCodePropertie("~b~", KnownColor.Cyan)] Blue,
        [ColorCodePropertie("~g~", KnownColor.LimeGreen)] Green,
        [ColorCodePropertie("~y~", KnownColor.Yellow)] Yellow,
        [ColorCodePropertie("~p~", KnownColor.Purple)] Purple,
        [ColorCodePropertie("~q~", KnownColor.Pink)] Pink,
        [ColorCodePropertie("~o~", KnownColor.Orange)] Orange,
        [ColorCodePropertie("~c~", KnownColor.Gray)] Grey,
        [ColorCodePropertie("~m~", KnownColor.DarkGray)] DarkerGrey,
        [ColorCodePropertie("~u~", KnownColor.Black)] Black,
        [ColorCodePropertie("~w~", KnownColor.White)] White,

        // Background colors
        [ColorCodePropertie("~br~", KnownColor.Red)] BackgroundRed,
        [ColorCodePropertie("~bb~", KnownColor.Blue)] BackgroundBlue,
        [ColorCodePropertie("~bg~", KnownColor.Green)] BackgroundGreen,
        [ColorCodePropertie("~by~", KnownColor.Yellow)] BackgroundYellow,
        [ColorCodePropertie("~bp~", KnownColor.Purple)] BackgroundPurple,
        [ColorCodePropertie("~bq~", KnownColor.Pink)] BackgroundPink,
        [ColorCodePropertie("~bo~", KnownColor.Orange)] BackgroundOrange,
        [ColorCodePropertie("~bc~", KnownColor.Gray)] BackgroundGrey,
        [ColorCodePropertie("~bm~", KnownColor.DarkGray)] BackgroundDarkerGrey,
        [ColorCodePropertie("~bu~", KnownColor.Black)] BackgroundBlack,
        [ColorCodePropertie("~bw~", KnownColor.White)] BackgroundWhite,

        // Control codes
        [ColorCodePropertie("~n~", 0, "\n")] NewLine,
        [ColorCodePropertie("~h~", 0, "\x1B[1m")] BoldText,
        [ColorCodePropertie("~_~", 0, "\x1B[4m")] UnderlineText,
        [ColorCodePropertie("~|~", 0, "\x1B[24m")] UnderlineReset,

        // Special Control codes
        // Taking affect in InternalWrite function
        [ColorCodePropertie("~...~", 0, "...", false, true)] FillLineWithSpaces,
        [ColorCodePropertie("~;~", 0, "\x1B[0m", false, true)] ResetColor,
        [ColorCodePropertie("~;;~", 0, "\x1B[0m", false, true)] ResetToConsole,
        [ColorCodePropertie("~-^-~", 0, "", false, true)] LineTop,
        [ColorCodePropertie("~-v-~", 0, "", false, true)] LineBottom,
        [ColorCodePropertie("~>-<~", 0, "", false, true)] Centered,
        [ColorCodePropertie("~!-!~", 0, "!00!", true, true)] CodeParsingOff,
        [ColorCodePropertie("~!|!~", 0, "!01!", true, true)] CodeParsingOn,
    }
}

