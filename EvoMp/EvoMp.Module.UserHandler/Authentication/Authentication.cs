using System;
using System.Data.Entity.Validation;
using System.Net.Mail;
using EvoMp.Module.EventHandler;
using EvoMp.Module.UserHandler.Authentication.Requests;
using EvoMp.Module.UserHandler.Authentication.Responses;
using EvoMp.Module.UserHandler.Entity;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;

namespace EvoMp.Module.UserHandler.Authentication
{
  public class Authentication
  {
    private readonly API _api;
    private readonly IEventHandler _eventHandler;
    private readonly SpawnManager _spawnManager;
    private readonly UserRepository _userRepository;

    // handles the whole authentication
    // gets the dependencies (Script, EventHandler and UserHandler) to register some
    // events. Then subscribe for to Client to Server events to handle login/registration separately
    public Authentication(IEventHandler eventHandler, SpawnManager spawnManager,
        UserRepository userRepository, API api)
    {
      _userRepository = userRepository;
      _eventHandler = eventHandler;
      _spawnManager = spawnManager;
      _api = api;
      _eventHandler.SubscribeToServerEvent("ready", new ServerEventHandle(OnPlayerReadyHandler));
      _eventHandler.SubscribeToServerEvent("registerRequest", new ServerEventHandle(RegisterRequest));
      _eventHandler.SubscribeToServerEvent("loginRequest", new ServerEventHandle(LoginRequest));
    }

    // gets called after the player/client connected and he is ready to receive triggers
    // If the users exists in the database, open the login otherwise the register
    public void OnPlayerReadyHandler(Client client, string eventName, object[] args)
    {
      User user = _userRepository.GetUserBySocialClubName(client.socialClubName);

      if (user != null)
        LoginUser(client, client.name, "asd");
      else
        RegisterUser(client, client.name, "asd", $"{client.name}@bla.de");
    }

    // handles the submission of the registration form
    public void RegisterRequest(Client client, string eventName, object[] args)
    {
      RegisterRequest registerRequest = JsonConvert.DeserializeObject<RegisterRequest>(args[0].ToString());

      RegisterUser(client, registerRequest.Name, registerRequest.Password,
          registerRequest.Email);
    }

    // handles the submission of the login form
    public void LoginRequest(Client client, string eventName, object[] args)
    {
      LoginRequest loginRequest = JsonConvert.DeserializeObject<LoginRequest>(args[0].ToString());

      LoginUser(client, loginRequest.Name, loginRequest.Password);
    }

    // Creates a new user object and save it to the database
    public void RegisterUser(Client client, string name, string password, string email)
    {
      if (client == null)
        return;

      RegisterResponse registerResponse = new RegisterResponse();
      try
      {
        if (_userRepository.GetUserBySocialClubName(client.socialClubName) != null)
        {
          registerResponse.Messages.Add(
              $"User with Social Club Name {client.socialClubName} already exists!");
          throw new DbEntityValidationException();
        }

        if (_userRepository.GetUserByName(name) != null)
        {
          registerResponse.Messages.Add($"User with name {name} already exists!");
          throw new DbEntityValidationException();
        }

        if (!IsEmailValid(email)) //ToDo: Should be an email unique?
        {
          registerResponse.Messages.Add($"The entered e-mail {email} is not valid!");
          throw new DbEntityValidationException();
        }

        using (UserContext userContext = _userRepository.GetUserContext())
        {
          string salt = _api.generateBCryptSalt(12);
          string passwordHash = _api.getPasswordHashBCrypt(password, salt);
          User user = new User
          {
            Name = name,
            SocialClubName = client.socialClubName,
            Salt = salt,
            PasswordHash = passwordHash,
            Email = email,
            HwId = client.uniqueHardwareId,
            Created = DateTime.Now
          };

          userContext.Users.Add(user);
          userContext.SaveChanges();

          _spawnManager.SpawnUser(user);
        }

        registerResponse.Successfull = true;
        registerResponse.Messages.Add("Successfully registered user!");
      }
      catch (DbEntityValidationException e)
      {
        foreach (var eve in e.EntityValidationErrors)
          foreach (var ve in eve.ValidationErrors)
            registerResponse.Messages.Add(ve.ErrorMessage);

        registerResponse.Successfull = false;
        _userRepository.GetUserContext().Users.Local.Clear();
      }

      _eventHandler.InvokeClientEvent(client, "registerResponse",
          JsonConvert.SerializeObject(registerResponse));
    }

    // Gets the existing user object if there is one and login the user, otherwise return error to client
    public void LoginUser(Client client, string name, string password)
    {
      if (client == null)
        return;

      User user = _userRepository.GetUserByName(name);

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

        using (UserContext userContext = _userRepository.GetUserContext())
        {
          userContext.Users.Attach(user);

          user.SocialClubName = client.socialClubName;
          user.HwId = client.uniqueHardwareId;
          user.LastLogin = DateTime.Now;

          userContext.SaveChanges();
        }

        _spawnManager.SpawnUser(user);
      }

      _eventHandler.InvokeClientEvent(client, "loginResponse",
          JsonConvert.SerializeObject(loginResponse));
    }

    public bool IsEmailValid(string email)
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