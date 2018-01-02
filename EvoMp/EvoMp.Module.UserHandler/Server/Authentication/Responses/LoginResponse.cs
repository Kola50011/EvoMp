using System.Collections.Generic;

namespace EvoMp.Module.UserHandler.Authentication.Responses
{
    internal class LoginResponse
    {
        public LoginResponse()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
        public bool Successfull { get; set; }
    }
}