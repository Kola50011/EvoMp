using System;
using System.Linq;

namespace EvoMp.Core.Core
{
    /// <summary>
    ///     Handler for startup parameter managment
    /// </summary>
    public class ParameterHandler
    {
        /// <summary>
        ///     Checks if the given parameter was given as startup argument
        /// </summary>
        /// <param name="parameter">Parameter to check</param>
        /// <returns>true if given</returns>
        public static bool IsGiven(string parameter)
        {
            return Environment.GetCommandLineArgs().
                Any(s => String.Equals(s, parameter, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}