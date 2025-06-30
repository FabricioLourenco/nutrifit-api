using Microsoft.EntityFrameworkCore;
using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Nutrifit.Infra.Data.Data;

namespace Nutrifit.Infra.Data.Repositories
{
    public class ConsultaRepository : BaseRepository<Consulta> , IConsultaRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public ConsultaRepository(NutrifitContext context,
                                      IUnitOfWork uow,
                                      INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Consulta> InserirConsulta(Consulta entity)
        {
            await AddAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Consulta> AtualizarConsulta(Consulta entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Consulta?> BuscarConsultaId(long consultaId)
        {
            return await Query()
                         .Where(c => c.Id == consultaId)
                         .Include(c => c.Paciente) // Inclui o objeto Paciente associado
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Consulta>> BuscarConsultas()
        {
            return await Query()
                         .Include(c => c.Paciente) // Inclui o objeto Paciente associado
                         .ToListAsync();
        }

        public async Task<IEnumerable<Consulta>> BuscarConsultasPorPacienteId(long pacienteId)
        {
            return await Query()
                         .Where(c => c.PacienteId == pacienteId)
                         .Include(c => c.Paciente).ThenInclude(d => d.Usuario)
                         .ToListAsync();
        }

        public async Task<bool> ExcluirConsulta(long consultaId)
        {
            var consulta = await BuscarConsultaId(consultaId);
            if (consulta == null)
            {
                _notificationHandler.AddNotification("Consulta não encontrada.");
                return false;
            }

            await RemoveAsync(consulta);
            _uow.Commit();
            return true;
        }

        #endregion

    }
}
