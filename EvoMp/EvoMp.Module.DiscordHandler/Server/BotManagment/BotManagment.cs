using System;
using System.Linq;
using DSharpPlus;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.DiscordHandler.Server.Entity;

namespace EvoMp.Module.DiscordHandler.Server.BotManagment
{
    public class BotManagment
    {
        public BotManagment(DiscordRepository discordRepository)
        {
            bool anyDiscordBotCreated = false;

            // Any existing Bots in Database?
            using (DiscordContext discordContext = discordRepository.GetDiscordContext())
            {
                anyDiscordBotCreated = discordContext.DiscordBots.Any();
            }

            // Currently no existing DiscordBot -> Ask to create one
            if (!anyDiscordBotCreated)
            {
                ConsoleOutput.WriteLine(ConsoleType.Debug,
                    "Currently no existing DiscordBot. Enter custom Token or default used? (Y/N)");
                string botToken = "MzE1MTkxNDI0NDgyMDE3Mjgx.DMTmbA.mj6lvnSnk1JJkxIDNgO4RMOe2m4";
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    ConsoleOutput.WriteLine(ConsoleType.Config, "Please enter the Bot Token:");

                    // read and check bot token
                    botToken = Console.ReadLine();
                }

                if (botToken != null)
                {
                    // Create bot and save to database
                    DiscordBot discordBot = new DiscordBot
                    {
                        Token = botToken
                    };
                    using (DiscordContext discordContext = discordRepository.GetDiscordContext())
                    {
                        discordContext.DiscordBots.Add(discordBot);
                        discordContext.SaveChanges();
                    }

                    anyDiscordBotCreated = true;
                }
            }

            // Discord Bots found -> Start them all
            if (anyDiscordBotCreated)
                using (DiscordContext discordContext = discordRepository.GetDiscordContext())
                {
                    foreach (DiscordBot discordBot in discordContext.DiscordBots)
                    {
                        DiscordClient newDiscordClient = Initialization.Setup(discordBot);
                        Initialization.Connect(newDiscordClient);
                        Initialization.BindEvents(newDiscordClient);
                    }
                }
        }
    }
}