using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class Consulta : BaseEntity
    {        
        public DateTime DataHora { get; set; }
        public string? Observacoes { get; set; }
        public long PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
