using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ConsoleTypeProperties : Attribute
    {
        public ConsoleColor ForegroundColor { get; }
        public ConsoleColor BackgroundColor { get; }

        public ConsoleTypeProperties(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }
}
