using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.DTos
{
    public class ComentarioPacienteDTo
    {
        public long Id { get; set; }
        public DateTime DataComentario { get; set; }
        public string Conteudo { get; set; }
        public long PacienteId { get; set; }
    }
}
