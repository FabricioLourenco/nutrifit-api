namespace Nutrifit.Domain.Common
{
    public class AppSettings
    {
        public JwtHandler JwtHandler { get; set; }
        public string ApiKey { get; set; }
    }

    public class JwtHandler
    {
        public string PrivateKey { get; set; }
    }
}
