using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Core.ConsoleHandler
{
    public class ConsoleHandler
    {
        private static ConsoleHandler _instance;

        private ConsoleHandler()
        {

        }

        private static ConsoleHandler GetInstance()
        {
            return _instance ?? (_instance = new ConsoleHandler());
        }

        public static void Write(ConsoleType consoleType, string message)
        {
            // Get ConsoleHandler instance
            ConsoleHandler instance = GetInstance(); //Debug

            // Write internal
            instance.InternalWrite(consoleType, message);
        }

        public static void WriteLine(ConsoleType consoleType, string message)
        {
            // Get ConsoleHandler instance
            ConsoleHandler instance = GetInstance(); //Debug

            // Write internal
            instance.InternalWrite(consoleType, message + "\n");
        }

        private void InternalWrite(ConsoleType consoleType, string message)
        {
            // Get consoleType properties
            ConsoleTypeProperties consoleTypeProperties = ConsoleUtils.GetConsoleTypeProperties(consoleType);

            // Todo: finish...
            string finalWriteString = $"{new DateTime().ToString(CultureInfo.InvariantCulture)}" + " " + 
                                      $"[]";


            // Set console color settings from type properties
            Console.ForegroundColor = consoleTypeProperties.ForegroundColor;
            Console.BackgroundColor = consoleTypeProperties.BackgroundColor;

            // Write message
            Console.Write(message);

            // Reset console colors
            Console.ResetColor();
        }
    }

}
