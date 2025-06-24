using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.DTos
{
    public class NutricionistaDTo
    {
        public long Id { get; set; }
        public string CrefNutricionista { get; set; }
        public string Especialidades { get; set; }
        public long UsuarioId { get; set; }
        public virtual ICollection<PacienteDTo> Pacientes { get; set; }
    }
}
