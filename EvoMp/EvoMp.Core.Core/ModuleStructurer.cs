using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EvoMp.Core.Core
{
    public class ModuleStructurer
    {
        /// <summary>
        ///     Refreshing the server resource modules.
        ///     If module was updated -> replacing
        ///     Module deleted -> deleting
        ///     Hint: Runs only if "DEBUG" constant is given
        /// </summary>
        public void RefreshResourceModules()
        {
#if !DEBUG
            Console.WriteLine("Release state. Copying modules skipped.");
            return;
#endif
            Console.WriteLine(
                $"Refreshing server resource modules...");
            // Define constants for the folder top copy from and to copy to
            const string gtMpServerModulesFolder = @".\resources\EvoMp\dist";
            const string projectSolutionCompiledModulesFolder = @".\..\EvoMp";

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
                // Search for modules.
                List<string> newModules = Directory.EnumerateFiles(projectSolutionCompiledModulesFolder,
                        "EvoMp.Module.*.*",
                        SearchOption.AllDirectories)
                    .Where(path => path.Contains(@"bin\Debug"))
                    .Where(file => file.ToLower().EndsWith("dll") || file.ToLower().EndsWith("pdb"))
                    .ToList();

                // Copy new modules
                foreach (string newModule in newModules)
                {
                    string destFile = gtMpServerModulesFolder + @"\" + Path.GetFileName(newModule);

                    // Destfile exist & destfile is same to new file -> skip
                    if (File.Exists(destFile))
                        if (new FileInfo(destFile).LastWriteTime >= new FileInfo(newModule).LastWriteTime)
                            continue;

                    // Copy new module & write message
                    File.Copy(newModule, destFile, true);
                    if (destFile.EndsWith(".dll"))
                        Console.WriteLine($"\tCopying module: \"{Path.GetFileName(destFile)}\".");
                }

                // Delete old modules
                foreach (string deleteModule in oldModules.Where(t => !newModules.Select(Path.GetFileName)
                    .Contains(Path.GetFileName(t))))
                {
                    File.Delete(deleteModule);
                    Console.WriteLine($"\tDeleted old module: \"{Path.GetFileName(deleteModule)}\".");
                }
            }
            catch (Exception exception)
            {
                // Throw exception
                throw new Exception($"\tInternal error in \"EvoMp.Core.Core.ModuleStructure\" " +
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
            Console.WriteLine("Release state. Copying NuGet packeges skipped.");
            return;
#endif
            const string serverRootFolder = ".";
            const string projectSolutionModulesFolder = @"..\EvoMp";
            const string projectSolutionModulesPackagesPattern = @"*";

            const string projectSolutionNuGetPackagesFolder = @"..\EvoMp\packages";

            try
            {
                // Search for module NuGet Packages
                Console.WriteLine(
                    $"Searching for new module dependency packages in " +
                    $"\"{Path.GetFullPath(projectSolutionModulesFolder)}\\*\".");
                List<string> packageFiles = Directory.EnumerateFiles(projectSolutionModulesFolder,
                        projectSolutionModulesPackagesPattern,
                        SearchOption.AllDirectories)
                    .Where(file => file.ToLower().EndsWith("dll") || file.ToLower().EndsWith("xml"))
                    .Where(file => !Path.GetFileName(file).ToLower().StartsWith("evomp"))
                    .ToList();

                // Search for solution NuGet packages
                Console.WriteLine(
                    $"Searching for new solution dependency packages in " +
                    $"\"{Path.GetFullPath(projectSolutionNuGetPackagesFolder)}\\*\".");
                packageFiles.AddRange(Directory.EnumerateFiles(projectSolutionNuGetPackagesFolder, "*",
                        SearchOption.AllDirectories)
                    .Where(file => file.ToLower().EndsWith("dll") || file.ToLower().EndsWith("xml"))
                    .Where(file => file.Contains(@"lib\net45"))
                    .Where(file => !Path.GetFileName(file).ToLower().StartsWith("evomp"))
                    .ToList());

                // Clear duplicates
                packageFiles = packageFiles.Distinct().ToList();

                // Copy new NuGet packages
                foreach (string packageFile in packageFiles)
                {
                    // Get target filename
                    string destinationFile = serverRootFolder + @"\" + Path.GetFileName(packageFile);

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
                    if (packageFile.EndsWith(".dll"))
                        Console.WriteLine($"\tUsing new package file: \"{Path.GetFileName(packageFile)}\".");
                }
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