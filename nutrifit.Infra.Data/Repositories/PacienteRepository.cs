using Microsoft.EntityFrameworkCore;
using nutrifit.Infra.Data.Context;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Infra.Data;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;
using Nutrifit.Infra.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrifit.Infra.Data.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente> , IPacienteRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public PacienteRepository(NutrifitContext context,
                                      IUnitOfWork uow,
                                      INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Paciente> AtualizarPaciente(Paciente entity)
        {
            await UpdateAsync(entity);
            _uow.Commit();
            return entity;
        }

        public async Task<Paciente?> BuscarPacienteId(long pacienteId)
        {
            return await Query()
                         .Where(p => p.Id == pacienteId)
                         .Include(p => p.Usuario)
                         .Include(p => p.Nutricionista)
                         .FirstOrDefaultAsync();
        }

        public async Task<Paciente?> BuscarPacienteByUsuarioId(long usuarioId)
        {
            return await Query()
                         .Where(p => p.UsuarioId == usuarioId)
                         .Include(p => p.Usuario)
                         .Include(p => p.Nutricionista)
                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Paciente>> BuscarPacientes()
        {
            return await Query()
                         .Include(p => p.Usuario)
                         .Include(p => p.Nutricionista)
                         .ToListAsync();
        }

        public async Task<IEnumerable<Paciente>> BuscarPacientesPorNutricionistaId(long nutricionistaId)
        {
            return await Query()
                         .Where(p => p.NutricionistaId == nutricionistaId)
                         .Include(p => p.Usuario)
                         .Include(p => p.Nutricionista)
                         .ToListAsync();
        }

        public async Task<bool> ExcluirPaciente(long pacienteId)
        {
            var paciente = await BuscarPacienteId(pacienteId);
            if (paciente == null)
            {
                _notificationHandler.AddNotification("Paciente não encontrado.");
                return false;
            }

            await RemoveAsync(paciente);
            _uow.Commit();
            return true;
        }


        #endregion

    }
}
