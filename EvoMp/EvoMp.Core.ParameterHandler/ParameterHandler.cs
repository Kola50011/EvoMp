using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler;

namespace EvoMp.Core.Parameter
{
    /// <summary>
    ///     Handler for startup parameter managment
    /// </summary>
    public class ParameterHandler
    {
        /// <summary>
        ///     List with all parameters and ther values
        /// </summary>
        private static Dictionary<string, Enum> _parameterList = new Dictionary<string, Enum>();

        /// <summary>
        ///     Stored all enums wich are registered as ParameterEnum
        /// </summary>
        private static readonly List<Type> RegisteredParameterList = new List<Type>();

        private static bool EnumUsingAttributes(Enum parameterEnum)
        {
            foreach (Enum enumItem in Enum.GetValues(parameterEnum.GetType()))
                if (GetParameterProperties(enumItem) == null)
                    return false;

            return true;
        }

        /// <summary>
        ///     Compares each parameter identifier with each other.
        ///     returns false if any duplicate found.
        /// </summary>
        private static bool OnlyUniqueIdentifier()
        {
            bool onlyUnique = true;

            foreach (Type enumType1 in RegisteredParameterList)
            foreach (Type enumType2 in RegisteredParameterList.Except(new[] {enumType1}))
            foreach (Enum enumValue1 in Enum.GetValues(enumType1))
            foreach (Enum enumValue2 in Enum.GetValues(enumType2))
            {
                ParameterProperties properties1 = GetParameterProperties(enumValue1);
                ParameterProperties properties2 = GetParameterProperties(enumValue2);

                if (properties1.ParameterIdentifier == properties2.ParameterIdentifier)
                {
                    onlyUnique = false;
                    ConsoleOutput.WriteLine(ConsoleType.Fatal,
                        $"Double use of the parameter identifier ~y~\"{properties1.ParameterIdentifier}\"~;~ " +
                        $"for parameter ~y~\"{enumValue1.GetType()}\"~;~ and ~y~\"{enumValue2.GetType()}\"~;~.");
                }

                if (properties1.ShortParameterIdentifier == properties2.ShortParameterIdentifier)
                {
                    onlyUnique = false;
                    ConsoleOutput.WriteLine(ConsoleType.Fatal,
                        $"Double use of the short parameter identifier ~y~\"{properties1.ShortParameterIdentifier}\"~;~ " +
                        $"for parameter ~y~\"{enumValue1.GetType()}\"~;~ and ~y~\"{enumValue2.GetType()}\"~;~.");
                }
            }

            return onlyUnique;
        }

        /// <summary>
        ///     Registering a enum as parameter enum.
        ///     All Enum items must use the ParameterProperties attribute.
        /// </summary>
        /// <param name="parameterEnum">The enum (new enum()) that should be registered.</param>
        public static void RegisterParameterEnum(Enum parameterEnum)
        {
            // Enum is already registered -> exception;
            if (RegisteredParameterList.Contains(parameterEnum.GetType()))
                throw new Exception($"The enum \"{parameterEnum.GetType()}\" is already a registered enum type!");

            // Enum don't implement the Parameter attribute -> exception;
            if (!EnumUsingAttributes(parameterEnum)) //TODO: Testen
                throw new Exception(
                    $"All Items of the enum \"{parameterEnum.GetType()}\" must use the ParameterProperties attribute!");

            // Add to registered parameters
            RegisteredParameterList.Add(parameterEnum.GetType());

            // Not only unique identifier -> remove enum & return;
            if (!OnlyUniqueIdentifier())
            {
                RegisteredParameterList.Remove(parameterEnum.GetType());
                return;
            }

            // Prepare parameter
            PrepareParameter();

            ConsoleOutput.WriteLine(ConsoleType.Note,
                $"Registered ~b~\"{string.Join(", ", Enum.GetNames(parameterEnum.GetType()))}\"~;~ as startup parameters.");
        }

        /// <summary>
        ///     Parsing all command line arguments for other functions
        /// </summary>
        public static void PrepareParameter()
        {
            _parameterList = new Dictionary<string, Enum>();

            // Only one parameter given -> return (first is path)
            List<string> startParameters = Environment.GetCommandLineArgs().ToList();
            if (startParameters.Count == 1)
                return;

            // Remove path
            startParameters.Remove(startParameters.First());

            foreach (string startParameter in startParameters)
            foreach (Type enumType in RegisteredParameterList)
            foreach (Enum parameter in Enum.GetValues(enumType))
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
        public static ParameterProperties GetParameterProperties(Enum startParameter)
        {
            MemberInfo[] memberInfos = startParameter.GetType().GetMember(startParameter.ToString());

            // No member -> return null;
            if (memberInfos.Length == 0)
                return null;

            ParameterProperties propertie = null;
            foreach (MemberInfo memberInfo in memberInfos)
            {
                propertie = (ParameterProperties) memberInfo.GetCustomAttribute(typeof(ParameterProperties), false);
                if (propertie != null)
                    break;
            }

            return propertie;
        }

        public static string GetFirstParameterValue(Enum parameter)
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
        public static List<string> GetParameterValues(Enum parameter)
        {
            ParameterProperties startParameterProperties = GetParameterProperties(parameter);

            List<string> parameterValues = (from startParameter in _parameterList
                where Equals(startParameter.Value, parameter)
                select startParameter.Key).ToList();

            // No parameters found -> check for default value
            if (!parameterValues.Any())
                if (startParameterProperties.DefaultValue != null)
                    parameterValues.Add(startParameterProperties.DefaultValue);

            return parameterValues;
        }
    }
}