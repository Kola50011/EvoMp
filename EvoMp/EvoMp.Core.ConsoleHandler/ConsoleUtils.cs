using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    class ConsoleUtils
    {
        public static ConsoleTypeProperties GetConsoleTypeProperties(ConsoleType consoleType)
        {
            MemberInfo[] memberInfo = consoleType.GetType().GetMember(consoleType.ToString());
            ConsoleTypeProperties attributes =
                (ConsoleTypeProperties)memberInfo[0].GetCustomAttribute(typeof(ConsoleTypeProperties), false);

            return attributes;
        }

        /// <summary>
        /// Creates a Dictionary wich contains the pos in the string, 
        /// and the matching console color for the gtmp font color string.
        /// </summary>
        /// <param name="message">The gtMp colored string</param>
        /// <returns>

        /// </returns>
        public static Dictionary<int, ConsoleColor> GtMpColorToConsoleColor(string message)
        {
            ConsoleColor _gtMpColorTildeToConsoleColor(string colorTilde)
            {
                // Get all gtMp ColorCodes
                IEnumerable<GtMpColorCodePropertie> gtMpColorCodes = Enum.GetValues(typeof(GtMpColorCode))
                .Cast<GtMpColorCode>()
                .Where(code => code.HasFlag(code))
                .Select(code => typeof(GtMpColorCode)
                .GetField(code.ToString()))
                .Select(info => info.GetCustomAttribute(typeof(GtMpColorCodePropertie), false))
                .Cast<GtMpColorCodePropertie>();


                GtMpColorCodePropertie currentGtMpColorCodePropertie = null;
                foreach (GtMpColorCodePropertie gtMpColorCode in gtMpColorCodes)
                    if (gtMpColorCode.GtMpColorIdentifier == colorTilde)
                    {
                        currentGtMpColorCodePropertie = gtMpColorCode;
                        break;
                    }

                if (currentGtMpColorCodePropertie != null)
                    return currentGtMpColorCodePropertie.EqualsColor;
                else
                    return ConsoleColor.Gray;
            }

            Dictionary<int, ConsoleColor> returnConsoleColors = new Dictionary<int, ConsoleColor>();

            // Split string to gtmp colors
            string[] colors = message.Split('~', '~');

            foreach (string color in colors)
            {
                // Get equal of GtMp color for Console
                ConsoleColor equalConsoleColor = _gtMpColorTildeToConsoleColor(color);

                // Get postion of the current color tilde
                int position = message.IndexOf($"~{color}~", StringComparison.Ordinal);

                // Cut message, so next tilde is a other
                message = message.Substring(position);

                // Add postion and ConsoleColor to dictionary
                returnConsoleColors.Add(position, equalConsoleColor);
            }

            // Return getted postion & colors
            return returnConsoleColors;
        }
    }
}