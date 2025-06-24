namespace Nutrifit.Domain.DTos
{
    public class RefeicaoDTo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public TimeSpan Horario { get; set; }
        public long PlanoAlimentarId { get; set; }
        public virtual ICollection<ItemRefeicaoDTo> Itens { get; set; }
    }
}
