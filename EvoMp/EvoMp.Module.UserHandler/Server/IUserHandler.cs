using System;
using System.Runtime.InteropServices;
using EvoMp.Core.Module.Server;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.Elements;

namespace EvoMp.Module.UserHandler.Server
{
	[ModuleProperties("shared", "Koka, Lukas", "Everything that has to do with a user")]
	public interface IUserHandler
	{
		bool CreateUser(User user);

		User GetUser([Optional] string name, [Optional] string socialClubName,
			[Optional] string email, [Optional] string hwId, int id = -1);

		User UpdateUser(User user, [Optional] string name, [Optional] string socialClubName,
			[Optional] string email, [Optional] string hwId, [Optional] DateTime lastLogin, int id = -1);

		bool SpawnUser(User user);
		bool Restrict([Optional] Client client, [Optional] User user);
		bool UnRestrict([Optional] Client client, [Optional] User user);
	}
}
