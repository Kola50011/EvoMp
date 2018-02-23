using System;
using EvoMp.Module.ClientWrapper.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class ClientWrapperTest
    {
        private readonly API _api;
        private readonly IClientWrapper _clientWrapper;
        private readonly IMessageHandler _messageHandler;

        public ClientWrapperTest(API api, IClientWrapper clientWrapper, IMessageHandler messageHandler)
        {
            _clientWrapper = clientWrapper;
            _messageHandler = messageHandler;
            _api = api;
        }

        [PlayerCommand("/setTime")]
        public void TestSetTime(Client sender, int hours, int minutes)
        {
            _clientWrapper.Setter.SetTime(sender, hours, minutes);
        }

        [PlayerCommand("/Testv")]
        public void TestSetPlayerIntoVehicle(Client sender)
        {
            Vehicle newVehicle = _api.createVehicle(VehicleHash.Deluxo, sender.position,
                sender.rotation, 1, 1,
                sender.dimension);

            newVehicle.waitForSynchronization();

            _clientWrapper.Setter.SetPlayerIntoVehicle(sender, newVehicle, -1); // < 1 sec waiting time
            // Runs "API.setPlayerIntoVehicle(sender, newVehicle, -1)" on client side

            sender.setIntoVehicle(newVehicle, -1); // ~5 sec waiting time
        }

        [PlayerCommand("/streetName")]
        public async void TestStreetNameGetter(Client sender)
        {
            try
            {
                string streetname = await _clientWrapper.Getter.GetStreetName(sender, sender.position);
                _messageHandler.PlayerMessage(sender, $"Streetname: ~o~{streetname}", MessageType.Debug);
            }
            catch (Exception)
            {
                _messageHandler.PlayerMessage(sender, $"Aborted in cause of Timeout", MessageType.Error);
            }
        }
    }
}
