namespace Nutrifit.Domain.DTos.Base
{
    public class GenericResponseDTo
    {
        public bool Sucesso { get; set; }
        public object Data { get; set; }
        public List<string> Mensagens { get; set; }
    }
}
