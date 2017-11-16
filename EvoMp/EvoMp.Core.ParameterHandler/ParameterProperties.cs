using System;

namespace EvoMp.Core.Parameter
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ParameterProperties : Attribute
    {
        /// <summary>
        ///     Attribute for start parameters
        /// </summary>
        /// <param name="parameterIdentifier">Identifer for the parameter</param>
        /// <param name="shortParameterIdentifier">Short version for the identifer</param>
        /// <param name="description">Description for the parameter</param>
        /// <param name="multipleUseAllowed">Can this parameter entered multiple times</param>
        /// <param name="defaultValue">The default value for the given parameter.</param>
        public ParameterProperties(string shortParameterIdentifier, string parameterIdentifier, string description,
            bool multipleUseAllowed = false, string defaultValue = null)
        {
            // Normal should start with --
            if (!parameterIdentifier.StartsWith("--"))
                throw new Exception($"The long parameterIdentifier musst start with a double \"-\"!\n" +
                                    $"Identifier: \"{parameterIdentifier}\".");

            // short should start with -
            if (!shortParameterIdentifier.StartsWith("-") || shortParameterIdentifier.StartsWith("--"))
                throw new Exception($"The shortParameterIdentifier musst start with a single \"-\"!\n" +
                                    $"Identifier: \"{parameterIdentifier}\".");


            // Set properties
            ParameterIdentifier = parameterIdentifier.ToLower();
            ShortParameterIdentifier = shortParameterIdentifier.ToLower();
            Description = description;
            MultipleUseAllowed = multipleUseAllowed;
            DefaultValue = defaultValue;
        }

        /// <summary>
        ///     Identifer for the parameter
        /// </summary>
        public string ParameterIdentifier { get; }

        /// <summary>
        ///     Short identifier for the parameter
        /// </summary>
        public string ShortParameterIdentifier { get; }

        /// <summary>
        ///     Description for the parameter
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Can this parameter entered multiple times?
        /// </summary>
        public bool MultipleUseAllowed { get; }

        /// <summary>
        /// Default value for parameter.
        /// Used if parameter wasn't entered
        /// </summary>
        public string DefaultValue { get; }
    }
}