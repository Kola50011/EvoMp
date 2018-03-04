using System;
using System.Linq;
using EvoMp.Module.ClientHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.ClientHandler.Server
{
    public class ExtendetClient
    {
        public readonly Client Client;
        public ClientDto Properties;

        internal ExtendetClient(Client sender)
        {
            Client = sender;
            if (API.shared.hasEntityData(sender, "ClientId"))
                InitFromDatabase((int) API.shared.getEntityData(sender, "ClientId"));
            else
                InitFromClient();
        }

        private void InitFromDatabase(int id)
        {
            using (ClientContext context = new ClientContext())
            {
                Properties = context.Clients.First(dto => dto.Id == id);
            }
        }

        private void InitFromClient()
        {
            using (ClientContext context = new ClientContext())
            {
                Properties = context.Clients.FirstOrDefault(dto => dto.Name == Client.name) ??
                             context.Clients.Add(new ClientDto
                             {
                                 Name = Client.name,
                                 Created = DateTime.Now,
                                 Email = "RandomEmailField",
                                 HwId = Client.uniqueHardwareId,
                                 LastLogin = DateTime.Now,
                                 LastUpdate = DateTime.Now,
                                 SocialClubName = Client.socialClubName,
                                 Salt = Client.name,
                                 PasswordHash = "RandomPasswordHash"
                             });
                context.SaveChanges();
            }

            API.shared.setEntityData(Client, "ClientId", Properties.Id);
        }

        /// <summary>
        ///     Spawns the client
        /// </summary>
        public void Spawn()
        {
            ClientHandler.SpawnManager.SpawnExtendetClient(this);
        }

        public void Save()
        {
            //TODO
        }
    }
}
