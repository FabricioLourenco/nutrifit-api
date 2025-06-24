using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.DTos
{
    public class EvolucaoPacienteDTo
    {
        public long Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public decimal Peso { get; set; }
        public decimal? Altura { get; set; }
        public string? Sintomas { get; set; }
        public long PacienteId { get; set; }
    }
}
