using EvoMp.Module.DbAccess.Server;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;

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
	 * Every x Seconds => Save user x, y, z, rotX, rotY, rotZ
	 */

	public class UserHandler : IUserHandler
	{
		public UserHandler(API api, IEventHandler eventHandler, IDbAccess db)
		{
			UserRepository userRepository = new UserRepository(api);

			SpawnManager spawnManager = new SpawnManager(api, userRepository);
			Authentication.Authentication auth =
				new Authentication.Authentication(eventHandler, spawnManager, userRepository, api);
		}
	}
}
