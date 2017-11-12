using System;
using System.IO;
using System.Linq;
using EvoMp.Core.ConsoleHandler;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Core
{
    public class Main : Script
    {
        #region DebugKonstante

#if DEBUG
        public const bool Debug = true;
#else
        public const bool Debug = false;
#endif

        #endregion //DebugKonstante

        public static string ServerFilesFolder = string.Empty;

        public Main()
        {
            #region Core preparing / initialization

            // Clear console, set console color & write copyright
            ConsoleOutput.Clear();

            // Prepare Console set title
            ConsoleHandler.ConsoleHandler.PrepareConsole();

            // Prepare Parameter
            ParameterHandler.PrepareParameter();

            #endregion // Core preparing / initialization

            ConsoleOutput.SetConsoleTitle("EvoMp GT-MP Server Core. All rights reserverd.");

            // Load core startup parameter
            ServerFilesFolder = ParameterHandler.GetFirstParameterString(Parameter.ServerFilesFolder);
            if (!ServerFilesFolder.EndsWith("/") && !ServerFilesFolder.EndsWith("\\"))
                ServerFilesFolder += "/";

            string asciiLogoFile = ParameterHandler.GetFirstParameterString(Parameter.LogoFileName);

            #region Logo, Copyright, Server informations

            // Write logo from logo file
            ConsoleOutput.WriteCentredText(ConsoleType.Note,
                ConsoleUtils.ParseTextFileForConsole($"{ServerFilesFolder}{asciiLogoFile}",
                    2, 1));

            ConsoleOutput.PrintLine("-", "~#E6E6E6~");
            // No Logo defined -> message and use default Logo
            if (asciiLogoFile == ParameterHandler.GetStartParameterProperties(Parameter.LogoFileName).DefaultValue)
            {
                ConsoleOutput.WriteCentredText(ConsoleType.Config,
                    $"Using logo file ~o~\"{Path.GetFullPath($"{asciiLogoFile}")}\"~;~.\n" +
                    $"Please start your server with the ~b~\"{ParameterHandler.GetStartParameterProperties(Parameter.LogoFileName).ParameterIdentifier}\" ~;~ parameter.");
                ConsoleOutput.PrintLine("-", "~#E6E6E6~", ConsoleType.Config);
            }

            // GetServerGamemodes writes cfg message to if not setten
            string moduleTypesString =
                string.Join(", ", ModuleTypeHandler.GetServerGamemodes().ToList().ConvertAll(input => input.ToUpper()));

            const string leftServerInfo = "~#90A4AE~";
            const string rightServerInfo = "~#ECEFF1~";

            // Tiny gray line & Empty
            ConsoleOutput.PrintLine("-", "~#E6E6E6~");
            ConsoleOutput.PrintLine(" ");

            // Small centered line with headline & developer
            ConsoleOutput.WriteCentredText(ConsoleType.Note,
                "".PadRight(55, '-') + "\n" +
                "Server information\n" +
                "".PadRight(55, '-'));

            ConsoleOutput.WriteCentredText(ConsoleType.Info,
                $"{leftServerInfo}{"Server mode:".PadRight(20)}{String.Empty.PadRight(5)}{rightServerInfo}{$"{moduleTypesString}".PadRight(20)}\n" +
                $"{leftServerInfo}{"Runtime mode:".PadRight(20)}{String.Empty.PadRight(5)}{rightServerInfo}{$"{(Debug ? "Debugging" : "Release")}".PadRight(20)}\n" +
                $"{leftServerInfo}{"Server name:".PadRight(20)}{String.Empty.PadRight(5)}{rightServerInfo}{$"{API.getServerName().Substring(0, 20)}".PadRight(20)}\n" +
                $"{leftServerInfo}{"Server port:".PadRight(20)}{String.Empty.PadRight(5)}{rightServerInfo}{$"{API.getServerPort():0000}".PadRight(20)}\n" +
                $"{leftServerInfo}{"Max players:".PadRight(20)}{String.Empty.PadRight(5)}{rightServerInfo}{$"{API.getMaxPlayers():0000}".PadRight(20)}\n");

            // Two empty lines
            ConsoleOutput.PrintLine(" ");
            ConsoleOutput.PrintLine(" ");

            // Small centered line with headline & developer
            ConsoleOutput.WriteCentredText(ConsoleType.Note,
                "".PadRight(55, '-') + "\n" +
                "Developer team\n" +
                "".PadRight(55, '-'));

            const string usernameColor = "~#ECEFF1~";
            const string diTitleColor = "~#03A9F4~";
            const string depyTitleColor = "~#4FC3F7~";
            const string staffTitleColor = "~#B3E5FC~";

            ConsoleOutput.WriteCentredText(ConsoleType.Note,
                $"{diTitleColor}{"Roleplay Director".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"DevGrab".PadRight(20)}\n" +
                $"{diTitleColor}{"Freeroam Director".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"Ruffo/Christian".PadRight(20)}\n" +
                $"{depyTitleColor}{"Roleplay Deputy".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"Sascha".PadRight(20)}\n" +
                $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"Koka".PadRight(20)}\n" +
                $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"Lukas/Nitac".PadRight(20)}\n" +
                $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"Sopex".PadRight(20)}\n" +
                $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"Gary".PadRight(20)}\n" +
                $"{staffTitleColor}{"Freeroam Staff".PadRight(20)}{String.Empty.PadRight(5)}{usernameColor}{"James".PadRight(20)}\n");
            // Two empty lines
            ConsoleOutput.PrintLine(" ");

            ConsoleOutput.PrintLine("-");

            #endregion Logo, Copyright, Server informations


            // Write information about Core startup
            ConsoleOutput.WriteLine(ConsoleType.Core, "Initializing EvoMp Core...");

            // Init ModuleStructurer
            ModuleStructurer moduleStructurer = new ModuleStructurer();

            // Copy modules & NuGet files to Server
            moduleStructurer.RefreshResourceModules();
            moduleStructurer.CopyNuGetPackagesToServer();

            // Write complete & loading modules message
            ConsoleOutput.WriteLine(ConsoleType.Core, "Initializing EvoMp Core completed.");

            // Load Modules
            new ModuleLoader(API).Load();
            #region ConsoleModule tester

            // Debugging

            ConsoleOutput.WriteLine(ConsoleType.Debug, "Testoutputs for console module");
            ConsoleOutput.PrintLine("-");
            ConsoleOutput.WriteLine(ConsoleType.Info, "~w~~bg~White With Green Background ~;~Original Color " +
                                                      "~g~Green ~o~Orange ~b~Blue ~y~Yellow!" +
                                                      "~n~New Line ~_~Underline ~|~ Underline off" +
                                                      "~h~Fett! ~g~Parsed text~!-!~~g~Parsing ~#FF0000~off!~!|!~~w~Parsing ~g~ on again!");
            ConsoleOutput.PrintLine("_");
            ConsoleOutput.WriteLine(ConsoleType.Info,
                "Automatic WordWrap on too long textes. Just kidding, or not? I dont know. Is this sentence wrapped? Tell me please. And if not, its .. NOT OKAY! Wait.. what the hell i'm writing here? I only need a long text! By the way: I'm not 100% Satisfied with the console output and the color parsing etc. I think we can use it in the whole server too. Not only in the console. I mean the control codes parsing. .. I just got hungry for watermelon. My paprika is very fruityp Good night! zZz ~n~~_~(Whole message in one ConsoleOutput.WriteLine() call, including this.)");
            ConsoleOutput.PrintLine("_");


            ConsoleOutput.WriteLine(ConsoleType.Note,
                "Demo ConsoleTypes~-^-~~-v-~ (~w~This Line unparsed: ~o~\"~!-!~Demo ConsoleTypes~-^-~~-v-~ ~!|!~\"~w~.");
            ConsoleOutput.WriteLine(ConsoleType.Core, "A Core message");
            ConsoleOutput.WriteLine(ConsoleType.Info, "A Info message");
            ConsoleOutput.WriteLine(ConsoleType.Warn, "A Warn message");
            ConsoleOutput.WriteLine(ConsoleType.Error, "A Error message");
            ConsoleOutput.WriteLine(ConsoleType.Fatal, "A Fatal Error message");
            ConsoleOutput.WriteLine(ConsoleType.Note, "A Note message");
            ConsoleOutput.WriteLine(ConsoleType.Debug, "A Debug message");
            ConsoleOutput.WriteLine(ConsoleType.Database, "A Database message");
            ConsoleOutput.WriteLine(ConsoleType.Config, "A Config message");
            ConsoleOutput.WriteLine(ConsoleType.Line, "A Line message");
            ConsoleOutput.PrintLine("-");

            #endregion ConsoleModule tester
        }
    }
}