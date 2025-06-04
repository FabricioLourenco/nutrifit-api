using System.ComponentModel.DataAnnotations;

namespace Nutrifit.Domain.Enuns
{
    public enum TipoUsuario
    {
        [Display(Name = "Administrador")]
        Administrador = 0,

        [Display(Name = "Nutricionista")]
        Nutricionista = 1,

        [Display(Name = "Paciente")]
        Paciente = 2
    }
}
