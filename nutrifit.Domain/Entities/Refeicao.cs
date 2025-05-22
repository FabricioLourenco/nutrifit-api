using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class Refeicao : BaseEntity
    {
        public string Nome { get; set; }
        public TimeSpan Horario { get; set; }
        public long PlanoAlimentarId { get; set; }      
        public virtual PlanoAlimentar PlanoAlimentar { get; set; }
        public virtual ICollection<ItemRefeicao> Itens { get; set; }
    }
}
