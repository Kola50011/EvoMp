using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EvoMp.Core.ConsoleHandler;
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

            // Collec module paths
            List<string> modulePaths = Directory.GetFiles(@".\resources\EvoMp\dist", "EvoMp.Module.*.dll",
                SearchOption.AllDirectories).ToList();

            // Bind modules
            IKernel kernel = BindModules(modulePaths);
            ConsoleOutput.WriteLine(ConsoleType.Core, "Loading modules complete.");
            ConsoleOutput.PrintLine("-");

            // Start modules
            ConsoleOutput.WriteLine(ConsoleType.Core, "Starting modules now.");
            StartModules(modulePaths, kernel);
            ConsoleOutput.WriteLine(ConsoleType.Core, "Starting modules complete.");
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

            // Progressing each module
            foreach (string modulePath in modulePaths)
            {
                bool hasNeededInterface = false;

                // load assembly
                Assembly moduleAssembly = Assembly.LoadFrom(modulePath);

                //Search for interface that's using the ModuleProperties attribute
                foreach (Type moduleClass in moduleAssembly.GetTypes())
                    foreach (Type moduleInterface in moduleClass.GetInterfaces())
                        if (Attribute.IsDefined(moduleInterface, typeof(ModuleProperties.ModuleProperties)))
                        {
                            hasNeededInterface = true;

                            // Load module interface Attribute, to get module informations
                            ModuleProperties.ModuleProperties moduleProperties = (ModuleProperties.ModuleProperties)
                                Attribute.GetCustomAttribute(moduleInterface, typeof(ModuleProperties.ModuleProperties));

                            // Moduletype is not given as startup parameter -> Message & next module;
                            if (!ModuleTypeHandler.IsModuleTypeValid(moduleProperties.ModuleType))
                            {
                                ConsoleOutput.WriteLine(ConsoleType.Note,
                                    $"~m~  Skipped module ~o~\"{moduleInterface.Name}\"~w~. " +
                                    $"Model type isn't given.");
                                continue;
                            }

                            // Console output
                            ConsoleOutput.WriteLine(ConsoleType.Core,
                                $"~c~  Binding ~b~\"{moduleInterface.Name}\" ~w~" +
                                $"to ~b~\"{moduleClass.FullName}\"~w~.");

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
            // Process each module
            foreach (string modulePath in modulePaths)
            {
                // Load assembly
                Assembly moduleAssembly = Assembly.LoadFrom(modulePath);
                bool moduleIsCorrectImplemented = false;

                // Search for "ModulePropert" interface class in assembly
                // and, if given, start the module4
                foreach (Type moduleClass in moduleAssembly.GetTypes())
                    foreach (Type moduleInterface in moduleClass.GetInterfaces())
                        if (Attribute.IsDefined(moduleInterface, typeof(ModuleProperties.ModuleProperties)))
                        {
                            moduleIsCorrectImplemented = true;

                            // Load module properties from interface
                            ModuleProperties.ModuleProperties moduleProperties = (ModuleProperties.ModuleProperties)
                                Attribute.GetCustomAttribute(moduleInterface, typeof(ModuleProperties.ModuleProperties));

                            // Moduletype is not given as startup parameter -> next module;
                            if (!ModuleTypeHandler.IsModuleTypeValid(moduleProperties.ModuleType))
                                continue;

                            // Write console output
                            ConsoleOutput.WriteLine(ConsoleType.Core,
                                $"  Starting module ~b~\"{moduleInterface.Name}\"~w~ " +
                                              $"by ~c~\"{moduleProperties.ModuleAuthors}\"~w~.");
                            ConsoleOutput.WriteLine(ConsoleType.Core,
                                $"    ~w~> ~c~{moduleProperties.ModuleDescription}.");

                            //Save old Cursors position for clear startup output
                            var consoleCursorLeft = Console.CursorLeft;
                            var consoleCursorTop = Console.CursorTop;

                            // Start module
                            kernel.Get(moduleClass);

                            // Set last console cursor, clear line, reset cursor
                            Console.SetCursorPosition(consoleCursorLeft, consoleCursorTop);
                            ConsoleOutput.WriteEmptyLine();
                            Console.SetCursorPosition(consoleCursorLeft, consoleCursorTop);
                        }

                // No implemention of "IModule" -> message
                if (moduleIsCorrectImplemented == false)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Error,
                        $"  Module ~o~\"{Path.GetFileNameWithoutExtension(modulePath)}\"~w~ is incorrect. " +
                                      $"Implement the ~g~\"ModuleProperties\"~w~ attribute in the given module interface.");
                }
            }
        }
    }
}