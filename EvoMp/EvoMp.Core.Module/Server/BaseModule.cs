using System;
using System.Reflection;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Shared.Server;

namespace EvoMp.Core.Module.Server
{
    public abstract class BaseModule
    {
        protected BaseModule()
        {

            Assembly moduleAssembly = Assembly.GetCallingAssembly();
            foreach (Type moduleClass in moduleAssembly.GetTypes())
            foreach (Type moduleInterface in moduleClass.GetInterfaces())
                if (Attribute.IsDefined(moduleInterface, typeof(ModuleProperties)))
                {
                    // Load module properties from interface
                    ModuleProperties moduleProperties = (ModuleProperties)
                        Attribute.GetCustomAttribute(moduleInterface, typeof(ModuleProperties));

                    ConsoleOutput.SetPrefix("\t");
                    // Write console output
                    ConsoleOutput.WriteLine(ConsoleType.Core,
                        $"~#51ff76~{moduleInterface.Name}~;~ " +
                        $"[~#83ff9d~{moduleProperties.ModuleAuthors}~;~]: " +
                        $"~#3e8e64~\"{moduleProperties.ModuleDescription}\"");
                    ConsoleOutput.SetPrefix("\t\t ~w~> ~;~");
                    }
        }
    }
}
