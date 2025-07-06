namespace Nutrifit.Domain.DTos
{
    public class AlimentoAlternativoDTo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal CaloriasPorGrama { get; set; } 
        public decimal CaloriasNaQuantidadeInformada { get; set; } 
        public decimal QuantidadeGramaNecessaria { get; set; } 
        public decimal Proteinas { get; set; }
        public decimal Carboidratos { get; set; }
        public decimal Gorduras { get; set; }
    }
}
