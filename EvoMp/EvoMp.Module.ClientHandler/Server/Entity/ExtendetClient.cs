using System;
using System.Data.Entity.Validation;
using System.Net.Mail;

namespace EvoMp.Module.ClientHandler.Server.Entity
{
    public class ExtendetClient
    {
        public readonly ClientDto Properties;
        private ClientDto _clientDto;

        public ExtendetClient(ClientDto properTies)
        {
            Properties = properTies;
            _clientDto = Properties;
        }

        public ExtendetClient()
        {
            Properties = new ClientDto();
        }

        public void Save()
        {
            if (!IsEmailValid(Properties.Email))
                throw new DbEntityValidationException("Email Address is invalid!");

            using (ClientContext context = new ClientContext())
            {
                if (_clientDto == null)
                {
                    // New User
                    context.Clients.Add(Properties);
                    _clientDto = Properties;
                }
                else
                {
                    // Existing User
                    context.Clients.Attach(_clientDto);
                    _clientDto = Properties;
                }
                context.SaveChanges();
            }
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
