namespace Nutrifit.Domain.DTos
{
    public class ConsultaDTo
    {
        public long Id { get; set; }
        public DateTime DataHora { get; set; }
        public string? Observacoes { get; set; }
        public long PacienteId { get; set; }

    }
}
