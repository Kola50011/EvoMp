using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            // Message (gray color)
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Loading modules now.");

            // Collec module paths
            List<string> modulePaths = Directory.GetFiles(@".\resources\EvoMp\dist", "EvoMp.Module.*.dll",
                    SearchOption.AllDirectories).ToList();

            // Bind & start modules
            IKernel kernel = BindModules(modulePaths);
            Console.WriteLine("\t-----------------------------------------------" +
                              "-----------------------------------------------");
            StartModules(modulePaths, kernel);

            // Message with "done" info (gray) & reset ConsoleColor
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Loading modules complete.");
            Console.ResetColor();
        }

        /// <summary>
        /// Trys to bind the given modules.
        /// Print's hint if a module was created the wrong way 
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
                //  load assembly
                Assembly moduleAssembly = Assembly.LoadFrom(modulePath);
                bool moduleUsingIModule = false;

                // Search for "IModule" interface class in assembly
                // and, if given, bind the module
                foreach (Type moduleClass in moduleAssembly.GetTypes())
                    foreach (Type moduleInterface in moduleClass.GetInterfaces())
                        if (moduleInterface.GetInterface(typeof(IModule).ToString()) != null)
                        {
                            Console.WriteLine(
                                $"\tBinding \"{moduleInterface.FullName}\" to \"{moduleClass.FullName}\".");

                            // Bind module
                            kernel.Bind(moduleInterface, moduleClass).To(moduleClass).InSingletonScope()
                                .WithConstructorArgument("api", context => Api);
                            moduleUsingIModule = true;
                        }

                // No implemention of "IModule" -> message
                if (!moduleUsingIModule)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\tModule \"{Path.GetFileNameWithoutExtension(modulePath)}\" is incorrect. " +
                                      $"Implement the \"IModule\" interface in the given module.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            // return created kernel
            return kernel;
        }


        /// <summary>
        /// Trys to start the given modules.
        /// Print's hint if a module was created the wrong way 
        /// </summary>
        /// <param name="modulePaths">Path to the modules, wich should started</param>
        /// <returns>IKernel</returns>
        private void StartModules(List<string> modulePaths, IKernel kernel)
        {
            // Process each module
            foreach (string modulePath in modulePaths)
            {
                // Load assembly
                Assembly moduleAssembly = Assembly.LoadFrom(modulePath);
                bool moduleStarted = false;

                // Search for "IModule" interface class in assembly
                // and, if given, start the module
                foreach (Type moduleClass in moduleAssembly.GetTypes())
                    foreach (Type moduleInterface in moduleClass.GetInterfaces())
                        if (moduleInterface.GetInterface(typeof(IModule).ToString()) != null)
                        {
                            Console.WriteLine($"\tStarting module \"{moduleClass.FullName}\".");
                            kernel.Get(moduleClass);
                            moduleStarted = true;
                        }

                // No implemention of "IModule" -> message
                if (moduleStarted == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\tModule \"{Path.GetFileNameWithoutExtension(modulePath)}\" is incorrect. " +
                                      $"Implement the \"IModule\" interface in the given module.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}