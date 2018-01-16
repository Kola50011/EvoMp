using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;

namespace EvoMp.Module.UserHandler.Server.Entity
{
    public class ClientContext : DbContext
    {
        public ClientContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
        }

        public DbSet<ClientDto> Clients { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            IEnumerable<DbEntityEntry> entities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added)
                .Where(x => x.Entity.GetType().GetProperty("LastUpdate") != null);

            foreach (DbEntityEntry entity in entities)
            {
                PropertyInfo propertyInfo = entity.Entity.GetType().GetProperty("LastUpdate");

                if (propertyInfo != null)
                    propertyInfo.SetValue(entity.Entity, DateTime.Now);
            }
        }

        public void FirstInit()
        {
            Database.SetInitializer<ClientContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<ClientContext>
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true
            };

            DbMigrator dbMigrator = new DbMigrator(migratorConfig);

            dbMigrator.Update();

            Database.Connection.Open();
        }
    }
}
