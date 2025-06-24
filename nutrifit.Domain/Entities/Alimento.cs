using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class Alimento : BaseEntity
    {
        public string Nome { get; set; }
        public decimal Calorias { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Carboidratos { get; set; }
        public decimal Gorduras { get; set; }
        public int AlimentoIbgeId { get; set; }
        public AlimentoIbge AlimentoIbge { get; set; }
    }
}
