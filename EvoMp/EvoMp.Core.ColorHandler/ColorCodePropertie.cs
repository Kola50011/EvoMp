using System;
using System.Drawing;

namespace EvoMp.Core.ColorHandler
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
        /// <param name="hasSpecialLogic">Is this Color code implemented by a special ("hardcoded") Logic?</param>
        public ColorCodePropertie(string colorCodeIdentifier, KnownColor color, string controlCodeAscii = null, bool ignoresParsingDisabled = false, bool hasSpecialLogic = false)
        {
            Identifier = colorCodeIdentifier;
            Color = color;
            ControlCodeAnsi = controlCodeAscii;
            IgnoresParsingDisabled = ignoresParsingDisabled;
            HasSpecialLogic = hasSpecialLogic;
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
        public bool HasSpecialLogic { get; }
    }
}