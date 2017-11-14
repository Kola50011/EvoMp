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

        /// <summary>
        ///     Parsing all command line arguments for other functions
        /// </summary>
        public static void PrepareParameter()
        {
            _parameterList = new Dictionary<string, Parameter>();

            // Only one parameter given -> return (first is path)
            List<string> startParameters = Environment.GetCommandLineArgs().ToList();
            if (startParameters.Count == 1)
                return;

            // Remove path
            startParameters.Remove(startParameters.First());

            foreach (string startParameter in startParameters)
                foreach (Parameter parameter in Enum.GetValues(typeof(Parameter)))
                {
                    string value = "";
                    ParameterProperties parameterPropertieses = GetParameterProperties(parameter);

                    string key = startParameter.ToLower();
                    if (startParameter.Contains(" "))
                        key = key.Substring(0, key.IndexOf(" ", StringComparison.CurrentCulture));

                    // string is not a parameter -> next
                    if (key.ToLower() != parameterPropertieses.ParameterIdentifier.ToLower() &&
                    key.ToLower() != parameterPropertieses.ShortParameterIdentifier.ToLower()) continue;

                    // String containts value for container?
                    if (startParameter.Contains(" "))
                        value = startParameter.Substring(startParameter.IndexOf(" ",
                            StringComparison.CurrentCulture));

                    // Parameter is only allowed one time -> Continue & Write warn
                    if (!parameterPropertieses.MultipleUseAllowed && _parameterList.ContainsValue(parameter))
                        ConsoleOutput.WriteLine(ConsoleType.Warn,
                            $"Parameter ~b~\"{parameterPropertieses.ParameterIdentifier}\"~;~ is only allowed one time." +
                            $"\nParameter ~o~\"{startParameter}\"~;~ would be ignored.");

                    _parameterList.Add(value.Trim(), parameter);
                }
        }


        /// <summary>
        ///     Returns the start parameter properties for the given StartParameter
        /// </summary>
        /// <param name="startParameter"></param>
        /// <returns></returns>
        public static ParameterProperties GetParameterProperties(Parameter startParameter)
        {
            MemberInfo[] memberInfo = startParameter.GetType().GetMember(startParameter.ToString());
            ParameterProperties attributes =
                (ParameterProperties)memberInfo[0].GetCustomAttribute(typeof(ParameterProperties), false);

            return attributes;
        }

        /// <summary>
        ///     Returns the first parameter value wich was found to the given parameter.
        ///     For getting all values: <see cref="GetParameterValues" />
        /// </summary>
        /// <param name="parameter">The searched parameter</param>
        /// <returns>Parameter value or null</returns>
        public static string GetFirstParameterValue(Parameter parameter)
        {
            return GetParameterValues(parameter).FirstOrDefault();
        }

        public static string[] GetAllParameterValue(bool withExecuteablePath = false)
        {
            if (withExecuteablePath)
                return Environment.GetCommandLineArgs();

            List<string> startParameters = Environment.GetCommandLineArgs().ToList();

            // Remove exePath
            startParameters.Remove(startParameters.First());

            return startParameters.ToArray();
        }

        /// <summary>
        ///     Returns all parameter values for the given parameter.
        ///     If no value found, and the defaultValue for the parameter is given,
        ///     the defaultValue returned
        /// </summary>
        /// <param name="parameter">The searched parameter</param>
        /// <returns></returns>
        public static List<string> GetParameterValues(Parameter parameter)
        {
            ParameterProperties startParameterProperties = GetParameterProperties(parameter);

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