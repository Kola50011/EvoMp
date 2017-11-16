using System;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Module.DiscordHandler.Entity;
using EvoMp.Module.EventHandler;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.DiscordHandler
{
    public class DiscordHandler : IDiscordHandler
    {
        public DiscordRepository DiscordRepository;
        public BotManagment.BotManagment BotManagment;

        public DiscordHandler(API api, IEventHandler eventHandler)
        {
            DiscordRepository = DiscordRepository.GetInstance();
            DiscordEvents.GetInstance();
            BotManagment = new BotManagment.BotManagment(DiscordRepository);

            // Debug
            DiscordEvents.OnChannelMessage += (channel, author, message) =>
            {
                ConsoleOutput.WriteLine(ConsoleType.Debug, $"{channel.ChannelName} -> {author.Username}: ${message}");
            };
        }
    }
}

