namespace Cmms.Core.Options
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string[] Audience { get; set; }
    }
}
