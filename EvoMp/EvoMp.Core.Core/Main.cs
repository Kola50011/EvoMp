using System;
using EvoMp.Core.ConsoleHandler;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Core
{
    public class Main : Script
    {
        public Main()
        {
            // Set console title
            ConsoleOutput.SetConsoleTitle("© 2017 EVO MP ALL RIGHTS RESERVED");

            #region Copyright and Server information

            // Clear console, set console color & write copyright
            ConsoleOutput.Clear();

            // Print logo & Copyright
            ConsoleOutput.Write(ConsoleType.Info,
                "~w~||===============================================||\n" +
                "~w~||~b~ ███████╗██╗   ██╗ ██████╗ ███╗   ███╗██████╗  ~w~||\n" +
                "~w~||~b~ ██╔════╝██║   ██║██╔═══██╗████╗ ████║██╔══██╗ ~w~||\n" +
                "~w~||~b~ █████╗  ██║   ██║██║   ██║██╔████╔██║██████╔╝ ~w~||\n" +
                "~w~||~b~ ██╔══╝  ╚██╗ ██╔╝██║   ██║██║╚██╔╝██║██╔═══╝  ~w~||\n" +
                "~w~||~b~ ███████╗ ╚████╔╝ ╚██████╔╝██║ ╚═╝ ██║██║      ~w~||\n" +
                "~w~||~b~ ╚══════╝  ╚═══╝   ╚═════╝ ╚═╝     ╚═╝╚═╝      ~w~||\n" +
                "~w~||===============================================||\n" +
                "~w~|| ~c~~_~© 2017 EVO MP ALL RIGHTS RESERVED~s~ ~w~            ||\n");

            string moduleTypesString = String.Join(", ", ModuleTypeHandler.GetServerTypes());
            int spacesForModuleTypes = 46 - moduleTypesString.Length;
            if (spacesForModuleTypes < 0)
                spacesForModuleTypes = 0;

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

            #endregion // Copyright and Server information

            // Debugging
            ConsoleOutput.WriteLine(
                ConsoleType.Info,"~w~~bg~White With Green Background ~s~Original Color " +
                                                "~g~Green ~o~Orange ~b~Blue ~y~Yellow!" +
                                                "~n~ New Line ~_~ Underline ~|~ Underline off" +
                                                "~h~Fett!");
            ConsoleOutput.PrintLine("-");


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