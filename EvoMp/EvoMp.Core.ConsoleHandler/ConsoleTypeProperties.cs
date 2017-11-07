using System;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ConsoleTypeProperties : Attribute
    {
        public ConsoleTypeProperties(string colorCodeType, string colorCodeText = "", string displayName = null)
        {
            ColorCodeType = colorCodeType;
            ColorCodeText = colorCodeText;
            DisplayName = displayName;
        }

        /// <summary>
        ///     Color code for the text
        /// </summary>
        public string ColorCodeText { get; }

        /// <summary>
        /// Extra display name
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        ///     ColorCode for the Type block
        /// </summary>
        public string ColorCodeType { get; }
    }
}