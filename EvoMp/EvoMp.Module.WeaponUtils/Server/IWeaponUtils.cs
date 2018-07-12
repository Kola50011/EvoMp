using System.Collections.Generic;
using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Shared;

namespace EvoMp.Module.WeaponUtils.Server
{
    [ModuleProperties("shared", "James", "WeaponUtils & Enums")]
    public interface IWeaponUtils
    {
        /// <summary>
        ///     Gets all possible WeaponHashes for the searched name
        /// </summary>
        /// <param name="searchWeaponName">The name pattern of the searched weapon</param>
        /// <returns>List with possible WeaponHashes</returns>
        List<WeaponHash> GetWeaponsByName(string searchWeaponName);

        /// <summary>
        ///     Gets all WeaponHashes for the given weaponType
        /// </summary>
        /// <param name="weaponType">The weaponType of the searched weapons</param>
        /// <returns>List with matching WeaponHashes</returns>
        List<WeaponHash> GetWeaponsByType(WeaponType weaponType);
    }
}
