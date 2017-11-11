using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler;

namespace EvoMp.Core.Core
{
    /// <summary>
    ///     Handler for startup parameter managment
    /// </summary>
    public class ParameterHandler
    {
        /// <summary>
        ///     List with all parameters and ther values
        /// </summary>
        private static Dictionary<string, Parameter> _parameterList = new Dictionary<string, Parameter>();

        // Store all start parmeter enums on startup for better perfomance
        private static readonly IEnumerable<ParameterProperties> StartParameterPropertieses =
            Enum.GetValues(typeof(Parameter))
                .Cast<Parameter>()
                .Where(code => code.HasFlag(code))
                .Select(code => typeof(Parameter)
                    .GetField(code.ToString()))
                .Select(info => info.GetCustomAttribute(typeof(ParameterProperties), false))
                .Cast<ParameterProperties>();

        /// <summary>
        ///     Parsing all command line arguments
        /// </summary>
        public static void PrepareParameter()
        {
            _parameterList = new Dictionary<string, Parameter>();

            // Parse Microsoft logic to string.
            string commandLineArgument = string.Join(" ", Environment.GetCommandLineArgs());

            // Parse char by char
            bool parsingParameter = false;
            bool openQuote = false;
            string currentParse = string.Empty;
            Parameter currentParameter = (Parameter)(-1);
            ParameterProperties currentStartParameterProperties = null;

            foreach (char commandLineChar in commandLineArgument)
            {
                // Starting parse new parameter if not parsing & - appears
                if (commandLineChar == '-' && !parsingParameter)
                {
                    // Reset valuesy
                    openQuote = false;
                    parsingParameter = true;
                    currentParameter = (Parameter)(-1);
                    currentStartParameterProperties = null;
                }

                // Stack to code
                if (parsingParameter)
                    currentParse += commandLineChar;

                // search for possible parameter
                if (!parsingParameter)
                {
                    // Get all possible start parameters
                    List<Parameter> possibleStartParameters =
                    (from Parameter startParameter in Enum.GetValues(typeof(Parameter))
                     let parameterPropertieses = GetStartParameterProperties(startParameter)
                     where parameterPropertieses.ParameterIdentifier.ToLower().StartsWith(currentParse.ToLower()) ||
                           parameterPropertieses.ShortParameterIdentifier.ToLower()
                               .StartsWith(currentParse.ToLower())
                     select startParameter).ToList();

                    // Only one match -> we found the right
                    if (possibleStartParameters.Count() == 1)
                    {
                        currentParameter = possibleStartParameters.First();
                        currentStartParameterProperties = GetStartParameterProperties(currentParameter);
                        parsingParameter = true;
                    }
                }

                // Remove parameter call, but only if its ends with space
                if (parsingParameter && currentParse.EndsWith(" "))
                    if (currentParse.ToLower().Trim() == currentStartParameterProperties?.ParameterIdentifier.ToLower()
                        || currentParse.ToLower().Trim() ==
                        currentStartParameterProperties?.ShortParameterIdentifier.ToLower())
                        currentParse = "";

                // Check for quotes. For string values
                if (commandLineChar == '\"')
                    openQuote = !openQuote;


                // Space and no open quote -> Parameter value complete
                if (commandLineChar == ' ' && !openQuote && currentStartParameterProperties != null)
                {
                    parsingParameter = false;

                    // Parameter is only allowed one time -> Write warn
                    if (!currentStartParameterProperties.MultipleUseAllowed &&
                        _parameterList.ContainsValue(currentParameter))
                        ConsoleOutput.WriteLine(ConsoleType.Warn,
                            $"Parameter ~b~\"{currentStartParameterProperties.ParameterIdentifier}\"~;~ is only allowed one time.\n" +
                            $"Parameter ~o~\"{currentStartParameterProperties.ParameterIdentifier} {currentParse}\"~;~ would be ignored.");
                    else
                        _parameterList.Add(currentParse.Replace("\"", ""), currentParameter);
                }
            }
        }


        /// <summary>
        ///     Returns the start parameter properties for the given StartParameter
        /// </summary>
        /// <param name="startParameter"></param>
        /// <returns></returns>
        public static ParameterProperties GetStartParameterProperties(Parameter startParameter)
        {
            MemberInfo[] memberInfo = startParameter.GetType().GetMember(startParameter.ToString());
            ParameterProperties attributes =
                (ParameterProperties)memberInfo[0].GetCustomAttribute(typeof(ParameterProperties), false);

            return attributes;
        }

        /// <summary>
        ///     Returns the first parameter value wich was found to the given parameter.
        ///     For getting all values: <see cref="GetParameterStrings" />
        /// </summary>
        /// <param name="parameter">The searched parameter</param>
        /// <returns>Parameter value or null</returns>
        public static string GetFirstParameterString(Parameter parameter)
        {
            return GetParameterStrings(parameter).FirstOrDefault();
        }

        /// <summary>
        /// Returns all parameter values for the given parameter.
        /// If no value found, and the defaultValue for the parameter is given,
        /// the defaultValue returned
        /// </summary>
        /// <param name="parameter">The searched parameter</param>
        /// <returns></returns>
        public static List<string> GetParameterStrings(Parameter parameter)
        {
            ParameterProperties startParameterProperties = GetStartParameterProperties(parameter);

            List<string> parameterValues = (from startParameter in _parameterList
                                            where startParameter.Value == parameter
                                            select startParameter.Key).ToList();

            // No parameters found -> check for default value
            if (!parameterValues.Any())
                if (startParameterProperties.DefaultValue != null)
                    parameterValues.Add(startParameterProperties.DefaultValue);

            return parameterValues;
        }
    }
}