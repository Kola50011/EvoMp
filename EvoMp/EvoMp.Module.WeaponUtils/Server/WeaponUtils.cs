using System;
using System.Collections.Generic;
using System.Linq;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.WeaponUtils.Server
{
    public class WeaponUtils : BaseModule, IWeaponUtils
    {
        List<WeaponHash> IWeaponUtils.GetWeaponsByName(string searchWeaponName)
        {
            return GetWeaponsByName(searchWeaponName);
        }

        List<WeaponHash> IWeaponUtils.GetWeaponsByType(WeaponType weaponType)
        {
            return GetWeaponByType(weaponType);
        }

        public static List<WeaponHash> GetWeaponsByName(string searchWeaponName)
        {
            List<WeaponHash> weapons = new List<WeaponHash>();
            searchWeaponName = searchWeaponName.ToLower();

            // conform to the name
            weapons.AddRange(Enum.GetValues(typeof(WeaponHash)).Cast<WeaponHash>()
                .Where(weapon => searchWeaponName == $"{weapon}".ToLower() && !weapons.Contains(weapon)));

            // contains the name
            weapons.AddRange(Enum.GetValues(typeof(WeaponHash)).Cast<WeaponHash>()
                .Where(weapon => $"{weapon}".ToLower().Contains(searchWeaponName) && !weapons.Contains(weapon)));

            // starts with the name
            weapons.AddRange(Enum.GetValues(typeof(WeaponHash)).Cast<WeaponHash>()
                .Where(weapon => $"{weapon}".ToLower().StartsWith(searchWeaponName) && !weapons.Contains(weapon)));

            return weapons;
        }

        public static List<WeaponHash> GetWeaponByType(WeaponType type)
        {
            return Enum.GetValues(typeof(WeaponHash)).Cast<WeaponHash>()
                .Where(weapon => API.shared.getWeaponType(weapon) == type).ToList();
        }
    }
}
