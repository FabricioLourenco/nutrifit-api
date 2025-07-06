namespace Nutrifit.Domain.DTos
{
    public class AlimentosAlternativosResponseDTo
    {
        public AlimentoDTo? AlimentoOriginal { get; set; }
        public List<AlimentoAlternativoDTo> AlimentosAlternativos { get; set; }
    }
}
