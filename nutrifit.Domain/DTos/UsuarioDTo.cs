using Nutrifit.Domain.Enuns;

namespace Nutrifit.Domain.DTos
{
    public class UsuarioDTo
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string? Telefone { get; set; }
        public string FotoPerfilUrl { get; set; }
        public bool Ativo { get; set; }
        public bool AutenticacaoDoisFatoresHabilitada { get; set; }
        public virtual PacienteDTo? Paciente { get; set; }
        public virtual NutricionistaDTo? Nutricionista { get; set; }
    }
}
