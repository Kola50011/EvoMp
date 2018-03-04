using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.BotHandler.Server
{
    /// <summary>
    /// The BotRepository class
    /// </summary>
    public class BotRepository
    {
        /// <summary>
        /// The singleton BotRepository instance
        /// </summary>
        private static BotRepository _botRepository;

        /// <summary>
        /// Private constructor wich initialize the BotContext
        /// </summary>
        private BotRepository()
        {
            new BotContext().FirstInit();
        }

        /// <summary>
        /// Creates an new BotContext
        /// </summary>
        /// <returns>New bot context</returns>
        public static BotContext GetBotContext()
        {
            BotContext context = new BotContext();
            return context;
        }

        /// <summary>
        /// Returns the singleton instance of the BotRepository
        /// </summary>
        /// <returns></returns>
        public static BotRepository GetInstance(API api)
        {
            return _botRepository ?? (_botRepository = new BotRepository());
        }
    }
}
