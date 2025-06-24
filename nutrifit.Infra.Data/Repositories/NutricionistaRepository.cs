using Microsoft.EntityFrameworkCore;
using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Nutrifit.Infra.Data.Data;

namespace Nutrifit.Infra.Data.Repositories
{
    public class NutricionistaRepository : BaseRepository<Nutricionista>, INutricionistaRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public NutricionistaRepository(NutrifitContext context,
                                      IUnitOfWork uow,
                                      INotificationHandler notificationHandler): base(context) 
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Nutricionista> AtualizarNutricionista(Nutricionista entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Nutricionista?> BuscarNutricionistaId(long nutricionistaId)
        {
            return await Query()
                         .Where(n => n.Id == nutricionistaId)
                         .Include(n => n.Usuario)
                         .Include(n => n.Pacientes)// Inclui o objeto Usuario associado
                         .FirstOrDefaultAsync();
        }

        public async Task<Nutricionista?> BuscarNutricionistaByUsuarioId(long usuarioId)
        {
            return await Query()
                         .Where(n => n.UsuarioId == usuarioId)
                         .Include(n => n.Usuario)
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Nutricionista>> BuscarNutricionistas()
        {
            return await Query()
                         .Include(n => n.Usuario) // Inclui o objeto Usuario associado
                         .ToListAsync();
        }

        public async Task<bool> ExcluirNutricionista(long nutricionistaId)
        {
            var nutricionista = await BuscarNutricionistaId(nutricionistaId);
            if (nutricionista == null)
            {
                _notificationHandler.AddNotification("Nutricionista não encontrado.");
                return false;
            }

            await RemoveAsync(nutricionista);
            _uow.Commit();
            return true;
        }

        #endregion

    }
}
