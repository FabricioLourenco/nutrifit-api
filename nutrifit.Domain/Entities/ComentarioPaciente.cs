using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class ComentarioPaciente : BaseEntity
    {      
        public DateTime DataComentario { get; set; }
        public string Conteudo { get; set; }
        public long PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
