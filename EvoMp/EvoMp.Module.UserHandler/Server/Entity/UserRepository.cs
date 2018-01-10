using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using GrandTheftMultiplayer.Server.API;

namespace EvoMp.Module.UserHandler.Server.Entity
{
	public class UserRepository
	{
		private readonly API _api;

		public UserRepository(API api)
		{
			_api = api;
			new UserContext().FirstInit();
		}

		public User GetUser([Optional] string name, [Optional] string socialClubName,
			[Optional] string email, [Optional] string hwId, int id = -1)
		{
			using (UserContext context = GetUserContext())
			{
				if (name != null)
					return context.Users.FirstOrDefault(u => u.Name == name);

				if (socialClubName != null)
					return context.Users.FirstOrDefault(u => u.SocialClubName == socialClubName);

				if (email != null)
					return context.Users.FirstOrDefault(u => u.Email == email);

				if (hwId != null)
					return context.Users.FirstOrDefault(u => u.HwId == hwId);

				if (id != -1)
					return context.Users.FirstOrDefault(u => u.Id == id);

				return null;
			}
		}

		public bool CreateUser(User user)
		{
			if (!IsEmailValid(user.Email))
				throw new DbEntityValidationException($"The entered e-mail {user.Email} is invalid!");

			if ( GetUser(user.Name) != null)
				throw new DbEntityValidationException($"The entered username {user.Name} is already taken!");

			if (GetUser(socialClubName: user.SocialClubName) != null)
				throw new DbEntityValidationException($"The entered Social Club Name {user.SocialClubName} is already taken!");

			using (UserContext userContext = GetUserContext())
			{
				userContext.Users.Add(user);
				userContext.SaveChanges();
			}
			return true;
		}

		public UserContext GetUserContext()
		{
			UserContext context = new UserContext();
			context.Init();
			return context;
		}

		public User UpdateUser(User user, [Optional] string name, [Optional] string socialClubName,
			[Optional] string email, [Optional] string hwId, [Optional] DateTime lastLogin, int id = -1)
		{
			using (UserContext context = GetUserContext())
			{
				context.Users.Attach(user);

				if (name != null)
					user.Name = name;

				if (socialClubName != null)
					user.SocialClubName = socialClubName;

				if (email != null)
					user.Email = email;

				if (hwId != null)
					user.HwId = hwId;

				if (lastLogin != DateTime.MinValue)
					user.LastLogin = lastLogin;

				if (id != -1)
					user.Id = id;

				context.SaveChanges();
			}
			return user;
		}

		private bool IsEmailValid(string email)
		{
			try
			{
				MailAddress m = new MailAddress(email);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
	}
}
