using System.Collections.Generic;
using System.Linq;
using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.MessageHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;
using EvoMp.Module.WeaponUtils.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class WeaponCommands
    {
        private readonly API _api;
        private readonly IMessageHandler _messageHandler;
        private readonly IWeaponUtils _weaponUtils;

        public WeaponCommands(API api, IWeaponUtils weaponUtils, IMessageHandler messageHandler)
        {
            _api = api;
            _weaponUtils = weaponUtils;
            _messageHandler = messageHandler;
        }

        [PlayerCommand("/w")]
        public void TestWeaponCommand(Client sender, string weaponname)
        {
            List<WeaponHash> possibleWeapon =
                _weaponUtils.GetWeaponsByName(weaponname);

            if (!possibleWeapon.Any())
            {
                _messageHandler.PlayerMessage(sender,
                    $"There is no weapon like ~o~{weaponname}~w~ .", MessageType.Error);
                return;
            }

            _api.givePlayerWeapon(sender, possibleWeapon.First(), 9999, true);
            _messageHandler.PlayerMessage(sender,
                $"Weapon ~o~{possibleWeapon.First()}~w~ ~c~(~w~{API.shared.getWeaponType(possibleWeapon.First())}~c~) ~w~created.", MessageType.Info);

            possibleWeapon.Remove(possibleWeapon.First());

            if (possibleWeapon.Any())
                _api.sendNotificationToPlayer(sender,
                    $"~w~Alternative weapons: ~g~{string.Join(", ", possibleWeapon)}");
        }

        [PlayerCommand("/rw")]
        public void TestWeaponRemoveCommand(Client sender)
        {
            _api.removeAllPlayerWeapons(sender);
            _messageHandler.PlayerMessage(sender, $"~o~All weapons are removed.", MessageType.Info);
        }

        [PlayerCommand("/wt")]
        public void TestWeaponSetTintCommand(Client sender, int tint)
        {
            if (sender.currentWeapon == WeaponHash.Unarmed)
            {
                _messageHandler.PlayerMessage(sender,
                    $"~o~{sender.currentWeapon}~w~ could not paint.", MessageType.Error);
                return;
            }

            _api.setPlayerWeaponTint(sender, sender.currentWeapon, (WeaponTint)tint);
            _messageHandler.PlayerMessage(sender,
                $"~o~{sender.currentWeapon}~w~ got a new Tint ~c~[~o~{(WeaponTint)tint}~c~]", MessageType.Info);
        }
    }
}
