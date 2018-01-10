using System.Collections.Generic;

namespace EvoMp.Module.UserHandler.Server.Authentication.Responses
{
	internal class RegisterResponse
	{
		public RegisterResponse()
		{
			Messages = new List<string>();
		}

		public List<string> Messages { get; set; }
		public bool Successfull { get; set; }
	}
}
