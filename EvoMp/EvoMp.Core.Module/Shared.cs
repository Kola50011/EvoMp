using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Module
{
    public static class Shared
    {
        public delegate void ModuleLoadingStart(API api);
        public delegate void CoreStartupCompleted();
        public delegate void ModuleLoaded(object moduleInstance);

        public static event ModuleLoadingStart OnModuleLoadingStart;
        public static event CoreStartupCompleted OnCoreStartupCompleted;
        public static event ModuleLoaded OnModuleLoaded;

        public static API Api;

        public static void OnOnCoreStartupCompleted()
        {
            OnCoreStartupCompleted?.Invoke();
        }

        public static void OnOnModuleLoaded(object moduleInstance)
        {
            OnModuleLoaded?.Invoke(moduleInstance);
        }

        public static void OnOnModuleLoadingStart(API api)
        {
            Api = api;
            OnModuleLoadingStart?.Invoke(api);
        }
    }
}
