using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Module.Server;
using EvoMp.Core.Shared.Server;
using GrandTheftMultiplayer.Server.API;
using Ninject;

namespace EvoMp.Core.Core.Server
{
    public class ModuleLoader
    {
        private readonly IKernel _kernel;
        private readonly List<Assembly> _moduleAssemblies;
        public ModuleLoader(API api)
        {
            Api = api;
            _kernel = new StandardKernel();
            _moduleAssemblies = new List<Assembly>();
        }

        private API Api { get; }

        public void Load()
        {
            ConsoleOutput.PrintLine("-");
            ConsoleOutput.WriteLine(ConsoleType.Core, "Loading modules now.");

            List<string> modulePaths = Directory.GetFiles("./resources/EvoMp/dist", "EvoMp.Module.*.dll",
                SearchOption.AllDirectories).ToList();

            // Bind modules
            BindModules(modulePaths);
            ConsoleOutput.WriteLine(ConsoleType.Core, "Loading modules completed.");
            ConsoleOutput.PrintLine("-");

            // Start modules
            ConsoleOutput.WriteLine(ConsoleType.Core, "Starting modules now.");
            StartModules();
            ConsoleOutput.WriteLine(ConsoleType.Core, "Starting modules completed.");
            ConsoleOutput.PrintLine("-");
        }

        /// <summary>
        ///     Trys to bind the given modules.
        ///     Print's hint if a module was created the wrong way
        /// </summary>
        /// <param name="modulePaths">Path to the modules, wich should binded</param>
        /// <returns>IKernel</returns>
        private void BindModules(List<string> modulePaths)
        {
            ConsoleOutput.AppendPrefix("\t");
            // Progressing each module
            foreach (string modulePath in modulePaths)
            {
                bool hasNeededInterface = false;

                // load assembly
                Assembly moduleAssembly = Assembly.LoadFrom(modulePath);

                //Search for interface that's using the ModuleProperties attribute
                foreach (Type moduleClass in moduleAssembly.GetTypes())
                foreach (Type moduleInterface in moduleClass.GetInterfaces())
                    if (Attribute.IsDefined(moduleInterface, typeof(ModuleProperties)))
                    {
                        hasNeededInterface = true;

                        // Load module interface Attribute, to get module informations
                        ModuleProperties moduleProperties = (ModuleProperties)
                            Attribute.GetCustomAttribute(moduleInterface, typeof(ModuleProperties));

                        // Moduletype is not given as startup parameter -> Message & next module;
                        if (!ModuleTypeHandler.IsModuleTypeValid(moduleProperties.ModuleType))
                        {
                            ConsoleOutput.WriteLine(ConsoleType.Core,
                                $"~#51ff76~{moduleInterface.Name}~;~ skipped. Wrong gamemode. ~c~{moduleProperties.ModuleType}");
                            continue;
                        }

                        // Console output
                        ConsoleOutput.WriteLine(ConsoleType.Core,
                            $"~#51ff76~{moduleInterface.Name}~;~ -> ~#83ff9d~{moduleClass.FullName}~;~.");

                        // Add to list & bind module
                        _moduleAssemblies.Add(moduleAssembly);
                        _kernel.Bind(moduleInterface, moduleClass).To(moduleClass).InSingletonScope()
                            .WithConstructorArgument("api", context => Api);
                    }

                // No implemention of "ModuleProperties" -> exception
                if (!hasNeededInterface)
                    throw new Exception($"The module {modulePath} didn't implement the \"ModuleAttribute\" " +
                                        $"in the main Interface. " + Environment.NewLine +
                                        "Please add the needed interface");
            }
            ConsoleOutput.ResetPrefix();
            // return created kernel
        }


        /// <summary>
        ///     Trys to start the given modules.
        ///     Print's hint if a module was created the wrong way
        /// </summary>
        private void StartModules()
        {
            bool possibleAfterEffects = false;

            // Process each module
            foreach (Assembly moduleAssembly in _moduleAssemblies)
                try
                {
                    // Search for "ModulePropert" interface class in assembly
                    // and, if given, start the module4
                    foreach (Type moduleClass in moduleAssembly.GetTypes())
                    foreach (Type moduleInterface in moduleClass.GetInterfaces())
                        if (Attribute.IsDefined(moduleInterface, typeof(ModuleProperties)))
                        {
                            // Load module properties from interface
                            ModuleProperties moduleProperties = (ModuleProperties)
                                Attribute.GetCustomAttribute(moduleInterface, typeof(ModuleProperties));

                            // Moduletype is not given as startup parameter -> next module;
                            if (!ModuleTypeHandler.IsModuleTypeValid
                                (moduleProperties.ModuleType))
                                continue;
                            try
                            {
                                ConsoleOutput.AppendPrefix("\t");
                                // Write console output
                                ConsoleOutput.WriteLine(ConsoleType.Core,
                                    $"~#51ff76~{moduleInterface.Name}~;~ " +
                                    $"[~#83ff9d~{moduleProperties.ModuleAuthors}~;~]: " +
                                    $"~c~{moduleProperties.ModuleDescription}");

                                ConsoleOutput.AppendPrefix("\t ~w~> ~;~");

                                // Start module
                                object instance = _kernel.Get(moduleClass);
                                SharedEvents.OnOnModuleLoaded(instance);
                            }
                            finally
                            {
                                ConsoleOutput.ResetPrefix();
                            }
                        }
                }
                catch (ActivationException e)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Error,
                        $"The module ~o~{moduleAssembly.FullName}~;~ could not start, because one or more dependecies are missing!.");

                    if (possibleAfterEffects)
                        ConsoleOutput.WriteLine(ConsoleType.Note,
                            "This could be a follow-up error, " +
                            "because other modules have not been started.");

                    ConsoleOutput.WriteLine(ConsoleType.Error, $"{e.Message}");
                }
                catch (Exception e)
                {
                    ConsoleOutput.PrintLine("=", "~#FFF~", ConsoleType.Error);

                    ConsoleOutput.WriteLine(ConsoleType.Error,
                        $"The module ~o~{moduleAssembly.FullName}~;~ could not start. ");

                    if (possibleAfterEffects)
                        ConsoleOutput.WriteLine(ConsoleType.Note,
                            "This could be a follow-up error, " +
                            "because other modules have not been started.");

                    possibleAfterEffects = true;

                    ConsoleOutput.WriteLine(ConsoleType.Error, $"~#FF0000~{e.Message}");
                    ConsoleOutput.WriteLine(ConsoleType.Error, $"~#FF0000~{e.StackTrace}");
                    ConsoleOutput.PrintLine("=", "~#FFF~", ConsoleType.Error);
                }
        }
    }
}
