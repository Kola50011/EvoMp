using System.Collections.Generic;

namespace EvoMp.Module.UserHandler.Authentication.Responses
{
    internal class RegisterResponse
    {
        public List<string> Messages { get; set; }
        public bool Successfull { get; set; }

        public RegisterResponse()
        {
            Messages = new List<string>();
        }
    }
}