using System;

namespace EvoMp.Core.Module.Server
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ModuleProperties : Attribute
    {
        /// <summary>
        ///     The authors of the module
        /// </summary>
        public readonly string ModuleAuthors;

        /// <summary>
        ///     Short description of the module
        /// </summary>
        public readonly string ModuleDescription;

        /// <summary>
        ///     The type of the module (shared, roleplay, freeroam, {custom}...)
        /// </summary>
        public readonly string ModuleType;

        /// <summary>
        ///     Startup priority of the module. 0 = Highest
        /// </summary>
        public readonly int Priority;

        /// <inheritdoc />
        /// <summary>
        ///     Defines module properties
        /// </summary>
        /// <param name="moduleType">The type of the module (shared, roleplay, freeroam, {custom}...)</param>
        /// <param name="moduleAuthors">The authors of the module</param>
        /// <param name="moduleDescription">Short description of the module</param>
        /// <param name="priority">Startup priority of the module. 0 = Highest</param>
        public ModuleProperties(string moduleType, string moduleAuthors, string moduleDescription,
            int priority = int.MaxValue)
        {
            ModuleType = moduleType;
            ModuleAuthors = moduleAuthors;
            ModuleDescription = moduleDescription;
            Priority = priority;
        }
    }
}
