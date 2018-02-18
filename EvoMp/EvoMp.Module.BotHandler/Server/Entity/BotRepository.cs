using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.BotHandler.Server.Entity
{
    public class BotRepository
    {
        private static BotRepository _botRepository;

        private BotRepository()
        {
            new BotContext().FirstInit();
        }

        public static BotContext GetVehicleContext()
        {
            BotContext context = new BotContext();
            return context;
        }

        public static BotRepository GetInstance(API api)
        {
            return _botRepository ?? (_botRepository = new BotRepository());
        }
    }
}
