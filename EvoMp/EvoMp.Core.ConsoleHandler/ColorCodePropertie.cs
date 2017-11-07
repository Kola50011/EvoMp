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
        /// <param name="color"> The equivalent of the color code</param>
        public ColorCodePropertie(string colorCodeIdentifier, KnownColor color)
        {
            Identifier = colorCodeIdentifier;
            Color = color;
        }

        public string Identifier { get; }
        public KnownColor Color { get; }
    }
}