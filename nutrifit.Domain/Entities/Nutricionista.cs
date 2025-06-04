using nutrifit.Domain.Entities.Base;

namespace Nutrifit.Domain.Entities
{
    public class Nutricionista : BaseEntity
    {
        public string CrefNutricionista { get; set; }
        public string Especialidades { get; set; }
        public long UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
