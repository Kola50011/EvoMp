﻿using System.Drawing;

namespace EvoMp.Core.ConsoleHandler
{
    /// <summary>
    ///     Avalible stringcolor codes.
    ///     Important: Colors can only be one char long!
    /// </summary>
    public enum ColorCodes
    {
        // Foreground colors
        [ColorCodePropertie("~r~", KnownColor.Red)] Red,
        [ColorCodePropertie("~b~", KnownColor.Cyan)] Blue,
        [ColorCodePropertie("~g~", KnownColor.LimeGreen)] Green,
        [ColorCodePropertie("~y~", KnownColor.LightYellow)] Yellow,
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
        [ColorCodePropertie("~n~", (KnownColor) (-3))] NewLine,
        [ColorCodePropertie("~s~", (KnownColor) (-4))] ResetColor,
        /// <summary>
        /// Hint: Bold is not supported
        /// </summary>
        [ColorCodePropertie("~h~", (KnownColor) (-5))] BoldText,
        [ColorCodePropertie("~_~", (KnownColor) (-6))] UnderlineText,
        [ColorCodePropertie("~|~", (KnownColor) (-7))] UnderlineReset
    }
}