using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.Logger
{
    public class Logger : ILogger
    {
        private readonly Dictionary<string, Color> _consoleColors = new Dictionary<string, Color>
        {
            {"Black", new Color(0, 0, 0)},
            {"White", new Color(255, 255, 255)},
            {"Red", new Color(255, 0, 0)},
            {"Lime", new Color(0, 255, 0)},
            {"Blue", new Color(0, 0, 255)},
            {"Yello", new Color(255, 255, 0)},
            {"Cyan", new Color(0, 255, 255)},
            {"Orange", new Color(255, 127, 80)},
            {"Magenta", new Color(255, 0, 255)},
            {"Violet", new Color(238, 130, 238)},
            {"Silver", new Color(192, 192, 192)},
            {"Gray", new Color(128, 128, 128)},
            {"Maroon", new Color(128, 0, 0)},
            {"Olive", new Color(128, 128, 0)},
            {"Green", new Color(0, 128, 0)},
            {"Purple", new Color(128, 0, 128)},
            {"Teal", new Color(0, 128, 128)},
            {"Navy", new Color(0, 0, 128)}
        };

        public Logger()
        {
            SyntaxMap = new Dictionary<string, Color[]>();

            // Predefined syntax's
            AddSyntax($"{LogCase.Info}", "Violet", "Black");
            AddSyntax($"{LogCase.Warn}", "Yellow", "Black");
            AddSyntax($"{LogCase.Error}", "Red", "Black");
            AddSyntax($"{LogCase.Fatal}", "Red", "Black");
            AddSyntax($"{LogCase.Debug}", "Blue", "Black");
            AddSyntax($"{LogCase.Intern}", "Cyan", "Black");
            AddSyntax($"{LogCase.System}", "Violet", "Black");
            AddSyntax($"{LogCase.Chat}", "White", "Black");
            AddSyntax($"{LogCase.Client}", "Yellow", "Black");
            AddSyntax($"{LogCase.ClientEvent}", "Black", "Orange");
            AddSyntax($"{LogCase.ServerEvent}", "Black", "Lime");
            AddSyntax($"{LogCase.Discord}", "Lime", "ORange");

            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out var mode);
            SetConsoleMode(handle, mode | 0x4);

            // Print all colors
            //foreach (string colorName in _consoleColors.Keys)
            //{
            //    Color color = _consoleColors.Get(colorName);
            //    string foregroundColorString = "\x1b[38;2;" + color.red + ";" + color.green +
            //                                   ";" + color.blue;
            //    // Default background
            //    Console.WriteLine(foregroundColorString + "m" + colorName);
            //}
        }

        public Dictionary<string, Color[]> SyntaxMap { get; set; }


        // Register new syntax's while runtime 
        public void AddSyntax(string syntaxname, string foreGround, string backGround)
        {
            SyntaxMap.Set(syntaxname, new[] { _consoleColors.Get(foreGround), _consoleColors.Get(backGround) });
        }

        public void AddSyntax(string syntaxname, Color foreGround, Color backGround)
        {
            SyntaxMap.Set(syntaxname, new[] { foreGround, backGround });
        }

        // Unregister syntax's while runtime
        public void RemoveSyntax(string syntaxname)
        {
            SyntaxMap.Remove(syntaxname);
        }

        // Writing the console-output 
        public void Write(string message, LogCase logCase = LogCase.Info)
        {
            if (message == "")
                return;

            string syntaxname = $"{logCase}";
            try
            {
                if (!SyntaxMap.ContainsKey(syntaxname))
                    throw new Exception("Syntax is not available.");

                if (message.Trim() == string.Empty)
                    return;

                Console.ResetColor(); // Reset color
                StackTrace stackTrace = new StackTrace();
                string timeString = string.Format("{0:HH:mm:ss:fff}", DateTime.Now);

                string finalMessage = string.Format(
                    timeString +
                    " | {0, " + GetBiggestSyntax() + "} | {1} | {2, -150}",
                    syntaxname, stackTrace.GetFrame(1).GetMethod().ReflectedType?.Name, message);


                Color backgroundColor = SyntaxMap.Get(syntaxname)[1];
                Color foregroundColor = SyntaxMap.Get(syntaxname)[0];
                string foregroundColorString = "\x1b[38;2;" + foregroundColor.red + ";" + foregroundColor.green +
                                               ";" + foregroundColor.blue;
                string backgroundColorString = ";48;2;" + backgroundColor.red + ";" + backgroundColor.green +
                                               ";" + backgroundColor.blue;
                if (backgroundColor.red == 0 && backgroundColor.green == 0 && backgroundColor.blue == 0)
                    Console.Write(foregroundColorString + "m" + finalMessage);
                else
                    Console.Write(foregroundColorString + backgroundColorString + "m" + finalMessage);

                if (!finalMessage.EndsWith(Environment.NewLine))
                    Console.WriteLine();

                AddTransport(finalMessage);
                Console.ResetColor(); // Reset color
            }
            catch (Exception e)
            {
                Write(e.ToString(), LogCase.Error);
            }
        }

        // Getting the current biggest defined syntax
        public int GetBiggestSyntax()
        {
            int size = 0;

            foreach (string syntaxMapKey in SyntaxMap.Keys)
                if (size <= syntaxMapKey.Length)
                    size = syntaxMapKey.Length;
            return size;
        }

        //Database function (not finished)
        public void AddTransport(string message)
        {
            //need to be filled
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);
    }
}