using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using EvoMp.Core.Module.Server;

namespace EvoMp.Module.WeaponHandler.Server.Entity
{
    public class WeaponContext : DbContext
    {
        public WeaponContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new NonPublicColumnAttributeConvention());
        }

        public void FirstInit()
        {
            Database.SetInitializer<WeaponContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<WeaponContext>
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true
            };

            DbMigrator dbMigrator = new DbMigrator(migratorConfig);
            dbMigrator.Update();
            Database.Connection.Open();
        }
        #region Tabels
        public DbSet<WeaponDto> Weapons { get; set; }
        public DbSet<ModificationDto> Modification { get; set; }
        public DbSet<WeaponModificationDto> WeaponModification { get; set; }
        public DbSet<WeaponPropertiesDto> WeaponProperties { get; set; }
        #endregion
    }
}
