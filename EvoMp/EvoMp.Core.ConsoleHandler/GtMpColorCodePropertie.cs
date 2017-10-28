using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Field)]
    public class GtMpColorCodePropertie : Attribute
    {
        public string GtMpColorIdentifier { get; }
        public ConsoleColor EqualsColor { get; }

        /// <summary>
        /// Attribute for the GtMpColorCode enum.
        /// ConsoleColor exceptions: 
        ///    - 99    = New Line
        ///    - 999   = Default Color
        ///    - 9999  = Bold Text
        /// </summary>
        /// <param name="gtMpColorIdentifier">The GtMp ColorString identifier without the tildes</param>
        /// <param name="equalsColor"> The equivalent of the Gt:Mp color code</param>
        public GtMpColorCodePropertie(string gtMpColorIdentifier, ConsoleColor equalsColor)
        {
            GtMpColorIdentifier = gtMpColorIdentifier;
            EqualsColor = equalsColor;
        }
    }
}