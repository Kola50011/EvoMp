using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.DiscordHandler.Server.Entity;
using EvoMp.Module.EventHandler.Server;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.DiscordHandler.Server
{
    public class DiscordHandler : IDiscordHandler
    {
        public BotManagment.BotManagment BotManagment;
        public DiscordRepository DiscordRepository;

        public DiscordHandler(API api, IEventHandler eventHandler)
        {
            DiscordRepository = DiscordRepository.GetInstance();
            DiscordEvents.GetInstance();
            BotManagment = new BotManagment.BotManagment(DiscordRepository);

            // Debug
            DiscordEvents.OnChannelMessage += (channel, author, message) =>
            {
                ConsoleOutput.WriteLine(ConsoleType.Debug,
                    $"{channel.ChannelName} -> {author.Username}: ${message}");
            };
        }
    }
}
