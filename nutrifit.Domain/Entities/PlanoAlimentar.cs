using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class PlanoAlimentar : BaseEntity
    {
        public string ObservacoesGerais { get; set; }
        public DateTime DataInicio { get; set; }
        public long PacienteId { get; set; }          
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<Refeicao> Refeicoes { get; set; }
    }
}
