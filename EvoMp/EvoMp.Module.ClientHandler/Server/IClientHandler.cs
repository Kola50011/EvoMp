using System.Runtime.InteropServices;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.ClientHandler.Server
{
    [ModuleProperties("shared", "Koka, Lukas", "Everything that has to do with a user")]
    public interface IClientHandler
    {
        IUtils Utils { get;}
        /// <summary>
        ///     Returns an ExtendedClient object for the given player
        /// </summary>
        /// <param name="sender">The player</param>
        /// <returns>ExtendedClient</returns>
        ExtendetClient GetExtendetClient(Client sender);

        bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient);
        bool UnRestrict([Optional] Client client, [Optional] ExtendetClient extendetClient);
    }
}
