using System;
using System.Collections.Generic;
using System.Linq;

namespace EvoMp.Core.Core
{
    public static class ModuleTypeHandler
    {
        private static string[] _serverTypes;

        public static string[] GetServerTypes()
        {
            // ServerType already setten -> return;
            if (_serverTypes != null)
                return _serverTypes;

            List<string> moduleTypes = new List<string>();

            foreach (string commandLineArg in Environment.GetCommandLineArgs())
                if(commandLineArg.ToLower().StartsWith("-g "))
                    moduleTypes.Add(commandLineArg.Substring("-g ".Length).Trim());

            //TODO: remove later or find better solution
            //TODO: Create issue for this todo
            if (!moduleTypes.Any())
            {
                moduleTypes.Add("freeroam");
                moduleTypes.Add("roleplay");
            }

            moduleTypes.Add("shared");

            _serverTypes = moduleTypes.ToArray();
            return _serverTypes;
        }

        public static bool IsModuleTypeValid(string moduleType)
        {
            return GetServerTypes().Select(s => s.ToLower()).Contains(moduleType.ToLower());
        }
    }
}
