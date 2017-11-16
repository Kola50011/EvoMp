using EvoMp.Core.Parameter;

namespace EvoMp.Core.Core
{
    public enum CoreParameter
    {
        /// <summary>
        /// Used to select server gamemode.
        /// Multiple using allowed
        /// </summary>
        [ParameterProperties("-g","--gamemode", "-g \"gameModeName\"", true, "any")] Gamemode,

        /// <summary>
        /// Folder where server relevant files placed
        /// //TODO: Remove and only use full paths.
        /// </summary>
        [ParameterProperties("-sff", "--ServerFilesFolder", "-sff \"./ServerFiles/\"", false, "./ServerFiles/")] ServerFilesFolder,

        /// <summary>
        /// Path to logo ascii file,
        /// Should placed in the ServerFilesFolder
        /// </summary>
        [ParameterProperties("-lg", "--LogoPath","-lg \"Server_Logo.txt\"", false, "Default_Logo.txt")] LogoFileName,

        //[ParameterProperties(null, null, "")] None,
    }
}
