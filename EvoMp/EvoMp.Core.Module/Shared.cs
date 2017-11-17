using System;

namespace EvoMp.Core.Module
{
    public static class Shared
    {
        public delegate void CoreStartupCompleted();
        public delegate void AssemblyLoaded(Type[] loadedAssembly, object moduleInstance);

        public static event CoreStartupCompleted OnCoreStartupCompleted;
        public static event AssemblyLoaded OnAssemblyLoaded;

        public static void OnOnCoreStartupCompleted()
        {
            OnCoreStartupCompleted?.Invoke();
        }

        public static void OnOnModuleLoaded(Type[] loadedClasses, object moduleInstance)
        {
            OnAssemblyLoaded?.Invoke(loadedClasses, moduleInstance);
        }
    }
}
