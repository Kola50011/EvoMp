using System.Linq;
using System.Runtime.InteropServices;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace EvoMp.Module.UserHandler.Server
{
	public class SpawnManager
	{
		private readonly API _api;
		private readonly UserRepository _userRepository;

		public SpawnManager(API api, UserRepository userRepository)
		{
			_api = api;
			_userRepository = userRepository;
			_api.onPlayerConnected += client => { Restrict(client); };
		}

		private Client GetClientByUser(User user)
		{
			Client client = _api.getAllPlayers().First(c => c.socialClubName == user.SocialClubName);
			if (client == null)
			{
				ConsoleOutput.WriteLine(ConsoleType.Warn,
					$"Unable to get Client from User! Username: {user.Name} | SCName: {user.SocialClubName}");
				return null;
			}
			return client;
		}

		public bool SpawnUser(User user)
		{
			Client client = GetClientByUser(user);
			client.position = new Vector3(0, 0, 0);
			return true;
		}

		public bool Restrict([Optional] Client client, [Optional] User user)
		{
			if (user != null)
				client = GetClientByUser(user);

			if (client == null) return false;

			_api.setEntityInvincible(client.handle, true);
			_api.freezePlayer(client, true);
			_api.setEntityTransparency(client.handle, 0);
			_api.setEntityCollisionless(client.handle, true);

			return true;
		}

		public bool UnRestrict([Optional] Client client, [Optional] User user)
		{
			if (user != null)
				client = GetClientByUser(user);

			if (client == null) return false;

			_api.setEntityInvincible(client.handle, false);
			_api.freezePlayer(client, false);
			_api.setEntityTransparency(client.handle, 255);
			_api.setEntityCollisionless(client.handle, false);

			return true;
		}
	}
}
