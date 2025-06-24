using nutrifit.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Nutrifit.Domain.Entities
{
    public class AlimentoIbge
    {
        [Key]
        public int NumeroDoAlimento { get; set; }
        public string? CategoriaDoAlimento { get; set; }
        public string? DescricaoDosAlimentos { get; set; }
        public decimal? Umidade { get; set; }
        public decimal? EnergiaKcal { get; set; }
        public decimal? EnergiaKJ { get; set; }
        public decimal? ProteinaG { get; set; }
        public decimal? LipideosG { get; set; }
        public string? ColesterolMg { get; set; }
        public decimal? CarboidratoG { get; set; }
        public decimal? FibraAlimentarG { get; set; }
        public decimal? CinzasG { get; set; }
        public decimal? CalcioMg { get; set; }
        public decimal? MagnesioMg { get; set; }
        public decimal? ManganesMg { get; set; }
        public decimal? FosforoMg { get; set; }
        public decimal? FerroMg { get; set; }
        public decimal? SodioMg { get; set; }
        public decimal? PotassioMg { get; set; }
        public decimal? CobreMg { get; set; }
        public decimal? ZincoMg { get; set; }
        public string? RetinolMcg { get; set; }
        public string? REMcg { get; set; }
        public string? RAEMcg { get; set; }
        public decimal? TiaminaMg { get; set; }
        public decimal? RiboflavinaMg { get; set; }
        public decimal? PiridoxinaMg { get; set; }
        public decimal? NiacinaMg { get; set; }
        public string?VitaminaCMg { get; set; }
    }
}
