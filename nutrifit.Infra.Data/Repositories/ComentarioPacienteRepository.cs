using Microsoft.EntityFrameworkCore;
using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Nutrifit.Infra.Data.Data;

namespace Nutrifit.Infra.Data.Repositories
{
    public class ComentarioPacienteRepository : BaseRepository<ComentarioPaciente>, IComentarioPacienteRepository
    {

        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public ComentarioPacienteRepository(NutrifitContext context,
                                      IUnitOfWork uow,
                                      INotificationHandler notificationHandler) : base (context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<ComentarioPaciente> InserirComentarioPaciente(ComentarioPaciente entity)
        {
            await AddAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<ComentarioPaciente> AtualizarComentarioPaciente(ComentarioPaciente entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<ComentarioPaciente?> BuscarComentarioPacienteId(long comentarioPacienteId)
        {
            return await Query()
                         .Where(cp => cp.Id == comentarioPacienteId)
                         .Include(cp => cp.Paciente) 
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ComentarioPaciente>> BuscarComentariosPaciente()
        {
            return await Query()
                         .Include(cp => cp.Paciente) 
                         .ToListAsync();
        }

        public async Task<IEnumerable<ComentarioPaciente>> BuscarComentariosPacientePorPacienteId(long pacienteId)
        {
            return await Query()
                         .Where(cp => cp.PacienteId == pacienteId)
                         .Include(cp => cp.Paciente)
                         .ToListAsync();
        }

        public async Task<bool> ExcluirComentarioPaciente(long comentarioPacienteId)
        {
            var comentarioPaciente = await BuscarComentarioPacienteId(comentarioPacienteId);
            if (comentarioPaciente == null)
            {
                _notificationHandler.AddNotification("Comentário do paciente não encontrado.");
                return false;
            }

            await RemoveAsync(comentarioPaciente);
            _uow.Commit();
            return true;
        }

        #endregion
    }
}
