using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Core.Module;
using GrandTheftMultiplayer.Server.API;
using Ninject;

namespace EvoMp.Core.Core
{
    public class ModuleLoader
    {
        public ModuleLoader(API api)
        {
            Api = api;
        }

        private API Api { get; }

        public void Load()
        {
            ConsoleOutput.PrintLine("-");
            ConsoleOutput.WriteLine(ConsoleType.Core, "Loading modules now.");

            // Collect module paths
            List<string> modulePaths = Directory.GetFiles(@".\resources\EvoMp\dist", "EvoMp.Module.*.dll",
                SearchOption.AllDirectories).ToList();

            // Bind modules
            IKernel kernel = BindModules(modulePaths);
            ConsoleOutput.WriteLine(ConsoleType.Core, "Loading modules completed.");
            ConsoleOutput.PrintLine("-");

            // Start modules
            ConsoleOutput.WriteLine(ConsoleType.Core, "Starting modules now.");
            StartModules(modulePaths, kernel);
            ConsoleOutput.WriteLine(ConsoleType.Core, "Starting modules completed.");
            ConsoleOutput.PrintLine("-");
        }

        /// <summary>
        ///     Trys to bind the given modules.
        ///     Print's hint if a module was created the wrong way
        /// </summary>
        /// <param name="modulePaths">Path to the modules, wich should binded</param>
        /// <returns>IKernel</returns>
        private IKernel BindModules(List<string> modulePaths)
        {
            //TODO: Write "getInstance" for standardKernel instance. Neccesarry for "onFly" module loding
            IKernel kernel = new StandardKernel();

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
                                $"~#51ff76~{moduleInterface.Name}~;~ skipped. Wrong gamemode.");
                            continue;
                        }

                        // Console output
                        ConsoleOutput.WriteLine(ConsoleType.Core,
                            $"~#51ff76~{moduleInterface.Name}~;~ -> ~#83ff9d~{moduleClass.FullName}~;~.");

                        // Bind module
                        kernel.Bind(moduleInterface, moduleClass).To(moduleClass).InSingletonScope()
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
            return kernel;
        }


        /// <summary>
        ///     Trys to start the given modules.
        ///     Print's hint if a module was created the wrong way
        /// </summary>
        /// <param name="modulePaths">Path to the modules, wich should started</param>
        /// <param name="kernel">The kernel</param>
        /// <returns>IKernel</returns>
        private void StartModules(List<string> modulePaths, IKernel kernel)
        {
            var possibleAfterEffects = false;

            // Process each module
            foreach (string modulePath in modulePaths)
                try
                {
                    // Load assembly
                    Assembly moduleAssembly = Assembly.LoadFrom(modulePath);
                    bool moduleIsCorrectImplemented = false;

                    // Search for "ModulePropert" interface class in assembly
                    // and, if given, start the module4
                    foreach (Type moduleClass in moduleAssembly.GetTypes())
                    foreach (Type moduleInterface in moduleClass.GetInterfaces())
                        if (Attribute.IsDefined(moduleInterface, typeof(ModuleProperties)))
                        {
                            moduleIsCorrectImplemented = true;

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
                                object instance = kernel.Get(moduleClass);
                                Shared.OnOnModuleLoaded(instance);
                            }
                            finally
                            {
                                ConsoleOutput.ResetPrefix();
                            }
                        }

                    // No implemention of "IModule" -> message
                    if (moduleIsCorrectImplemented == false)
                        ConsoleOutput.WriteLine(ConsoleType.Error,
                            $"Module ~o~\"{Path.GetFileNameWithoutExtension(modulePath)}\"~;~ is incorrect. " +
                            $"Implement the ~g~\"ModuleProperties\"~;~ attribute in the given module interface.");
                }
                catch (Exception exception)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Error,
                        $"The module ~o~{modulePath}~;~ could not start. ");

                    if (possibleAfterEffects)
                        ConsoleOutput.WriteLine(ConsoleType.Note,
                            "This could be a follow-up error, " +
                            "because other modules have not been started.");

                    possibleAfterEffects = true;

                    ConsoleOutput.WriteLine(ConsoleType.Error, $"{exception.Message}");
                    ConsoleOutput.WriteLine(ConsoleType.Empty, $"{exception.StackTrace}");
                }
        }
    }
}