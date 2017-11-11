using System;
using System.Drawing;
using System.IO;
using EvoMp.Core.ConsoleHandler;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Core
{
    public class Main : Script
    {
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

           // ConsoleOutput.StartFullBoxMode(ConsoleType.Info, "█");

            // Todo write suffix & prefix function
            ConsoleOutput.PrintLine(" ");

            // Write logo from logo file
            ConsoleOutput.WriteCentredText(ConsoleType.Info,
                ConsoleUtils.ParseTextFileForConsole($"{ServerFilesFolder}{asciiLogoFile}"));

            // No Logo defined -> message and use default Logo
            if (asciiLogoFile == ParameterHandler.GetStartParameterProperties(Parameter.LogoFileName).DefaultValue)
                ConsoleOutput.WriteCentredText(ConsoleType.Config,
                    $"Using logo file ~o~\"{Path.GetFullPath($"{asciiLogoFile}")}\".~;~" +
                    $"Please start our server with the -LogoPath");


            // TODO: Ab hier noch weiter machen..
            string moduleTypesString = string.Join(", ", ModuleTypeHandler.GetServerGamemodes());
            int spacesForModuleTypes = 46 - moduleTypesString.Length;
            if (spacesForModuleTypes < 0)
                spacesForModuleTypes = 0;

            //TODO: BoxMode
          //  ConsoleOutput.StopFullBoxMode();

            // Module types
            ConsoleOutput.Write(ConsoleType.Info,
                $"~w~|| ~b~{moduleTypesString}" + new string(' ', spacesForModuleTypes) + "~w~||\n");

            //Debug state information
#if DEBUG
            ConsoleOutput.Write(ConsoleType.Info,
                "~w~||~b~        DEBUG MODE                             ~w~||\n");
#else
            ConsoleOutput.Write(ConsoleType.Info, 
                "~w~||~b~        RELEASE MODE                           ~w~||\n");
#endif

            ConsoleOutput.Write(ConsoleType.Info,
                "~w~||===============================================||\n");

            // Parse Servername
            string servername = API.getServerName().PadRight(30).Substring(0, 30);
            if (servername.Trim() != API.getServerName())
                servername = servername.Substring(0, servername.Length - 3) + "...";

            ConsoleOutput.Write(ConsoleType.Note,
                $"~w~|| ~c~Server name: {servername}   ~w~||\n" +
                $"~w~|| ~c~Port:                    {API.getServerPort():0000}                 ~w~||\n" +
                $"~w~|| ~c~Max players:             {API.getMaxPlayers():00000}                ~w~||\n");

            // Print authors
            ConsoleOutput.Write(ConsoleType.Note,
                "~w~||===============================================||\n" +
                "~w~|| ~c~Roleplay Director        ~b~DevGrab              ~w~||\n" +
                "~w~|| ~c~Freeroam Director        ~b~Ruffo/Christian      ~w~||\n" +
                "~w~|| ~c~Roleplay Deputy          ~b~Sascha               ~w~||\n" +
                "~w~|| ~c~Roleplay Staff           ~b~Koka                 ~w~||\n" +
                "~w~|| ~c~Roleplay Staff           ~b~Lukas/Nitaco         ~w~||\n" +
                "~w~|| ~c~Roleplay Staff           ~b~Sopex                ~w~||\n" +
                "~w~|| ~c~Roleplay Staff           ~b~Gary                 ~w~||\n" +
                "~w~|| ~c~Freeroam Staff           ~b~James                ~w~||\n" +
                "~w~||===============================================||\n");

            #endregion Logo, Copyright, Server informations

            // Debugging
            ConsoleOutput.PrintLine("█");
            ConsoleOutput.WriteLine(ConsoleType.Info, "~w~~bg~White With Green Background ~s~Original Color " +
                                  "~g~Green ~o~Orange ~b~Blue ~y~Yellow!" +
                                  "~n~ New Line ~_~ Underline ~|~ Underline off" +
                                  "~h~Fett!");
            ConsoleOutput.PrintLine("-");

            ConsoleOutput.WriteLine(ConsoleType.Core, "A Core message");
            ConsoleOutput.WriteLine(ConsoleType.Info, "A Info message");
            ConsoleOutput.WriteLine(ConsoleType.Warn, "A Warn message");
            ConsoleOutput.WriteLine(ConsoleType.Error, "A Error message");
            ConsoleOutput.WriteLine(ConsoleType.Fatal, "A Fatal Error message");
            ConsoleOutput.WriteLine(ConsoleType.Note, "A Note message");
            ConsoleOutput.WriteLine(ConsoleType.Debug, "A Debug message");
            ConsoleOutput.WriteLine(ConsoleType.Database, "A Database message");
            ConsoleOutput.WriteLine(ConsoleType.Line, "A Line message");
            ConsoleOutput.PrintLine("-");
            ConsoleOutput.WriteLine(ConsoleType.Info, "~g~Parsed text~!-!~~g~Parsing ~#FF0000~off!~!|!~~w~Parsing ~g~ on again!");
            ConsoleOutput.PrintLine("█");







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
        }
    }
}