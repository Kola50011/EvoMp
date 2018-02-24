using System;
using System.Data.Entity.Validation;
using EvoMp.Module.ClientHandler.Server;
using EvoMp.Module.ClientHandler.Server.Entity;
using EvoMp.Module.EventHandler.Server;
using EvoMp.Module.Login.Server.Authentication.Communication;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using Newtonsoft.Json;

namespace EvoMp.Module.Login.Server.Authentication
{
    public class Authentication
    {
        private readonly API _api;
        private readonly IClientHandler _clientHandler;
        private readonly IEventHandler _eventHandler;

        // handles the whole authentication
        // gets the dependencies (Script, EventHandler and UserHandler) to register some
        // events. Then subscribe for to Client to Server events to handle login/registration separately
        public Authentication(API api, IEventHandler eventHandler, IClientHandler clientHandler)
        {
            _api = api;
            _eventHandler = eventHandler;
            _clientHandler = clientHandler;

            //_eventHandler.SubscribeToServerEvent("ready", new ServerEventHandle(OnPlayerReadyHandler));
            _eventHandler.SubscribeToServerEvent("AuthRequest", new ServerEventHandle(AuthRequest));
        }

        // gets called after the player/client connected and he is ready to receive triggers
        // If the users exists in the database, open the login otherwise the register
        public void OnPlayerReadyHandler(Client client, string eventName, object[] args)
        {
            ExtendetClient extendetClient = new ExtendetClient(client);

            if (extendetClient.Properties.Name == null)
            {
                AuthOpen authOpen = new AuthOpen
                {
                    Type = "Register"
                };
                _eventHandler.InvokeClientEvent(client, "AuthOpen", JsonConvert.SerializeObject(authOpen));
            }
            else
            {
                AuthOpen authOpen = new AuthOpen
                {
                    Type = "Login",
                    Username = extendetClient.Properties.Name
                };
                _eventHandler.InvokeClientEvent(client, "AuthOpen", JsonConvert.SerializeObject(authOpen));
            }
        }

        // handles the submission of the registration/login form
        public void AuthRequest(Client client, string eventName, object[] args)
        {
            AuthRequest authRequest = JsonConvert.DeserializeObject<AuthRequest>(args[0].ToString());

            if (authRequest.Type == "Login")
                LoginClient(client, authRequest.Username, authRequest.Password);
            else
                RegisterClient(client, authRequest.Username, authRequest.Password,
                    authRequest.Email);
        }

        // Creates a new user object and save it to the database
        public void RegisterClient(Client client, string email, string name, string password)
        {
            if (client == null)
                return;

            AuthResponse authResponse = new AuthResponse();

            try
            {
                string salt = _api.generateBCryptSalt(12);
                string passwordHash = _api.getPasswordHashBCrypt(password, salt);
                ExtendetClient extendetClient = new ExtendetClient(client);

                extendetClient.Save();

                authResponse.Success = true;
            }
            catch (DbEntityValidationException e)
            {
                if (!e.Message.Contains("Validation failed for one or more"))
                    authResponse.Error.Add(e.Message);

                foreach (var eve in e.EntityValidationErrors)
                foreach (var ve in eve.ValidationErrors)
                    authResponse.Error.Add(ve.ErrorMessage);

                authResponse.Success = false;
            }

            _eventHandler.InvokeClientEvent(client, "AuthResponse",
                JsonConvert.SerializeObject(authResponse));
        }

        // Gets the existing user object if there is one and login the user, otherwise return error to client
        public void LoginClient(Client client, string name, string password)
        {
            if (client == null)
                return;

            ExtendetClient extendetClient = new ExtendetClient(client);

            AuthResponse authResponse = new AuthResponse();

            if (extendetClient.Properties.Name == null)
            {
                authResponse.Success = false;
                authResponse.Error.Add("Username not found!");
            }
            else if (!_api.verifyPasswordHashBCrypt(password, extendetClient.Properties.PasswordHash))
            {
                authResponse.Success = false;
                authResponse.Error.Add("The entered password is incorrect!");
            }
            else
            {
                authResponse.Success = true;

                extendetClient.Properties.SocialClubName = client.socialClubName;
                extendetClient.Properties.HwId = client.uniqueHardwareId;
                extendetClient.Properties.LastLogin = DateTime.Now;

                _clientHandler.SpawnExtendetClient(extendetClient);
                _clientHandler.UnRestrict(extendetClient: extendetClient);
            }

            _eventHandler.InvokeClientEvent(client, "AuthResponse",
                JsonConvert.SerializeObject(authResponse));
        }
    }
}
