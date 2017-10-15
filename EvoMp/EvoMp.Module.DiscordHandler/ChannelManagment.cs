using System;
using System.Linq;
using DSharpPlus.Entities;
using EvoMp.Module.DiscordHandler.Entity;

namespace EvoMp.Module.DiscordHandler
{
    public class ChannelManagment
    {
        private static ChannelManagment _channelManagment;
        private static DiscordRepository _discordRepository;

        private ChannelManagment()
        {
            _discordRepository = DiscordRepository.GetInstance();
        }


        public static ChannelManagment GetInstance()
        {
            if (_channelManagment == null)
                _channelManagment = new ChannelManagment();

            return _channelManagment;
        }


        /// <summary>
        ///     Gets or creates the bot Channel
        /// </summary>
        /// <param name="discordUser"></param>
        /// <param name="discordChannel"></param>
        /// <returns></returns>
        public DiscordBotChannel GetBotChannel(DiscordUser discordUser, DiscordChannel discordChannel)
        {
            DiscordBotChannel returnChannel;
            Console.WriteLine("Test1");
            using (DiscordContext discordContext = _discordRepository.GetDiscordContext())
            {
                Console.WriteLine("Test12");
                // Channel search
                returnChannel = discordContext.DiscordBotChannels.FirstOrDefault(channel =>
                    channel.ChannelId == discordChannel.Id);

                // Can't found the channel in Database -> create
                if (returnChannel == null)
                {
                    returnChannel = discordContext.DiscordBotChannels.Add(new DiscordBotChannel
                    {
                        DiscordBot =
                            discordContext.DiscordBots.First(bot => bot.DiscordId == discordUser.Id),
                        ChannelId = discordChannel.Id,
                        ChannelName = discordChannel.Name
                    });
                    discordContext.SaveChanges();
                }
            }
            return returnChannel;
        }
    }
}