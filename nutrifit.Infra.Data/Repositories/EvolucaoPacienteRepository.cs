using Microsoft.EntityFrameworkCore;
using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Nutrifit.Infra.Data.Data;

namespace Nutrifit.Infra.Data.Repositories
{
    public class EvolucaoPacienteRepository : BaseRepository<EvolucaoPaciente>, IEvolucaoPacienteRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public EvolucaoPacienteRepository(NutrifitContext context,
                                      IUnitOfWork uow,
                                      INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<EvolucaoPaciente> InserirEvolucaoPaciente(EvolucaoPaciente entity)
        {
            await AddAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<EvolucaoPaciente> AtualizarEvolucaoPaciente(EvolucaoPaciente entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<EvolucaoPaciente?> BuscarEvolucaoPacienteId(long evolucaoPacienteId)
        {
            return await Query()
                         .Where(ep => ep.Id == evolucaoPacienteId)
                         .Include(ep => ep.Paciente) // Inclui o objeto Paciente associado
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EvolucaoPaciente>> BuscarEvolucoesPaciente()
        {
            return await Query()
                         .Include(ep => ep.Paciente) // Inclui o objeto Paciente associado
                         .ToListAsync();
        }

        public async Task<IEnumerable<EvolucaoPaciente>> BuscarEvolucoesPacientePorPacienteId(long pacienteId)
        {
            return await Query()
                         .Where(ep => ep.PacienteId == pacienteId)
                         .Include(ep => ep.Paciente)
                         .ToListAsync();
        }

        public async Task<bool> ExcluirEvolucaoPaciente(long evolucaoPacienteId)
        {
            var evolucaoPaciente = await BuscarEvolucaoPacienteId(evolucaoPacienteId);
            if (evolucaoPaciente == null)
            {
                _notificationHandler.AddNotification("Evolução do paciente não encontrada.");
                return false;
            }

            await RemoveAsync(evolucaoPaciente);
            _uow.Commit();
            return true;
        }


        #endregion
    }
}
