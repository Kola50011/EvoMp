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
            _api.onPlayerDisconnected += OnPlayerDisconnected;
        }

        private void OnPlayerDisconnected(Client player, string reason)
        {
            ExtendetClient extendetClient = new ExtendetClient(player);
            extendetClient.Update(true);
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
                client.position = extendetClient.Properties.Position;
                client.rotation = extendetClient.Properties.Rotation;
                return true;
            }

            return false;
        }

        public bool Restrict([Optional] Client client, [Optional] ExtendetClient extendetClient)
        {
            if (extendetClient != null)
                client = GetClientByExtendetClient(extendetClient);
            else
            {
                if (client == null)
                    return false;
                else
                    extendetClient = new ExtendetClient(client);
            }




            //TODO: @Koka: Why in module ClientHandler. This should be in module Login
            //_api.setEntityInvincible(client.handle, true);
            //_api.freezePlayer(client, true);
            //_api.setEntityTransparency(client.handle, 0);
            //_api.setEntityCollisionless(client.handle, true);

            // Temp
            extendetClient.Spawn();
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
