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

            if (!moduleTypes.Any())
                moduleTypes.Add("any");

            moduleTypes.Add("shared");

            _serverTypes = moduleTypes.ToArray();
            return _serverTypes;
        }

        public static bool IsModuleTypeValid(string moduleType)
        {
            return GetServerTypes().Contains("any") || 
                GetServerTypes().Select(s => s.ToLower()).Contains(moduleType.ToLower());
        }
    }
}
