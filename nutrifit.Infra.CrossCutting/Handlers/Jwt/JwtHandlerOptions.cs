namespace Nutrifit.Infra.CrossCutting.Handlers.Jwt
{
    public class JwtHandlerOptions
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public string JwtPrivateKey { get; set; }
        public DateTime ExpireIn { get; set; }
    }
}
