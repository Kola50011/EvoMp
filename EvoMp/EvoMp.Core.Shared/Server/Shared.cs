using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Core.Shared.Server
{
    public static class SharedEvents
    {
        public delegate void AfterCoreStartupCompleted();

        public delegate void CoreStartupCompleted();

        public delegate void ModuleLoaded(object moduleInstance);

        public delegate void ModuleLoadingStart(API api);

        public static bool StartUpCompleted;

        public static API Api;

        /// <summary>
        ///     Called one line before the modules start to loading.
        /// </summary>
        public static event ModuleLoadingStart OnModuleLoadingStart;

        /// <summary>
        ///     Called if the Server-Startup is completed.
        /// </summary>
        public static event CoreStartupCompleted OnCoreStartupCompleted;

        /// <summary>
        ///     Called after the Server-Startup is completed & after OnCoreStartupCompleted event calling.
        /// </summary>
        public static event AfterCoreStartupCompleted OnAfterCoreStartupCompleted;

        /// <summary>
        ///     Called if the given instance of a module is created.
        /// </summary>
        public static event ModuleLoaded OnModuleLoaded;

        /// <summary>
        ///     Invokes the OnCoreStartupCompleted event, after core startup.
        /// </summary>
        public static void OnOnCoreStartupCompleted()
        {
            StartUpCompleted = true;
            OnCoreStartupCompleted?.Invoke();
        }

        /// <summary>
        ///     Invokes the OnModuleLoaded event with the given loaded module instance.
        /// </summary>
        /// <param name="moduleInstance"></param>
        public static void OnOnModuleLoaded(object moduleInstance)
        {
            OnModuleLoaded?.Invoke(moduleInstance);
        }

        /// <summary>
        ///     Invokes the OnModuleLoadingStart event with the singlescope instance of API.
        /// </summary>
        /// <param name="api">The singlescope instance of API.</param>
        public static void OnOnModuleLoadingStart(API api)
        {
            Api = api;
            OnModuleLoadingStart?.Invoke(api);
        }

        /// <summary>
        ///     Invokes the OnAfterCoreStartupCompleted event.
        /// </summary>
        public static void OnOnAfterCoreStartupCompleted()
        {
            OnAfterCoreStartupCompleted?.Invoke();
        }
    }
}
