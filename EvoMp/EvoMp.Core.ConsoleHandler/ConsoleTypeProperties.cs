using System;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ConsoleTypeProperties : Attribute
    {
        public ConsoleTypeProperties(string colorCodeType, string displayName, string colorCodeText = "~#fff~")
        {
            TypeCode = colorCodeType;
            TextCode = colorCodeText != "" ? colorCodeText : "~#fff~";
            TypeName = displayName;
        }

        /// <summary>
        /// TypeCode & TypeName
        /// </summary>
        /// <param name="paddingChar">padding char, for fit to longest Type</param>
        /// <param name="prefix">Prefix between TypeCode and name</param>
        /// <returns></returns>
        public string TypeText(char paddingChar = Char.MinValue, string prefix = "")
        {
            if (paddingChar == Char.MinValue)
                return TypeCode + prefix + TypeName;

            return TypeCode + prefix + TypeName.PadRight(ConsoleUtils.LongestTypeLength, paddingChar);
        }

        /// <summary>
        ///     Color code for the text
        /// </summary>
        public string TextCode { get; }

        /// <summary>
        /// Extra display name
        /// </summary>
        public string TypeName { get; }

        /// <summary>
        ///     ColorCode for the Type block
        /// </summary>
        public string TypeCode { get; }
    }
}