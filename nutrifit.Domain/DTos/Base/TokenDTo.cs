namespace Nutrifit.Domain.DTos.Base
{
    public class TokenDTo
    {
        public string BearerToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
