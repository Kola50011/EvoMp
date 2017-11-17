using System;
using System.IO;
using System.Linq;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Core.Module;
using EvoMp.Core.Parameter;
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

        public Main()
        {

            try
            {
                #region Core preparing / initialization

                // Clear console, set console color & write copyright
                ConsoleOutput.Clear();

                // Prepare Console set title
                ConsoleHandler.ConsoleHandler.PrepareConsole();

                // Register Core Parameter Enum
                ParameterHandler.RegisterParameterEnum(new CoreParameter());

                #endregion // Core preparing / initialization

                ConsoleOutput.SetConsoleTitle("EvoMp GT-MP Server Core. All rights reserverd.");

                // Load core startup parameter
                string asciiLogoFile = ParameterHandler.GetFirstParameterValue(CoreParameter.LogoFileName);

                #region Logo, Copyright, Server informations

                ConsoleOutput.PrintLine("-", "~#E6E6E6~");

                // Write logo from logo file
                ConsoleOutput.WriteCentredText(ConsoleType.Note, 
                    ConsoleUtils.ParseTextFileForConsole($"{asciiLogoFile}",2, 1));

                // No Logo defined -> message and use default Logo
                if (asciiLogoFile == ParameterHandler.GetParameterProperties(CoreParameter.LogoFileName).DefaultValue)
                {
                    ConsoleOutput.WriteCentredText(ConsoleType.Config,
                        $"Using logo file ~o~\"{Path.GetFullPath($"{asciiLogoFile}")}\"~;~.\n" +
                        $"Please start your server with the ~b~" +
                        $"\"{ParameterHandler.GetParameterProperties(CoreParameter.LogoFileName).ParameterIdentifier}\" ~;~ " +
                        $"parameter.");
                }

                // GetServerGamemodes writes cfg message to if not setten
                string moduleTypesString =
                    string.Join(", ", ModuleTypeHandler.GetServerGamemodes().ToList().ConvertAll(input => input.ToUpper()));

                const string leftServerInfo = "~#90A4AE~";
                const string rightServerInfo = "~#ECEFF1~";

                // Tiny gray line & Empty
                ConsoleOutput.PrintLine(" ");

                // Small centered line with headline & developer
                ConsoleOutput.WriteCentredText(ConsoleType.Note,
                    "".PadRight(55, '-') + "\n" +
                    "Server information\n" +
                    "".PadRight(55, '-'));

                ConsoleOutput.WriteCentredText(ConsoleType.Info,
                    $"{leftServerInfo}{"Server mode:".PadRight(20)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{moduleTypesString}".PadRight(20)}\n" +
                    $"{leftServerInfo}{"Runtime mode:".PadRight(20)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{(Debug ? "Debugging" : "Release")}".PadRight(20)}\n" +
                    $"{leftServerInfo}{"Server name:".PadRight(20)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{API.getServerName().Substring(0, 20)}".PadRight(20)}\n" +
                    $"{leftServerInfo}{"Server port:".PadRight(20)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{API.getServerPort():0000}".PadRight(20)}\n" +
                    $"{leftServerInfo}{"Max players:".PadRight(20)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{API.getMaxPlayers():0000}".PadRight(20)}\n");

                // One empty lines
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
                    $"{diTitleColor}{"Roleplay Director".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"DevGrab".PadRight(20)}\n" +
                    $"{diTitleColor}{"Freeroam Director".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"Ruffo/Christian".PadRight(20)}\n" +
                    $"{depyTitleColor}{"Roleplay Deputy".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"Sascha".PadRight(20)}\n" +
                    $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"Koka".PadRight(20)}\n" +
                    $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"Lukas/Nitac".PadRight(20)}\n" +
                    $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"Sopex".PadRight(20)}\n" +
                    $"{staffTitleColor}{"Roleplay Staff".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"Gary".PadRight(20)}\n" +
                    $"{staffTitleColor}{"Freeroam Staff".PadRight(20)}{string.Empty.PadRight(5)}{usernameColor}{"James".PadRight(20)}\n");
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

                Shared.OnOnModuleLoadingStart(API);

                // Load Modules
                new ModuleLoader(API).Load();
                ConsoleOutput.WriteLine(ConsoleType.Core, "Core startup completed");
                ConsoleOutput.PrintLine("-");
                Shared.OnOnCoreStartupCompleted();
            }
            catch (Exception e)
            {
                Console.SetOut(ConsoleHandler.ConsoleHandler.OriginalTextWriter);
                Console.WriteLine(e);
                //throw;
            }
        }
    }
}