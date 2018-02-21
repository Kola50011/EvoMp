using EvoMp.Core.Module.Server;
using GrandTheftMultiplayer.Shared;
using System.Collections.Generic;

namespace EvoMp.Module.WeaponUtils.Server
{
    [ModuleProperties("shared", "James", "WeaponUtils & Enums")]
    public interface IWeaponUtils
    {
        List<WeaponHash> GetWeaponsByName(string searchWeaponName);

        List<WeaponHash> GetWeaponsByType(WeaponType weaponType);
    }
}
