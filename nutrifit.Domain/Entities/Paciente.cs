using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class Paciente: BaseEntity
    {
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }      
        public long UsuarioId { get; set; }
        public long NutricionistaId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Nutricionista Nutricionista { get; set; }

        public virtual ICollection<PlanoAlimentar> PlanosAlimentares { get; set; }
        public virtual ICollection<EvolucaoPaciente> Evolucoes { get; set; }
        public virtual ICollection<ComentarioPaciente> Comentarios { get; set; }
    }
}
