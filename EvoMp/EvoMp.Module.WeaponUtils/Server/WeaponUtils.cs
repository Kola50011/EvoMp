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
        /// <inheritdoc />
        /// <summary>
        ///     Gets all possible WeaponHashes for the searched name
        /// </summary>
        /// <param name="searchWeaponName">The name pattern of the searched weapon</param>
        /// <returns>List with possible WeaponHashes</returns>
        public List<WeaponHash> GetWeaponsByName(string searchWeaponName)
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

        /// <inheritdoc />
        /// <summary>
        ///     Gets all WeaponHashes for the given weaponType
        /// </summary>
        /// <param name="weaponType">The weaponType of the searched weapons</param>
        /// <returns>List with matching WeaponHashes</returns>
        public List<WeaponHash> GetWeaponsByType(WeaponType weaponType)
        {
            return Enum.GetValues(typeof(WeaponHash)).Cast<WeaponHash>()
                .Where(weapon => API.shared.getWeaponType(weapon) == weaponType).ToList();
        }
    }
}
