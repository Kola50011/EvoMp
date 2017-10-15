using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;

namespace EvoMp.Module.UserHandler.Entity
{
    public class UserContext : DbContext
    {
        public UserContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
        }

        public DbSet<User> Users { get; set; }

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

        public void Init()
        {
            Database.SetInitializer<UserContext>(null);
            Database.Connection.Open();
        }

        public void FirstInit()
        {
            Database.SetInitializer<UserContext>(null);

            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<UserContext>
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true
            };

            DbMigrator dbMigrator = new DbMigrator(migratorConfig);

            dbMigrator.Update();

            Database.Connection.Open();

            /*
                  Console.WriteLine("Drop Database Users? (y/n)");
                  if (Console.ReadLine() == "y")
                  {
                      foreach (User user in Users.ToList())
                          Users.Remove(user);
                      SaveChanges();
                  }*/
        }
    }
}