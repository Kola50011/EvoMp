using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EvoMp.Module.DiscordHandler.Entity
{
    public class DiscordContext : DbContext
    {
        public DiscordContext() : base(Environment.GetEnvironmentVariable("NameOrConnectionString"))
        {
        }

        public DbSet<DiscordBot> DiscordBots { get; set; }
        public DbSet<DiscordBotChannel> DiscordBotChannels { get; set; }
        public DbSet<DiscordServerMember> DiscordServerMembers { get; set; }

        public void FirstInit()
        {
            // Startup parameter for database drop given -> drop.
            
            Database.SetInitializer<DiscordContext>(null);

            // Configurate migration
            DbMigrationsConfiguration migratorConfig = new DbMigrationsConfiguration<DiscordContext>
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true,
            };

            DbMigrator dbMigrator = new DbMigrator(migratorConfig);

            dbMigrator.Update();

            // Open database connection
            Database.Connection.Open();


            Console.WriteLine("Drop Database Discord? (y/n)");
            if (Console.ReadLine() == "y")
            {
                foreach (DiscordBot bot in DiscordBots.ToList())
                    DiscordBots.Remove(bot);
                SaveChanges();
            }
        }
    }
}