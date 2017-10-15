namespace EvoMp.Module.DiscordHandler.Entity
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
            return new DiscordContext();
        }

        public static DiscordRepository GetInstance()
        {
            return _discordRepository ?? (_discordRepository = new DiscordRepository());
        }

    }
}