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
        /// <param name="controlCodeAscii">Ascii string, if ColorCode is controlCode</param>
        /// <param name="ignoresParsingDisabled">Can this ColorCode ignore the disabled Parsing?</param>
        public ColorCodePropertie(string colorCodeIdentifier, KnownColor color, string controlCodeAscii = null, bool ignoresParsingDisabled = false)
        {
            Identifier = colorCodeIdentifier;
            Color = color;
            ControlCodeAnsi = controlCodeAscii;
            IgnoresParsingDisabled = ignoresParsingDisabled;
        }

        /// <summary>
        ///     ColorCode identifier
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        ///     The Color for the identifier
        /// </summary>
        public KnownColor Color { get; }

        /// <summary>
        /// The Control code Ascii String
        /// </summary>
        public string ControlCodeAnsi { get; }

        public bool IgnoresParsingDisabled { get; }
    }
}