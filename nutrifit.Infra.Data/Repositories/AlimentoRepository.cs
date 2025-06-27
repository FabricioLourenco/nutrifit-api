using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using nutrifit.Infra.Data.Context;
using Nutrifit.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Nutrifit.Infra.Data.Repositories
{
    public class AlimentoRepository : BaseRepository<Alimento>, IAlimentoRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public AlimentoRepository(NutrifitContext context,
                                  IUnitOfWork uow,
                                  INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Public Methods

        public async Task AddAlimentoAsync(Alimento entity) 
        {
            await AddAsync(entity);
        }

        public async Task AddRangeAlimentosAsync(IEnumerable<Alimento> entities) 
        {
            await _context.Alimento.AddRangeAsync(entities);
        }
        public async Task<Alimento?> BuscarAlimentoByAlimentoIbgeId(int alimentoIbgeId)
        {
            return await Query().FirstOrDefaultAsync(a => a.AlimentoIbgeId == alimentoIbgeId);
        }

        public async Task<Alimento> AtualizarAlimento(Alimento entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Alimento?> BuscarAlimentoId(long alimentoId)
        {
            return await Query()
                         .Where(a => a.Id == alimentoId)
                         .Include(a => a.AlimentoIbge) 
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Alimento>> BuscarAlimentos()
        {
            return await Query().ToListAsync();
        }

        public async Task<bool> ExcluirAlimento(long alimentoId)
        {
            var alimento = await BuscarAlimentoId(alimentoId);
            if (alimento == null)
            {
                _notificationHandler.AddNotification("Alimento não encontrado.");
                return false;
            }

            await RemoveAsync(alimento);
            _uow.Commit();
            return true;
        }

        #endregion
    }
}
