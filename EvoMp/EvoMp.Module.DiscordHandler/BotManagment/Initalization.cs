using System.Threading.Tasks;
using DSharpPlus;
using EvoMp.Module.DiscordHandler.Entity;

namespace EvoMp.Module.DiscordHandler.BotManagment
{
  internal static class Initialization
  {

    /// <summary>
    /// Initializes a new discordBot
    /// </summary>
    /// <param name="discordBot"></param>
    /// <returns>DiscordClient</returns>
    public static DiscordClient Setup(DiscordBot discordBot)
    {
      return new DiscordClient(new DiscordConfiguration()
      {
        Token = discordBot.Token,
        TokenType = TokenType.Bot
      });
    }

    /// <summary>
    /// Connects a discordClient
    /// </summary>
    /// <param name="discordClient"></param>
    public static async void Connect(DiscordClient discordClient)
    {
      await discordClient.ConnectAsync();
    }

    /// <summary>
    /// Binds the module events to the bot
    /// </summary>
    /// <param name="discordClient"></param>
    public static void BindEvents(DiscordClient discordClient)
    {
      discordClient.MessageCreated += async e =>
      {
        await Task.Yield();
        DiscordEvents.TriggerChannelMessage(e);
      };
      
    }
  }
}
