using System.Data.Entity.Validation;
using EvoMp.Core.ConsoleHandler.Server;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.UserHandler.Server;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.Login.Server
{
	public class Login : ILogin
	{
		public Login(API api, IEventHandler eventHandler, IUserHandler userHandler)
		{
			Authentication.Authentication auth = new Authentication.Authentication(api, eventHandler, userHandler);
		}
	}
}
