using EvoMp.Core.Parameter;

namespace EvoMp.Core.Core.Server
{
    public enum CoreParameter
    {
        /// <summary>
        ///     Used to select server gamemode.
        ///     Multiple using allowed
        /// </summary>
        [ParameterProperties("-g", "--gamemode", "-g \"gameModeName\"", true, "any")] Gamemode,

        /// <summary>
        ///     Path to logo ascii file,
        ///     Should placed in the ServerFilesFolder
        /// </summary>
        [ParameterProperties("-lg", "--LogoPath",
            "-lg \"./ServerFiles/Server_Logo.txt\"", false, "./ServerFiles/Default_Logo.txt")] LogoFileName

        //[ParameterProperties(null, null, "")] None,
    }
}