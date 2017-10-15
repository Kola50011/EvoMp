using System;
using EvoMp.Module.DiscordHandler.Entity;
using EvoMp.Module.EventHandler;
using EvoMp.Module.Logger;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.DiscordHandler
{
    public class DiscordHandler : IDiscordHandler
    {
        public DiscordRepository DiscordRepository;
        public BotManagment.BotManagment BotManagment;

        public DiscordHandler(API api, IEventHandler eventHandler, ILogger logger)
        {
            DiscordRepository = DiscordRepository.GetInstance();
            BotManagment = new BotManagment.BotManagment(DiscordRepository, logger);

            // Debug  
            DiscordEvents.OnChannelMessage += (channel, author, message) =>
            {
                logger.Write($"{channel.ChannelName} -> {author.Username}: ${message}", LogCase.Discord);
            };
        }

        public string ModuleName { get; } = "DiscordHandler";
        public string ModuleDesc { get; } = "Module for discord communication";
        public string ModuleAuth { get; } = "Ruffo";
    }
}

