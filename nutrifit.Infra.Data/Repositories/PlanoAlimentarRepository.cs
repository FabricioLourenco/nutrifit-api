using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using nutrifit.Infra.Data.Context;
using Nutrifit.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Nutrifit.Infra.Data.Repositories
{
    public class PlanoAlimentarRepository : BaseRepository<PlanoAlimentar>, IPlanoAlimentarRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public PlanoAlimentarRepository(NutrifitContext context,
                                        IUnitOfWork uow,
                                        INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Public Methods

        public async Task<PlanoAlimentar> InserirPlanoAlimentar(PlanoAlimentar entity)
        {
            await AddAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<PlanoAlimentar> AtualizarPlanoAlimentar(PlanoAlimentar entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<PlanoAlimentar?> BuscarPlanoAlimentarId(long planoAlimentarId)
        {
            return await Query()
                         .Where(pa => pa.Id == planoAlimentarId)
                         .Include(pa => pa.Paciente)
                         .Include(pa => pa.Refeicoes).ThenInclude(d => d.Itens).ThenInclude(e => e.Alimento)
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlanoAlimentar>> BuscarPlanosAlimentares()
        {
            return await Query()
                         .Include(pa => pa.Paciente)
                         .Include(pa => pa.Refeicoes).ThenInclude(d => d.Itens).ThenInclude(e => e.Alimento)
                         .ToListAsync();
        }

        public async Task<IEnumerable<PlanoAlimentar>> BuscarPlanosAlimentaresPorPacienteId(long pacienteId)
        {
            return await Query()
                         .Where(pa => pa.PacienteId == pacienteId)
                         .Include(pa => pa.Paciente)
                         .Include(pa => pa.Refeicoes).ThenInclude(d => d.Itens).ThenInclude(e => e.Alimento)
                         .ToListAsync();
        }

        public async Task<bool> ExcluirPlanoAlimentar(long planoAlimentarId)
        {
            var planoAlimentar = await BuscarPlanoAlimentarId(planoAlimentarId);
            if (planoAlimentar == null)
            {
                _notificationHandler.AddNotification("Plano alimentar não encontrado.");
                return false;
            }

            await RemoveAsync(planoAlimentar);
            _uow.Commit();
            return true;
        }

        #endregion
    }
}
