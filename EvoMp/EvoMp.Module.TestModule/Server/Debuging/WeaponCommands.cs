using EvoMp.Module.CommandHandler.Server.Attributes;
using EvoMp.Module.WeaponUtils.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using System.Collections.Generic;
using System.Linq;

namespace EvoMp.Module.TestModule.Server.Debuging
{
    public class WeaponCommands
    {
        private readonly API _api;
        private readonly IWeaponUtils _weaponUtils;

        public WeaponCommands(API api, IWeaponUtils weaponUtils)
        {
            _api = api;
            _weaponUtils = weaponUtils;
        }

        [PlayerCommand("/w")]
        public void TestWeaponCommand(Client sender, string weaponname)
        {
            List<WeaponHash> possibleWeapon = WeaponUtils.Server.WeaponUtils.GetWeaponsByName(weaponname);

            if (!possibleWeapon.Any())
            {
                _api.sendChatMessageToPlayer(sender, $"There is no weapon like ~o~{weaponname}~w~ .");
                return;
            }
            _api.givePlayerWeapon(sender, possibleWeapon.First(), 9999, true);
            _api.sendChatMessageToPlayer(sender, $"Weapon ~o~{possibleWeapon.First()}~w~ ~c~(~w~{(WeaponType)API.shared.getWeaponType(possibleWeapon.First())}~c~) ~w~created.");
            if (possibleWeapon.Count > 1)
            {
                possibleWeapon.RemoveAt(0);
                _api.sendNotificationToPlayer(sender, $"~w~Alternative weapons: ~g~{string.Join(",", possibleWeapon)}");
            }
        }

        [PlayerCommand("/rw")]
        public void TestWeaponRemoveCommand(Client sender)
        {
            _api.removeAllPlayerWeapons(sender);
            _api.sendChatMessageToPlayer(sender, $"~o~All weapons are removed.");
        }

        [PlayerCommand("/wt")]
        public void TestWeaponSetTintCommand(Client sender, int tint)
        {
            if (sender.currentWeapon == WeaponHash.Unarmed)
            {
                _api.sendChatMessageToPlayer(sender, $"~o~{sender.currentWeapon}~w~ could not paint.");
                return;
            }

            _api.setPlayerWeaponTint(sender, sender.currentWeapon, (WeaponTint)tint);
            _api.sendChatMessageToPlayer(sender, $"~o~{sender.currentWeapon}~w~ got a new Tint [ ${(WeaponTint)tint}");
        }
    }
}
