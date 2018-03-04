using System.Runtime.InteropServices;
using EvoMp.Core.Module.Server;
using EvoMp.Module.DbAccess.Server;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.ClientHandler.Server
{
    /*
     * Handles Users and Spawning of them
     */

    public class ClientHandler : BaseModule, IClientHandler
    {
        internal static SpawnManager SpawnManager;

        public ClientHandler(API api, IEventHandler eventHandler, IDbAccess db)
        {
            //TODO: make own spawn module
            SpawnManager = new SpawnManager(api);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Returns an ExtendedClient object for the given player
        /// </summary>
        /// <param name="sender">The player</param>
        /// <returns>ExtendedClient</returns>
        public ExtendetClient GetExtendetClient(Client sender)
        {
            return new ExtendetClient(sender);
        }

        public bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            return SpawnManager.Restrict(client, extendetClient);
        }

        public bool UnRestrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            return SpawnManager.UnRestrict(client, extendetClient);
        }
    }
}
