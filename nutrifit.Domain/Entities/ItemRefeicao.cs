using nutrifit.Domain.Entities.Base;
using Nutrifit.Domain.Enuns;

namespace Nutrifit.Domain.Entities
{
    public class ItemRefeicao : BaseEntity
    {      
        public decimal Quantidade { get; set; } 
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
        public long RefeicaoId { get; set; }
        public long AlimentoId { get; set; }
        public virtual Refeicao Refeicao { get; set; }
        public virtual Alimento Alimento { get; set; }
    }
}
