using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using EvoMp.Core.ColorHandler.Server;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Parameter.Server;
using EvoMp.Core.Shared.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Core.Server
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
            DbConfiguration.SetConfiguration(new QueryLogDbConfiguration());
            try
            {
                #region Core preparing / initialization

                // Clear console, set console color & write copyright
                ConsoleUtils.Clear();

                // Prepare Console set title
                ConsoleHandler.Server.ConsoleHandler.PrepareConsole();

                #endregion // Core preparing / initialization

                ConsoleUtils.SetConsoleTitle("EvoMp GT-MP Server Core. All rights reserverd.");

                // Load Console params
                ParameterHandler.LoadParams();

                CheckDatabaseReset();

                // Load logo
                ParameterHandler.SetDefault("LogoPath", "./ServerFiles/Default_Logo.txt");
                string asciiLogoFile = ParameterHandler.GetValue("LogoPath");

                #region Logo, Copyright, Server informations

                ConsoleOutput.PrintLine("-", "~#E6E6E6~");

                // Write logo from logo file
                ConsoleOutput.WriteCentredText(ConsoleType.Note,
                    ConsoleUtils.ParseTextFileForConsole($"{asciiLogoFile}", 2, 1));

                // No Logo defined -> message and use default Logo
                if (ParameterHandler.IsDefault("LogoPath"))
                    ConsoleOutput.WriteCentredText(ConsoleType.Config,
                        $"Using logo file ~o~\"{Path.GetFullPath($"{asciiLogoFile}")}\"~;~.\n" +
                        $"Please start your server with the ~b~" +
                        $"LogoPath ~;~ " +
                        $"parameter.");

                // GetServerGamemodes writes cfg message to if not setten
                string moduleTypesString =
                    string.Join(", ",
                        ModuleTypeHandler.GetServerGamemodes().ToList().ConvertAll(input => input.ToUpper()));

                const string leftServerInfo = "~#90A4AE~";
                const string rightServerInfo = "~#ECEFF1~";

                // Tiny gray line & Empty
                ConsoleOutput.PrintLine(" ");

                // Small centered line with headline & developer
                ConsoleOutput.WriteCentredText(ConsoleType.Note,
                    "".PadRight(80, '-') + "\n" +
                    "Server information\n" +
                    "".PadRight(80, '-'));

                ConsoleOutput.WriteCentredText(ConsoleType.Info,
                    $"{leftServerInfo}{"Server mode:".PadRight(35)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{moduleTypesString}".PadRight(35)}\n" +
                    $"{leftServerInfo}{"Runtime mode:".PadRight(35)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{(Debug ? "Debugging" : "Release")}".PadRight(35)}\n" +
                    $"{leftServerInfo}{"Server name:".PadRight(35)}{string.Empty.PadRight(5)}{rightServerInfo}{API.getServerName()}{"".PadRight(ColorUtils.CleanUp(API.getServerName()).Length > 35 ? 0 : 35 - ColorUtils.CleanUp(API.getServerName()).Length)}\n" +
                    $"{leftServerInfo}{"Server port:".PadRight(35)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{API.getServerPort():0000}".PadRight(35)}\n" +
                    $"{leftServerInfo}{"Max players:".PadRight(35)}{string.Empty.PadRight(5)}{rightServerInfo}{$"{API.getMaxPlayers():0000}".PadRight(35)}\n");

                // One empty lines
                ConsoleOutput.PrintLine(" ");

                // Small centered line with headline & developer
                ConsoleOutput.WriteCentredText(ConsoleType.Note,
                    "".PadRight(80, '-') + "\n" +
                    "Developer team\n" +
                    "".PadRight(80, '-'));

                const string usernameColor = "~#ECEFF1~";
                const string diTitleColor = "~#03A9F4~";
                const string depyTitleColor = "~#4FC3F7~";
                const string staffTitleColor = "~#B3E5FC~";

                ConsoleOutput.WriteCentredText(ConsoleType.Note,
                    $"{diTitleColor}{"Freeroam Director".PadRight(35)}{string.Empty.PadRight(5)}{usernameColor}{"Ruffo ~c~(Christian Groothoff)".PadRight(35+3)}\n" +
                    $"{depyTitleColor}{"Freeroam Deputy".PadRight(35)}{string.Empty.PadRight(5)}{usernameColor}{"Koka".PadRight(35)}\n" +
                    $"{depyTitleColor}{"Freeroam Staff".PadRight(35)}{string.Empty.PadRight(5)}{usernameColor}{"Sascha".PadRight(35)}\n" +
                    $"{staffTitleColor}{"Freeroam Staff".PadRight(35)}{string.Empty.PadRight(5)}{usernameColor}{"James".PadRight(35)}\n"
                );

                ConsoleOutput.PrintLine(" ");

                // Startup parameters
                ConsoleOutput.WriteCentredText(ConsoleType.Note,
                    "".PadRight(80, '-') + "\n" +
                    "Startup Parameters\n" +
                    "".PadRight(80, '-'));
                ParameterHandler.PrintArgs();

                ConsoleOutput.PrintLine(" ");
                ConsoleOutput.PrintLine("-");

                #endregion Logo, Copyright, Server informations

                // Only copy and then stop. Used for docker

                ParameterHandler.SetDefault("onlyCopy", "false");

                // Write information about Core startup
                ConsoleOutput.WriteLine(ConsoleType.Core, "Initializing EvoMp Core...");

                // Init ModuleStructurer
                ModuleStructurer moduleStructurer = new ModuleStructurer();

                // Copy modules & NuGet files to Server
                moduleStructurer.CopyModulesToServer();
                moduleStructurer.CopyNuGetPackagesToServer();

                // Write complete & loading modules message
                ConsoleOutput.WriteLine(ConsoleType.Core, "Initializing EvoMp Core completed.");

                if (!ParameterHandler.IsDefault("onlyCopy"))
                {
                    // Finish sequence
                    SharedEvents.OnOnCoreStartupCompleted();
                    ConsoleOutput.WriteLine(ConsoleType.Core, "Core startup completed");
                    ConsoleOutput.PrintLine("-");

                    ConsoleOutput.WriteLine(ConsoleType.Core, "OnlyCopy parameter has been detected! Stopping Server!");
                    Environment.Exit(0);
                }
                else
                {
                    SharedEvents.OnOnModuleLoadingStart(API);

                    // Load Modules
                    new ModuleLoader(API).Load();

                    // Finish sequence
                    SharedEvents.OnOnCoreStartupCompleted();
                    ConsoleOutput.WriteLine(ConsoleType.Core, "Core startup completed");
                    ConsoleOutput.PrintLine("-");
                }

                SharedEvents.OnOnAfterCoreStartupCompleted();
            }
            catch (Exception e)
            {
                ConsoleOutput.FinalConsoleWrite(e.ToString(), true);
            }
        }

        /// <summary>
        ///     Checks if the Database should reset.
        /// </summary>
        private static void CheckDatabaseReset()
        {
            // Init reset procedure if database reset wanted.
            if (ParameterHandler.GetValue("ResetDatabase") == null)
                return;

            const string database = "EvoMpGtMpServer";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                      //"Initial Catalog=master" +
                                      ";Integrated Security=True;" +
                                      $"Connect Timeout=30;" +
                                      $"Encrypt=False;" +
                                      $"TrustServerCertificate=True;" +
                                      $"ApplicationIntent=ReadWrite;" +
                                      "MultiSubnetFailover=False;" +
                                      "MultipleActiveResultSets = True;";

            // Write console output
            ConsoleOutput.WriteLine(ConsoleType.Database, $"Deleting Database ~o~{database}~;~.");
            string sqlCommandText = $"DROP DATABASE {database}";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            ConsoleOutput.WriteLine(ConsoleType.Database, $"Database ~o~{database}~;~ deleted.");
        }
    }
}
