using Microsoft.EntityFrameworkCore;
using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Nutrifit.Infra.Data.Data;

namespace Nutrifit.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public UsuarioRepository(NutrifitContext context,
                                IUnitOfWork uow,
                                INotificationHandler notificationHandler): base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Usuario> InserirUsuario(Usuario entity)
        {
            await AddAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Usuario?> BuscarUsuarioId(long usuarioId)
        {
            return await Query()
                        .Include(c => c.Nutricionista)
                        .Include(c => c.Paciente)
                        .Where(c => c.Id == usuarioId).FirstOrDefaultAsync();
        }

        public async Task<Usuario?> BuscarUsuarioLogin(string email, string senhaHash)
        {
            return await Query().Where(c => c.Email.Equals(email) &&
                                        c.SenhaHash.Equals(senhaHash) &&
                                        c.Ativo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarios()
        {
            return await Query().ToListAsync();
        }

        public async Task<bool> ExcluirUsuario(long usuarioId)
        {
            var usuario = await BuscarUsuarioId(usuarioId);
            if (usuario == null)
            {
                _notificationHandler.AddNotification("Usuario não encontrado.");
                return false;
            }

            await RemoveAsync(usuario);
            _uow.Commit();
            return true;
        }

        

        #endregion
    }
}
