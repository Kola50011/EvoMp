using System;
using DSharpPlus.EventArgs;
using EvoMp.Module.DiscordHandler.Entity;

namespace EvoMp.Module.DiscordHandler.Server
{
    public delegate void ChannelMessageHandler(DiscordBotChannel discordChannel, DiscordServerMember author,
        string message);

    public class DiscordEvents
    {
        private static DiscordEvents _discordEvents;
        private static ChannelManagment _channelManagment;

        /// <summary>
        ///     Constructor
        ///     Fetching channelManagment instance
        /// </summary>
        public DiscordEvents()
        {
            _channelManagment = ChannelManagment.GetInstance();
        }

        // Events
        public static event ChannelMessageHandler OnChannelMessage;

        public static DiscordEvents GetInstance()
        {
            return _discordEvents ?? (_discordEvents = new DiscordEvents());
        }

        public static void TriggerChannelMessage(MessageCreateEventArgs messageCreateEventArgs)
        {
            Console.WriteLine("test1");
            DiscordBotChannel sendedChannel = _channelManagment.GetBotChannel(messageCreateEventArgs.Client.CurrentUser,
                messageCreateEventArgs.Channel);
            Console.WriteLine("test2");
            DiscordServerMember sendedServerMember =
                ServerMemberManagment.GetServerMember(messageCreateEventArgs.Author);
            OnChannelMessage?.Invoke(sendedChannel, sendedServerMember, messageCreateEventArgs.Message.Content.Trim());
        }
    }
}
