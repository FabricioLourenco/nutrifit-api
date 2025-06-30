using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.DTos
{
    public class PacienteDTo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public long UsuarioId { get; set; }
        public long NutricionistaId { get; set; }
        public virtual ICollection<ConsultaDTo> Consultas { get; set; }
        public virtual ICollection<PlanoAlimentarDTo> PlanosAlimentares { get; set; }
        public virtual ICollection<EvolucaoPacienteDTo> Evolucoes { get; set; }
        public virtual ICollection<ComentarioPacienteDTo> Comentarios { get; set; }
    }
}
