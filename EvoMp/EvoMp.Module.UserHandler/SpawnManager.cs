using System.Timers;
using EvoMp.Core.ConsoleHandler;
using EvoMp.Module.UserHandler.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.UserHandler
{
    public class SpawnManager
    {
        private readonly API _api;
        private readonly UserRepository _userRepository;

        public SpawnManager(API api, UserRepository userRepository)
        {
            _api = api;
            _api.onPlayerDisconnected += OnPlayerDisconnectedHandler;
            _userRepository = userRepository;

            Timer myTimer = new Timer();
            myTimer.Elapsed += DelayEvent;
            myTimer.Interval = 10000; // Every 30 seconds
            myTimer.Start();

            _api.onPlayerConnected += RestrictClient;
        }

        private void DelayEvent(object source, ElapsedEventArgs e)
        {
            SaveAllUserPositions();
        }

        private void SaveAllUserPositions()
        {
            using (UserContext userContext = _userRepository.GetUserContext())
            {
                foreach (Client client in _api.getAllPlayers())
                {
                    User user = _userRepository.GetUserBySocialClubName(client.socialClubName);
                    if (user == null) continue;
                    SaveUserPosition(user, userContext);
                }
            }
        }

        private void SaveUserPosition(User user)
        {
            using (UserContext userContext = _userRepository.GetUserContext())
            {
                Client client = _userRepository.GetClientBySocialClubName(user.SocialClubName);
                if (client == null)
                {
                    ConsoleOutput.WriteLine(ConsoleType.Warn, "Client is null in SaveUserPosition");
                    return;
                }
                userContext.Users.Attach(user);

                user.PosX = client.position.X;
                user.PosY = client.position.Y;
                user.PosZ = client.position.Z;
                user.RotX = client.rotation.X;
                user.RotY = client.rotation.Y;
                user.RotZ = client.rotation.Z;

                userContext.SaveChanges();
            }
        }

        private void SaveUserPosition(User user, UserContext userContext)
        {
            Client client = _userRepository.GetClientBySocialClubName(user.SocialClubName);
            if (client == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn, "Client is null in SaveUserPosition");
                return;
            }

            userContext.Users.Attach(user);

            user.PosX = client.position.X;
            user.PosY = client.position.Y;
            user.PosZ = client.position.Z;
            user.RotX = client.rotation.X;
            user.RotY = client.rotation.Y;
            user.RotZ = client.rotation.Z;

            userContext.SaveChanges();
        }

        private void RestoreUserPosition(User user)
        {
            Client client = _userRepository.GetClientBySocialClubName(user.SocialClubName);
            if (client == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn, "Client is null in RestoreUserPosition");
                return;
            }

            client.position = new Vector3(user.PosX, user.PosY, user.PosZ + 1);
            client.rotation = new Vector3(user.RotX, user.RotY, user.RotZ);
        }

        private void OnPlayerDisconnectedHandler(Client client, string reason)
        {
            if (client == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn, "Client is null in OnPlayerDisconnectedHandler");
                return;
            }

            User user = _userRepository.GetUserBySocialClubName(client.socialClubName);
            if (user == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn, "User is null in OnPlayerDisconnectedHandler");
                return;
            }
            
            SaveUserPosition(user);
        }

        public void SpawnUser(User user)
        {
            Client client = _userRepository.GetClientBySocialClubName(user.SocialClubName);
            if (client == null)
            {
                ConsoleOutput.WriteLine(ConsoleType.Warn, "Client is null in SpawnUser");
                return;
            }

            RestoreUserPosition(user);
            UnRestrictClient(client);
        }

        private void RestrictClient(Client user)
        {
            _api.setEntityInvincible(user.handle, true);
            _api.freezePlayer(user, true);
            _api.setEntityTransparency(user.handle, 0);
            _api.setEntityCollisionless(user.handle, true);
        }

        private void UnRestrictClient(Client user)
        {
            _api.setEntityInvincible(user.handle, false);
            _api.freezePlayer(user, false);
            _api.setEntityTransparency(user.handle, 255);
            _api.setEntityCollisionless(user.handle, false);
        }
    }
}