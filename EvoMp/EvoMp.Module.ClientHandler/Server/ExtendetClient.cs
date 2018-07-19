using System;
using System.Data.Entity.Migrations;
using System.Linq;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.ClientHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
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
        public void Spawn(bool ignoreSkin = false)
        {
            // Set skin on spawn -> Set skin, or get random skin, if not setten.
            if (!ignoreSkin)
                Client.setSkin(Properties.SkinHash != 0
                    ? Properties.SkinHash
                    : (PedHash) Enum.GetValues(typeof(PedHash))
                        .GetValue(new Random(DateTime.Now.Millisecond).Next(0,
                            Enum.GetValues(typeof(PedHash)).Length)));

            ClientHandler.SpawnManager.SpawnExtendetClient(this);
        }

        /// <summary>
        ///     Updates the database data of the extended client.
        /// </summary>
        public void Update(bool saveAlso = false)
        {
            Properties.Position = Client.position;
            Properties.Rotation = Client.rotation;
            Properties.LastUpdate = DateTime.Now;
            Properties.SkinHash = (PedHash) Client.model;

            if (saveAlso)
                Save();
        }

        public void Save()
        {
            ConsoleOutput.WriteLine(ConsoleType.Debug,
                $"Saving extended Client ~b~{Client.name}~w~ ID: ~b~ {Properties.Id}");
            using (ClientContext clientContext = ClientRepository.GetClientContext())
            {
                //TODO: Test
                clientContext.Clients.AddOrUpdate(Properties);
                clientContext.SaveChanges();
            }
        }
    }
}
