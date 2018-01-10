using System;
using System.Runtime.InteropServices;
using EvoMp.Module.DbAccess.Server;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.UserHandler.Server
{
	/*
	 * Handles Spawning and Authentication
	 * 
	 * Flow:
	 * User Joins => Freeze User
	 * 
	 * User is ready to get Messages -> User with SocialClub name already Registered?
	 *							yes	 => Open Login
	 *							no	 => Open Register
	 *
	 * Receive RegisterRequest from User -> Everything Correct?
	 *								yes	 => RegisterResponse, SpawnUser, UnRestrict
	 *								no	 => RegisterResponse
	 * 
	 * Receive LoginRequest from User -> Everything Correct=
	 *							yes	  => LoginResponse, SpawnUser, UnRestrict
	 *							no	  => LoginResponse
	 *
	 */

	public class UserHandler : IUserHandler
	{
		private readonly SpawnManager _spawnManager;
		private readonly UserRepository _userRepository;

		public UserHandler(API api, IEventHandler eventHandler, IDbAccess db)
		{
			_userRepository = new UserRepository(api);

			_spawnManager = new SpawnManager(api, _userRepository);
		}

		public User GetUser([Optional] string name, [Optional] string socialClubName,
			[Optional] string email, [Optional] string hwId, int id = -1)
		{
			return _userRepository.GetUser(name, socialClubName, email, hwId, id);
		}

		public User UpdateUser(User user, [Optional] string name, [Optional] string socialClubName,
			[Optional] string email, [Optional] string hwId, [Optional] DateTime lastLogin, int id = -1)
		{
			return _userRepository.UpdateUser(user, name, socialClubName, email, hwId, lastLogin, id);
		}

		/// <summary>
		///     Spawns the user at the default spawn location.
		/// </summary>
		/// <param name="user">The user that should be spawned</param>
		/// <returns>If successful</returns>
		public bool SpawnUser(User user)
		{
			return _spawnManager.SpawnUser(user);
		}

		/// <summary>
		///     Make the user unable to do anything.
		/// </summary>
		/// <param name="client"></param>
		/// <param name="user"></param>
		/// <returns>If successful</returns>
		public bool Restrict(Client client = null, User user = null)
		{
			return _spawnManager.Restrict(client, user);
		}

		/// <summary>
		///     Make the user able to do everything again.
		/// </summary>
		/// <param name="client"></param>
		/// <param name="user"></param>
		/// <returns>If successful</returns>
		public bool UnRestrict(Client client = null, User user = null)
		{
			return _spawnManager.UnRestrict(client, user);
		}

		public bool CreateUser(User user)
		{
			return _userRepository.CreateUser(user);
		}
	}
}
