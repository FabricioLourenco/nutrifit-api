using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> InserirUsuario(UsuarioDTo model);

        Task<List<Usuario>> BuscarUsuarios();

        Task<Usuario> AtualizarUsuario(UpdateBaseDTo model);

        Task<bool> ExcluirUsuario(long usuarioId);
    }
}
