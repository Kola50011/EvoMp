using System;
using System.Data.Entity.Validation;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.UserHandler.Server;
using EvoMp.Module.UserHandler.Server.Authentication.Requests;
using EvoMp.Module.UserHandler.Server.Authentication.Responses;
using EvoMp.Module.UserHandler.Server.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;

namespace EvoMp.Module.Login.Server.Authentication
{
	public class Authentication
	{
		private readonly API _api;
		private readonly IEventHandler _eventHandler;
		private readonly IUserHandler _userHandler;

		// handles the whole authentication
		// gets the dependencies (Script, EventHandler and UserHandler) to register some
		// events. Then subscribe for to Client to Server events to handle login/registration separately
		public Authentication(API api, IEventHandler eventHandler, IUserHandler userHandler)
		{
			_api = api;
			_eventHandler = eventHandler;
			_userHandler = userHandler;

			_eventHandler.SubscribeToServerEvent("ready", new ServerEventHandle(OnPlayerReadyHandler));
			_eventHandler.SubscribeToServerEvent("registerRequest", new ServerEventHandle(RegisterRequest));
			_eventHandler.SubscribeToServerEvent("loginRequest", new ServerEventHandle(LoginRequest));
		}

		// gets called after the player/client connected and he is ready to receive triggers
		// If the users exists in the database, open the login otherwise the register
		public void OnPlayerReadyHandler(Client client, string eventName, object[] args)
		{
			User user = _userHandler.GetUser(socialClubName: client.socialClubName);

			// TODO Send the message to open the correct panel on the client, instead of skipping

			if (user != null)
				LoginClient(client, client.name, "asd");
			else
				RegisterClient(client, client.name, "asd", $"{client.name}@bla.de");
		}

		// handles the submission of the registration form
		public void RegisterRequest(Client client, string eventName, object[] args)
		{
			RegisterRequest registerRequest = JsonConvert.DeserializeObject<RegisterRequest>(args[0].ToString());

			RegisterClient(client, registerRequest.Name, registerRequest.Password,
				registerRequest.Email);
		}

		// handles the submission of the login form
		public void LoginRequest(Client client, string eventName, object[] args)
		{
			LoginRequest loginRequest = JsonConvert.DeserializeObject<LoginRequest>(args[0].ToString());

			LoginClient(client, loginRequest.Name, loginRequest.Password);
		}

		// Creates a new user object and save it to the database
		public void RegisterClient(Client client, string email, string name, string password)
		{
			if (client == null)
				return;

			RegisterResponse registerResponse = new RegisterResponse();
			try
			{
				string salt = _api.generateBCryptSalt(12);
				string passwordHash = _api.getPasswordHashBCrypt(password, salt);
				User user = new User
				{
					Email = email,
					HwId = client.uniqueHardwareId,
					Name = name,
					PasswordHash = passwordHash,
					Salt = salt,
					SocialClubName = client.socialClubName
				};
				_userHandler.CreateUser(user);

				registerResponse.Successfull = true;
				registerResponse.Messages.Add("Successfully registered user!");
			}
			catch (DbEntityValidationException e)
			{
				if (!e.Message.Contains("Validation failed for one or more"))
					registerResponse.Messages.Add(e.Message);

				foreach (var eve in e.EntityValidationErrors)
				foreach (var ve in eve.ValidationErrors)
					registerResponse.Messages.Add(ve.ErrorMessage);

				registerResponse.Successfull = false;
			}

			_eventHandler.InvokeClientEvent(client, "registerResponse",
				JsonConvert.SerializeObject(registerResponse));
		}

		// Gets the existing user object if there is one and login the user, otherwise return error to client
		public void LoginClient(Client client, string name, string password)
		{
			if (client == null)
				return;

			User user = _userHandler.GetUser(name);

			LoginResponse loginResponse = new LoginResponse();

			if (user == null)
			{
				loginResponse.Successfull = false;
				loginResponse.Messages.Add("Username not found!");
			}
			else if (!_api.verifyPasswordHashBCrypt(password, user.PasswordHash))
			{
				loginResponse.Successfull = false;
				loginResponse.Messages.Add("The entered password is incorrect!");
			}
			else
			{
				loginResponse.Successfull = true;
				loginResponse.Messages.Add("Login Successfull.");

				_userHandler.UpdateUser(user, socialClubName: client.socialClubName, hwId: client.uniqueHardwareId,
					lastLogin: DateTime.Now);
				_userHandler.SpawnUser(user);
				_userHandler.UnRestrict(user: user);
			}

			_eventHandler.InvokeClientEvent(client, "loginResponse",
				JsonConvert.SerializeObject(loginResponse));
		}
	}
}
