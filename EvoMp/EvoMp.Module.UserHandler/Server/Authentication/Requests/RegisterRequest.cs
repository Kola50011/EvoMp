namespace EvoMp.Module.UserHandler.Server.Authentication.Requests
{
	internal class RegisterRequest
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
