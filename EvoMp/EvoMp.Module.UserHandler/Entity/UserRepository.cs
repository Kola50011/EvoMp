using System.Linq;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.UserHandler.Entity
{
    public class UserRepository
    {
        private readonly API _api;

        public UserRepository(API api)
        {
            _api = api;
            //new UserContext().FirstInit();
            GetUserContext();
        }

        public User GetUserByName(string name)
        {
            using (UserContext userContext = GetUserContext())
            {
                return userContext.Users.DefaultIfEmpty(null).FirstOrDefault(user => user.Name == name);
            }
        }

        public User GetUserBySocialClubName(string socialClubName)
        {
            using (UserContext userContext = GetUserContext())
            {
                return userContext.Users.DefaultIfEmpty(null)
                .FirstOrDefault(user => user.SocialClubName == socialClubName);
            }
        }

        public User GetUserById(int id)
        {
            using (UserContext userContext = GetUserContext())
            {
                return userContext.Users.DefaultIfEmpty(null).FirstOrDefault(user => user.Id == id);
            }
        }

        public Client GetClientBySocialClubName(string socialClubName)
        {
            return _api
                .getAllPlayers()
                .First(client => client.socialClubName == socialClubName);
        }

        public UserContext GetUserContext()
        {
            UserContext context = new UserContext();
            context.Init();
            return context;
        }
    }
}