using System;
using System.Linq;
using System.Runtime.InteropServices;
using EvoMp.Core.Module.Server;
using EvoMp.Module.ClientHandler.Server.Entity;
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
        private readonly ClientRepository _clientRepository;
        private readonly SpawnManager _spawnManager;

        public ClientHandler(API api, IEventHandler eventHandler, IDbAccess db)
        {
            _clientRepository = new ClientRepository(api);
            _spawnManager = new SpawnManager(api);
        }

        public bool SpawnExtendetClient(ExtendetClient extendetClient)
        {
            return _spawnManager.SpawnExtendetClient(extendetClient);
        }

        public bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            return _spawnManager.Restrict(client, extendetClient);
        }

        public bool UnRestrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            return _spawnManager.UnRestrict(client, extendetClient);
        }
    }
}
