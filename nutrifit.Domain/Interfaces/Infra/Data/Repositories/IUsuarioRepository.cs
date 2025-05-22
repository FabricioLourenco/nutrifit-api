using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> InserirUsuario(Usuario entity);
        Task<IEnumerable<Usuario>> BuscarUsuarios();
        Task<Usuario?> BuscarUsuarioId(long usuarioId);
        Task<Usuario?> BuscarUsuarioLogin(string email, string senhaHash);
        Task<Usuario> AtualizarUsuario(Usuario entity);
        Task<bool> ExcluirUsuario(long usuarioId);
    }
}
