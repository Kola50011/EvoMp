using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.CommandHandler.Server;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.VehicleHandler.Server;
using EvoMp.Module.WeaponHandler.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Gta.Vehicle;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class ExtendedWeaponTest
    {
        private readonly API _api;
        private readonly IMessageHandler _messageHandler;
        private readonly IWeaponHandler _weaponHandler;

        public ExtendedWeaponTest(API api, IWeaponHandler weaponHandler, IMessageHandler messageHandler)
        {
            _api = api;
            _weaponHandler = weaponHandler;
            _messageHandler = messageHandler;
        }

        [PlayerCommand("/dbvDestroy")]
        public void DestroyWeapon(Client sender)
        {
            WeaponHash weapon = _api.getPlayerWeapons(sender).First(x => x == WeaponHash.CarbineRifleMk2);
            ExtendedWeapon extendedWeapon = new ExtendedWeapon(weapon);
        }

        [PlayerCommand("/dbvspawn")]
        public void SpawnVehicle(Client sender, int vehicleId)
        {
            ExtendedWeapon extendedWeapon = new ExtendedWeapon(vehicleId);
            
        }
    }
}
