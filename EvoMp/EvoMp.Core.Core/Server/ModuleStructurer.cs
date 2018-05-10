using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using EvoMp.Core.ConsoleHandler.Server;

#if !DEBUG
using EvoMp.Core.Parameter.Server;

#endif

namespace EvoMp.Core.Core.Server
{
    //TODO: @OpenSource "EvoMp" entfernen
    public class ModuleStructurer
    {
        /// <summary>
        ///     Refreshing the server resource modules.
        ///     Hint: Runs only if "DEBUG" constant is given
        /// </summary>
        public void CopyModulesToServer()
        {
#if !DEBUG
            if (ParameterHandler.IsDefault("onlyCopy"))
            {
                ConsoleOutput.WriteLine(ConsoleType.Core, "Release state. Copying modules skipped.");
                return;
            }
#endif
            ConsoleOutput.WriteLine(ConsoleType.Core,
                $"Refreshing server resource modules...");
            // Define constants for the folder top copy from and to copy to
            const string gtMpServerModulesFolder = @"./resources/EvoMp/dist";
            const string projectSolutionCompiledModulesFolder = @"./../EvoMp/";


            // Create the Modules folder in the resource if it doesnt exist
            if (!Directory.Exists(gtMpServerModulesFolder))
                Directory.CreateDirectory(gtMpServerModulesFolder);

            // Delete old modules
            List<string> oldModules = Directory.EnumerateFiles(gtMpServerModulesFolder, "EvoMp.Module.*.*",
                    SearchOption.AllDirectories)
                .Where(file => file.Contains("EvoMp.Module."))
                .ToList();

            // Get the DLLs from the project folders
            // (Including *.pdb files. Used for debugging)
            try
            {
                ConsoleOutput.AppendPrefix("\t");
                // Search for modules.
                List<string> newModules = Directory.EnumerateFiles(projectSolutionCompiledModulesFolder,
                    "EvoMp.Module.*.*",
                    SearchOption.AllDirectories).ToList();
                newModules = newModules.Select(file => file.Replace(@"\", "/")).ToList();

                newModules = newModules.Where(path => path.Contains("bin/"))
                    .Where(file =>
                        file.ToLower().EndsWith("dll") || file.ToLower().EndsWith("pdb") ||
                        file.ToLower().EndsWith("xml"))
                    .ToList();

                const string slash = "/";

                // Clean old modules wich existing as dll's in other modules
                foreach (string module in newModules.ToArray())
                {
                    // modulePath contains no "\" -> next
                    if (!module.Contains(slash))
                        continue;

                    string moduleFile = module.Substring(module.LastIndexOf(slash, StringComparison.Ordinal) + 1);
                    string modulePath = module.Substring(0, module.LastIndexOf(slash, StringComparison.Ordinal));

                    // ModuleFile contains no "." -> next
                    if (!moduleFile.Contains("."))
                        continue;
                    // Remove .dll .pdb etc..
                    moduleFile = moduleFile.Substring(0, moduleFile.LastIndexOf(".", StringComparison.Ordinal));

                    // Path didn't contains the name of the module file -> remove from new modules
                    if (!modulePath.Contains(moduleFile))
                        newModules.Remove(module);
                }

                // Copy new modules
                foreach (string newModule in newModules)
                {
                    string destFile = gtMpServerModulesFolder + slash + Path.GetFileName(newModule);

                    // Destfile exist & destfile is same to new file -> skip
                    if (File.Exists(destFile))
                        if (new FileInfo(destFile).LastWriteTime >= new FileInfo(newModule).LastWriteTime)
                            continue;

                    // Copy new module & write message
                    File.Copy(newModule, destFile, true);
                    if (destFile.EndsWith(".dll"))
                        ConsoleOutput.WriteLine(ConsoleType.Core,
                            $"Copying module: ~#83cfff~\"{Path.GetFileName(destFile)}\".");
                }

                // Delete old modules
                foreach (string deleteModule in oldModules.Where(t => !newModules.Select(Path.GetFileName)
                    .Contains(Path.GetFileName(t))))
                {
                    File.Delete(deleteModule);
                    ConsoleOutput.WriteLine(ConsoleType.Core,
                        $"Delete old module: ~#83cfff~\"{Path.GetFileName(deleteModule)}\".");
                }

                ConsoleOutput.ResetPrefix();
            }
            catch (Exception exception)
            {
                // Throw exception
                throw new Exception($"Internal error in \"EvoMp.Core.Core.ModuleStructure\" " +
                                    $"{Environment.NewLine}" +
                                    $"{exception.Message}{Environment.NewLine}" +
                                    $"{exception.StackTrace}");
            }
        }

        /// <summary>
        ///     Copying NuGet packages to the gtmp server files
        ///     Hint: Runs only if "DEBUG" constant is given
        /// </summary>
        public void CopyNuGetPackagesToServer()
        {
#if !DEBUG
            if (ParameterHandler.IsDefault("onlyCopy"))
            {
                ConsoleOutput.WriteLine(ConsoleType.Core, "Release state. Copying NuGet packeges skipped.");
                return;
            }
#endif
            const string serverRootFolder = ".";

            const string projectSolutionNuGetPackagesFolder = @"../EvoMp/packages";

            try
            {
                // Search for solution NuGet packages
                ConsoleOutput.WriteLine(ConsoleType.Core,
                    $"Searching for new dependencies in " +
                    $"~#83cfff~\"{Path.GetFullPath(projectSolutionNuGetPackagesFolder)}\\*\"~;~.");
                List<string> packageFiles = Directory.EnumerateFiles(projectSolutionNuGetPackagesFolder, "*",
                        SearchOption.AllDirectories)
                    .Where(file => file.ToLower().EndsWith("dll") || file.ToLower().EndsWith("xml"))
                    .Where(file => file.Contains(@"lib\net45"))
                    .Where(file => !Path.GetFileName(file).ToLower().StartsWith("evomp"))
                    .ToList();

                // Clear duplicates
                packageFiles = packageFiles.Distinct().ToList();


                ConsoleOutput.WriteLine(ConsoleType.Core, "Using dependencies: ");
                ConsoleOutput.AppendPrefix("\t");

                List<string> usedPackagesList = new List<string>();
                // Copy new NuGet packages
                foreach (string packageFile in packageFiles)
                {
                    if (packageFile.EndsWith(".dll"))
                    {
                        string packageName = Path.GetFileName(packageFile).Replace("\\", "/");

                        // Packed already loaded -> continue;
                        if(usedPackagesList.Contains(packageName))
                            continue;

                            ConsoleOutput.WriteLine(ConsoleType.Core,
                                $"~#83cfff~\"{packageName}\".");

                        usedPackagesList.Add(packageName);
                    }

                    // Get target filename
                    string destinationFile = serverRootFolder + @"/" + Path.GetFileName(packageFile).Replace("\\", "/");

                    // File exist -> Check creation date and delete if older
                    if (File.Exists(destinationFile))
                    {
                        // File is newest -> skip
                        if (new FileInfo(destinationFile).LastWriteTime >= new FileInfo(packageFile).LastWriteTime)
                            continue;

                        // Try to delete older file, if fails, skip file..
                        // I knew, not the best way. 
                        // Feel free if u knew a better way.. 
                        // (But info one of the project directors about our change)
                        try
                        {
                            File.Delete(destinationFile);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    // Copy file & message
                    File.Copy(packageFile, destinationFile);
                }

                ConsoleOutput.ResetPrefix();
            }
            catch (Exception exception)
            {
                // Throw exception
                throw new Exception($"Internal error in \"EvoMp.Core.Core.CopyNuGetPackagesToServer\" " +
                                    $"{Environment.NewLine}" +
                                    $"{exception.Message}{Environment.NewLine}" +
                                    $"{exception.StackTrace}");
            }
        }
    }
}
