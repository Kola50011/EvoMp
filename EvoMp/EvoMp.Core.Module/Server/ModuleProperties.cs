using System;
using System.Runtime.CompilerServices;
using EvoMp.Core.ConsoleHandler.Server;

namespace EvoMp.Core.Module.Server
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ModuleProperties : Attribute
    {
        public readonly string ModuleAuthors;
        public readonly string ModuleDescription;
        public readonly string ModuleType;

        /// <inheritdoc />
        /// <summary>
        ///     Defines module properties
        /// </summary>
        /// <param name="moduleType">The type of the module (shared, roleplay, freeroam, {custom}...)</param>
        /// <param name="moduleAuthors">The authors of the module</param>
        /// <param name="moduleDescription">Short description of the module</param>
        /// <param name="propName"></param>
        public ModuleProperties(string moduleType, string moduleAuthors, string moduleDescription,
            [CallerMemberName] string propName = null)
        {
            ModuleType = moduleType;
            ModuleAuthors = moduleAuthors;
            ModuleDescription = moduleDescription;

            ConsoleOutput.WriteLine(ConsoleType.Core, propName ?? "test");
        }
    }
}
