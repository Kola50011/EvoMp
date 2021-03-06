using System.Collections.Generic;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Parameter.Server;

namespace EvoMp.Core.Core.Server
{
    public static class ModuleTypeHandler
    {
        private static string[] _serverTypes;

        /// <summary>
        ///     Gets the given server gamemodes.
        ///     The gamemodes are used to load modules filtered.
        ///     If no gamemodes given, any modules would be loaded.
        /// </summary>
        /// <returns>Array[string] with server gamemodes</returns>
        public static string[] GetServerGamemodes()
        {
            // Set defaults
            ParameterHandler.SetDefault("Gamemode", "any");

            // ServerType already setten -> return;
            if (_serverTypes != null)
                return _serverTypes;

            List<string> serverGamemodes = ParameterHandler.GetValue("Gamemode").Split(',').ToList();
            serverGamemodes.ForEach(x => x = x.Trim());

            // Only default parameter gamemode value loaded -> warning
            if (ParameterHandler.IsDefault("Gamemode"))
                ConsoleOutput.WriteLine(ConsoleType.Config,
                    $"~-^-~The server started without defined gamemodes, so the default value~o~ \"any\"~;~ was used. " +
                    $"Nevertheless, it is strongly advised to include the desired gamemodes, " +
                    $"because mode ~o~\"any\"~;~ could have massive side effects.~-v-~");

            // Shared is always needed
            serverGamemodes.Add("shared");

            // Cast to array
            _serverTypes = serverGamemodes.ToArray();
            return _serverTypes;
        }

        public static bool IsModuleTypeValid(string moduleType)
        {
            return (GetServerGamemodes().Contains("any") ||
                    GetServerGamemodes().Select(s => s.ToLower()).Contains(moduleType.ToLower())) &&
                   moduleType.ToLower() != "disabled";
        }
    }
}
