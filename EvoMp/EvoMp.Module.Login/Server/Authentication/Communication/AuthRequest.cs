namespace EvoMp.Module.Login.Server.Authentication.Communication
{
    public class AuthRequest
    {
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
