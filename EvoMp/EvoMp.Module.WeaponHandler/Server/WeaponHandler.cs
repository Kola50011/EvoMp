using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoMp.Core.Module;
using EvoMp.Core.Module.Server;
using EvoMp.Module.WeaponHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.WeaponHandler.Server
{
    public class WeaponHandler : BaseModule, IWeaponHandler
    {
        private readonly API _api;
        private readonly WeaponRepository _weaponRepositroy;

        public WeaponHandler(API api)
        {
            _api = api;
            _weaponRepositroy = WeaponRepository.GetInstance();
        }
    }
}
