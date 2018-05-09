using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Core.Core.Server.Exceptions;
using EvoMp.Core.Module.Server;
using EvoMp.Core.Shared.Server;
using GrandTheftMultiplayer.Server.API;
using Ninject;
using Ninject.Infrastructure.Language;

namespace EvoMp.Core.Core.Server
{
    /// <summary>
    ///     The ModuleLoader class.
    ///     Relevant for module loading and starting.
    /// </summary>
    public class ModuleLoader
    {
        private readonly IKernel _kernel;
        private readonly List<Assembly> _moduleAssemblies;

        /// <summary>
        ///     Creates instance of the module loader
        /// </summary>
        /// <param name="api">The GTMP api instance. Used for Ninject.</param>
        public ModuleLoader(API api)
        {
            Api = api;
            _kernel = new StandardKernel();
            _moduleAssemblies = new List<Assembly>();
        }

        private API Api { get; }

        /// <summary>
        ///     The full module loading and startup
        /// </summary>
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
        private void BindModules(IEnumerable<string> modulePaths)
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
                        //  Main module class didn't based on BaseModule -> Exception
                        if (!moduleClass.GetAllBaseTypes().Contains(typeof(BaseModule)))
                            throw new NotValidModuleException(
                                $"The module {modulePath} didn't base on the \"BaseModule\" abstract class." +
                                Environment.NewLine +
                                "Inherit from the BaseModule class.");

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
                            .WithConstructorArgument("api", context => Api).OnActivation(SharedEvents.OnOnModuleLoaded);
                    }

                // No implemention of "ModuleProperties" -> exception
                if (!hasNeededInterface)
                    throw new NotValidModuleException(
                        $"The module {modulePath} didn't implement the \"ModuleAttribute\" " +
                        "in the main Interface. " + Environment.NewLine +
                        "Please add the needed interface");
            }

            // Sort modules by priority
            _moduleAssemblies.Sort((assembly1, assembly2) =>
            {
                int GetAssemblyPrio(Assembly ass)
                {
                    foreach (Type moduleClass in ass.GetTypes())
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

                            return moduleProperties.Priority;
                        }

                    return int.MaxValue;
                }

                return GetAssemblyPrio(assembly1).CompareTo(GetAssemblyPrio(assembly2));
            });
            ConsoleOutput.WriteLine(ConsoleType.Core, "Sort modules done.");


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
            {
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
                                // Start module
                                _kernel.Get(moduleClass);
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
                    possibleAfterEffects = true;
#if DEBUG
                    throw;
#endif
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
#if DEBUG
                    throw;
#endif
                }
            }
        }
    }
}
