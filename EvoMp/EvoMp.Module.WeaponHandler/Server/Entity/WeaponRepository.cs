using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoMp.Module.WeaponHandler.Server.Entity
{
    public class WeaponRepository
    {
        private static WeaponRepository _weaponRepository;
        public WeaponRepository()
        {
            new WeaponContext().FirstInit();
        }

        private WeaponContext CreateContext()
        {
            WeaponContext context = new WeaponContext();
            return context;
        }

        public static WeaponRepository GetInstance()
        {
            return _weaponRepository ?? (_weaponRepository = new WeaponRepository());
        }

        public static WeaponContext GetWeaponContext()
        {
            return GetInstance().CreateContext();
        }
    }
}
