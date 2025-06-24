namespace Nutrifit.Domain.DTos
{
    public class AlimentoDTo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Calorias { get; set; }
        public decimal Proteinas { get; set; }
        public decimal Carboidratos { get; set; }
        public decimal Gorduras { get; set; }
        public int AlimentoIbgeId { get; set; }
    }
}
