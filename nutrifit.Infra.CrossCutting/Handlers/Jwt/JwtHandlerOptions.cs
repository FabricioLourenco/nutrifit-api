namespace Nutrifit.Infra.CrossCutting.Handlers.Jwt
{
    public class JwtHandlerOptions
    {
        public long Id { get; set; }
        public long EstacaoId { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public long UsuarioId { get; set; }
        public string JwtPrivateKey { get; set; }
        public DateTime ExpireIn { get; set; }
    }
}
