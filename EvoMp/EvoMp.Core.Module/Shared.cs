using System;

namespace EvoMp.Core.Module
{
    public static class Shared
    {
        public delegate void CoreStartupCompleted();
        public delegate void AssemblyLoaded(Type[] loadedAssembly);

        public static event CoreStartupCompleted OnCoreStartupCompleted;
        public static event AssemblyLoaded OnAssemblyLoaded;

        public static void OnOnCoreStartupCompleted()
        {
            OnCoreStartupCompleted?.Invoke();
        }

        public static void OnOnModuleLoaded(Type[] loadedClasses)
        {
            OnAssemblyLoaded?.Invoke(loadedClasses);
        }
    }
}
