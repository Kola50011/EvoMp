using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared.Gta;
using EvoMp.Module.WeaponHandler.Server.Entity;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.Entity.Migrations;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.MessageHandler.Server.Enums;

namespace EvoMp.Module.WeaponHandler.Server
{
    public class ExtendedWeapon
    {
        private WeaponDto _weapon;
        public WeaponDto Properties;
        public NetHandle Weapon;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="weaponHash"></param>
        public ExtendedWeapon(WeaponHash weaponHash)
        {

        }

        public ExtendedWeapon(NetHandle weapon)
        {
            Weapon = weapon;
        }

        private void InitNew(WeaponHash weaponHash)
        {
            using (WeaponContext context = WeaponRepository.GetWeaponContext())
            {
                Properties = context.Weapons.Add(new WeaponDto
                {
                    WeaponHash = weaponHash,
                    WeaponProperties = context.WeaponProperties.First(dto => dto.WeaponHash == weaponHash)
                });
                context.SaveChanges();

                // Set Entity Data (WeaponId to Nethandle)
                if (!Weapon.IsNull) API.shared.setEntityData(Weapon, "WeaponId", Properties.WeaponId);
            }
        }

        public void FullUpdate(bool saveAlso = false)
        {
            //UpdateWeaponModification();
            if (saveAlso)
                Save();
        }

        /*private void UpdateWeaponModification()
        {
            if (Properties.WeaponModification == null)
                Properties.WeaponModification = new List<WeaponModificationDto>();

            using (WeaponContext context = WeaponRepository.GetWeaponContext())
            {
                foreach(WeaponComponent modification in Enum.GetValues(typeof(WeaponComponent)))
                {
                    int value = API.shared.getAllWeaponComponents()

                    ModificationDto modificationDto = context.Modification
                        .FirstOrDefault(modDto => modDto.Slot == modification);

                    // if ModificationDto is null
                    if (modificationDto == null)
                    {
                        modificationDto = context.Modification.Add(new ModificationDto
                        {
                            //Value = value,
                            Slot = modification
                        });
                        context.SaveChanges();
                    }
                }
            }
        }*/

        private void Save()
        {
            _weapon = Properties;

            // start new tarnsaction for the possibility to rollback
            using (var contextTransaction = WeaponRepository.GetWeaponContext().Database.BeginTransaction())
            {
                using (WeaponContext context = WeaponRepository.GetWeaponContext())
                {
                    try
                    {
                        context.Weapons.AddOrUpdate(Properties);
                        context.SaveChanges();
                        contextTransaction.Commit();
                        if(!Weapon.IsNull)
                            API.shared.setEntityData(Weapon, "WeaponId", Properties.WeaponId);
                    }
                    catch (Exception e)
                    {
                        ConsoleOutput.WriteLine(ConsoleType.Database, "Error on Saving ExtendedVehicle!");
                        ConsoleOutput.WriteException($"{e}");
                        // Rollback changes on failure
                        contextTransaction.Rollback();
                    }
                }
            }

        }

    }
}
