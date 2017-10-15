using System;
using System.Linq;
using DSharpPlus;
using EvoMp.Module.DiscordHandler.Entity;
using EvoMp.Module.Logger;

namespace EvoMp.Module.DiscordHandler.BotManagment
{
  public class BotManagment
  {
    public BotManagment(DiscordRepository discordRepository, ILogger logger)
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
        logger.Write("Currently no existing DiscordBot. Enter custom Token or default used? (Y/N)", LogCase.Discord);

          string botToken = "MzE1MTkxNDI0NDgyMDE3Mjgx.DMTmbA.mj6lvnSnk1JJkxIDNgO4RMOe2m4";
          if (Console.ReadLine()?.ToLower() == "y")
          {
              logger.Write("Please enter the Bot Token:", LogCase.Discord);

              // read and check bot token
              botToken = Console.ReadLine();
          }

          if (botToken != null)
          {
            // Create bot and save to database
            DiscordBot discordBot = new DiscordBot()
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
