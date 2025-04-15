namespace Cmms.Core.Respones
{
    public class LoginRespone
    {
        public bool IsLoggedIn { get; set; } = false;
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
