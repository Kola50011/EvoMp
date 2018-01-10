namespace EvoMp.Module.DiscordHandler.Server.Entity
{
    public class DiscordRepository
    {
        private static DiscordRepository _discordRepository;

        private DiscordRepository()
        {
            new DiscordContext().FirstInit();
        }

        public DiscordContext GetDiscordContext()
        {
            DiscordContext context = new DiscordContext();
            context.Init();
            return context;
        }

        public static DiscordRepository GetInstance()
        {
            return _discordRepository ?? (_discordRepository = new DiscordRepository());
        }
    }
}