using System.Collections.Generic;

namespace EvoMp.Module.Login.Server.Authentication.Communication
{
    public class AuthResponse
    {
        public string Type { get; set; }
        public bool Success { get; set; }
        public List<string> Error { get; set; }
    }
}
