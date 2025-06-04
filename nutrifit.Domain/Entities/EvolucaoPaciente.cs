using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class EvolucaoPaciente : BaseEntity
    {     
        public DateTime DataRegistro { get; set; }
        public decimal Peso { get; set; }
        public decimal? Altura { get; set; }
        public string? Sintomas { get; set; }
        public long PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
