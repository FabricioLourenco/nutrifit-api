using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class AlimentoIbge
    {
        public int Codigo { get; set; }  // Código do alimento
        public string DescricaoDoAlimento { get; set; }  // Descrição do alimento
        public string Categoria { get; set; }  // Categoria do alimento
        public int? CodigoDePreparacao { get; set; }  // Código de preparação (pode ser nulo)
        public string DescricaoDaPreparacao { get; set; }  // Descrição da preparação
        public decimal EnergiaKcal { get; set; }  // Energia em kcal
        public decimal ProteinaG { get; set; }  // Proteína em gramas
        public decimal LipidiosTotaisG { get; set; }  // Lipídios totais em gramas
        public decimal CarboidratoG { get; set; }  // Carboidrato em gramas
        public decimal FibraAlimentarTotalG { get; set; }  // Fibra alimentar total em gramas
        public decimal? ColesterolMg { get; set; }  // Colesterol em mg (pode ser nulo)
        public decimal AGSaturaDosG { get; set; }  // Ácidos graxos saturados em gramas
        public decimal AGMonoG { get; set; }  // Ácidos graxos monoinsaturados em gramas
        public decimal AGPoliG { get; set; }  // Ácidos graxos poli-insaturados em gramas
        public decimal AGLinoleicoG { get; set; }  // Ácido linoleico em gramas
        public decimal AGLinolenicoG { get; set; }  // Ácido linolênico em gramas
        public decimal AGTransTotalG { get; set; }  // Ácidos graxos trans totais em gramas
        public decimal AcucarTotalG { get; set; }  // Açúcar total em gramas
        public decimal AcucarDeAdicaoG { get; set; }  // Açúcar de adição em gramas
        public decimal CalcioMg { get; set; }  // Cálcio em mg
        public decimal MagnesioMg { get; set; }  // Magnésio em mg
        public decimal ManganesMg { get; set; }  // Manganês em mg
        public decimal FosforoMg { get; set; }  // Fósforo em mg
        public decimal FerroMg { get; set; }  // Ferro em mg
        public decimal SodioMg { get; set; }  // Sódio em mg
        public decimal? SodioDeAdicaoMg { get; set; }  // Sódio de adição em mg (pode ser nulo)
        public decimal PotassioMg { get; set; }  // Potássio em mg
        public decimal CobreMg { get; set; }  // Cobre em mg
        public decimal ZincoMg { get; set; }  // Zinco em mg
        public decimal? SelenioMcg { get; set; }  // Selênio em mcg (pode ser nulo)
        public decimal? RetinolMcg { get; set; }  // Retinol em mcg (pode ser nulo)
        public decimal VitaminaA_RAE_Mcg { get; set; }  // Vitamina A (RAE) em mcg
        public decimal TiaminaMg { get; set; }  // Tiamina em mg
        public decimal RiboflavinaMg { get; set; }  // Riboflavina em mg
        public decimal NiacinaMg { get; set; }  // Niacina em mg
        public decimal Niacina_NE_Mg { get; set; }  // Niacina (NE) em mg
        public decimal PiridoxinaMg { get; set; }  // Piridoxina em mg
        public decimal CobalaminaMcg { get; set; }  // Cobalamina (Vitamina B12) em mcg
        public decimal Folato_DFE_Mcg { get; set; }  // Folato (DFE) em mcg
        public decimal VitaminaD_Mcg { get; set; }  // Vitamina D em mcg
        public decimal VitaminaE_Mg { get; set; }  // Vitamina E em mg
        public decimal VitaminaC_Mg { get; set; }  // Vitamina C em mg
    }
}
