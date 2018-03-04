using System.Linq;
using System.Runtime.InteropServices;
using EvoMp.Core.ConsoleHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.ClientHandler.Server
{
    public class SpawnManager
    {
        private readonly API _api;

        public SpawnManager(API api)
        {
            _api = api;
            _api.onPlayerConnected += client => { Restrict(client); };
        }

        private Client GetClientByExtendetClient(ExtendetClient extendetClient)
        {
            Client client = _api.getAllPlayers()
                .First(c => c.socialClubName == extendetClient.Properties.SocialClubName);
            if (client == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn,
                    $"Unable to get Client from User! Username: {extendetClient.Properties.Name} | SCName: {extendetClient.Properties.SocialClubName}");
                return null;
            }

            return client;
        }

        public bool SpawnExtendetClient(ExtendetClient extendetClient)
        {
            Client client = GetClientByExtendetClient(extendetClient);
            if (client != null)
            {
                client.position = new Vector3(0, 0, 0);
                return true;
            }

            return false;
        }

        public bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            if (extendetClient != null)
                client = GetClientByExtendetClient(extendetClient);

            if (client == null) return false;

            _api.setEntityInvincible(client.handle, true);
            _api.freezePlayer(client, true);
            _api.setEntityTransparency(client.handle, 0);
            _api.setEntityCollisionless(client.handle, true);

            return true;
        }

        public bool UnRestrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            if (extendetClient != null)
                client = GetClientByExtendetClient(extendetClient);

            if (client == null) return false;

            _api.setEntityInvincible(client.handle, false);
            _api.freezePlayer(client, false);
            _api.setEntityTransparency(client.handle, 255);
            _api.setEntityCollisionless(client.handle, false);

            return true;
        }
    }
}
