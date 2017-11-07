using System;
using System.Drawing;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorCodePropertie : Attribute
    {
        /// <summary>
        ///     Attribute for the color code enum.
        /// </summary>
        /// <param name="colorCodeIdentifier">The ColorString identifier without the tildes</param>
        /// <param name="color">The equivalent of the color code</param>
        public ColorCodePropertie(string colorCodeIdentifier, KnownColor color)
        {
            Identifier = colorCodeIdentifier;
            Color = color;
        }

        /// <summary>
        ///     ColorCode identifier
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        ///     The Color for the identifier
        /// </summary>
        public KnownColor Color { get; }
    }
}