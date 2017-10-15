using System;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Core
{
    public class Main : Script
    {
        public Main()
        {
            #region Copyright and Server information

            // Clear console, set console color & write copyright
            Console.Clear();

            // Print logo & Copyright
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(
                "||===============================================||\n" +
                "|| ███████╗██╗   ██╗ ██████╗ ███╗   ███╗██████╗  ||\n" +
                "|| ██╔════╝██║   ██║██╔═══██╗████╗ ████║██╔══██╗ ||\n" +
                "|| █████╗  ██║   ██║██║   ██║██╔████╔██║██████╔╝ ||\n" +
                "|| ██╔══╝  ╚██╗ ██╔╝██║   ██║██║╚██╔╝██║██╔═══╝  ||\n" +
                "|| ███████╗ ╚████╔╝ ╚██████╔╝██║ ╚═╝ ██║██║      ||\n" +
                "|| ╚══════╝  ╚═══╝   ╚═════╝ ╚═╝     ╚═╝╚═╝      ||\n" +
                "||===============================================||\n" +
                "|| © 2017 EVO MP ALL RIGHTS RESERVED             ||\n");

            //Debug state information
#if DEBUG
            Console.Write(
                "||        DEBUG MODE                             ||\n");
#else
            Console.Write(
                "||        RELEASE MODE                           ||\n");
#endif

            Console.Write(
                "||===============================================||\n");

            // Parse Servername
            string servername = API.getServerName().PadRight(30).Substring(0, 30);
            if (servername.Trim() != API.getServerName())
                servername = servername.Substring(0, servername.Length - 3) + "...";

            // Server informations
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(
                $"|| Server name: {servername}   ||\n" +
                $"|| Port:                    {API.getServerPort():0000}                 ||\n" +
                $"|| Max players:             {API.getMaxPlayers():00000}                ||\n");

            // Print authors
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                "||===============================================||\n" +
                "|| Roleplay Director        DevGrab              ||\n" +
                "|| Freeroam Director        Ruffo/Christian      ||\n" +
                "|| Roleplay Deputy          Sascha               ||\n" +
                "|| Roleplay Staff           Koka                 ||\n" +
                "|| Roleplay Staff           Lukas/Nitaco         ||\n" +
                "|| Roleplay Staff           Sopex                ||\n" +
                "|| Roleplay Staff           Gary                 ||\n" +
                "|| Freeroam Staff           James                ||\n" +
                "||===============================================||\n");

            #endregion // Copyright and Server information

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("\n-----------------------------------------------" +
                          "-----------------------------------------------" +
                          "\n");
            // Write information about Core startup
            Console.WriteLine("Initializing EvoMp Core...");

            // Init ModuleStructurer
            ModuleStructurer moduleStructurer = new ModuleStructurer();

            // Copy modules & NuGet files to Server
            moduleStructurer.RefreshResourceModules();
            moduleStructurer.CopyNuGetPackagesToServer();

            // Write complete & loading modules message
            Console.WriteLine("Initializing EvoMp Core completed.\n");

            // Load Modules
            new ModuleLoader(API).Load();

            Console.Write("-----------------------------------------------" +
                          "-----------------------------------------------" +
                          "\n");
        }
    }
}