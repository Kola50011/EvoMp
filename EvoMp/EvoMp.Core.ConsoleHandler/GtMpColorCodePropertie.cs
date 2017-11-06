using System;
using System.Drawing;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorCodePropertie : Attribute
    {
        public string Identifier { get; }
        public KnownColor Color { get; }

        /// <summary>
        /// Attribute for the GtMpColorCode enum.
        /// KnowColor casted exceptions: 
        ///    -3   New Line
        ///    -4   Default Color
        ///    -5   Bold Text
        /// </summary>
        /// <param name="colorCodeIdentifier">The GtMp ColorString identifier without the tildes</param>
        /// <param name="color"> The equivalent of the color code</param>
        public ColorCodePropertie(string colorCodeIdentifier, KnownColor color)
        {
            Identifier = colorCodeIdentifier;
            Color = color;
        }
    }
}