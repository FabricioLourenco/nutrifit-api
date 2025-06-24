using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.DTos
{
    public class PlanoAlimentarDTo
    {
        public long Id { get; set; }    
        public string ObservacoesGerais { get; set; }
        public DateTime DataInicio { get; set; }
        public long PacienteId { get; set; }
        public virtual ICollection<RefeicaoDTo> Refeicoes { get; set; }
    }
}
