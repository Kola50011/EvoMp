using System;

namespace EvoMp.Core.Module.Server
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ModuleProperties : Attribute
    {
        public readonly string ModuleType;
        public readonly string ModuleAuthors;
        public readonly string ModuleDescription;

        /// <summary>
        /// Defines module properties
        /// </summary>
        /// <param name="moduleType">The type of the module (shared, roleplay, freeroam, {custom}...)</param>
        /// <param name="moduleAuthors">The authors of the module</param>
        /// <param name="moduleDescription">Short description of the module</param>
        public ModuleProperties(string moduleType, string moduleAuthors, string moduleDescription)
        {
            ModuleType = moduleType;
            ModuleAuthors = moduleAuthors;
            ModuleDescription = moduleDescription;
        }
    }
}