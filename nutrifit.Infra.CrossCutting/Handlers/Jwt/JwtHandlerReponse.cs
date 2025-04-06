namespace Nutrifit.Infra.CrossCutting.Handlers.Jwt
{
    public class JwtHandlerReponse
    {
        public string Token { get; set; }
        public DateTime ExpireIn { get; set; }
    }
}
