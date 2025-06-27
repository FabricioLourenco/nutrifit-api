using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.DI;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;

namespace Nutrifit.Service.Services
{
    public class ComentarioPacienteService : IComentarioPacienteService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly IComentarioPacienteRepository _comentarioPacienteRepository;
        private readonly IPacienteRepository _pacienteRepository; 
        private readonly INotificationHandler _notificationHandler;

        public ComentarioPacienteService(IMapper mapper,
                                         IComentarioPacienteRepository comentarioPacienteRepository,
                                         IPacienteRepository pacienteRepository,
                                         INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _comentarioPacienteRepository = comentarioPacienteRepository;
            _pacienteRepository = pacienteRepository;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<ComentarioPacienteDTo> InserirComentarioPaciente(ComentarioPacienteDTo model)
        {
            try
            {
                // Validação de existência do paciente
                var pacienteExistente = await _pacienteRepository.BuscarPacienteId(model.PacienteId);
                if (pacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Paciente não encontrado para associar o comentário.");
                    return null;
                }

                var comentarioPaciente = _mapper.Map<ComentarioPaciente>(model);
                var insertedComentarioPaciente = await _comentarioPacienteRepository.InserirComentarioPaciente(comentarioPaciente);
                return _mapper.Map<ComentarioPacienteDTo>(insertedComentarioPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao inserir comentário do paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ComentarioPacienteDTo>> BuscarComentariosPaciente()
        {
            try
            {
                var comentarios = await _comentarioPacienteRepository.BuscarComentariosPaciente();
                return _mapper.Map<List<ComentarioPacienteDTo>>(comentarios);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar comentários do paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<ComentarioPacienteDTo?> BuscarComentarioPacientePorId(long id)
        {
            try
            {
                var comentarioPaciente = await _comentarioPacienteRepository.BuscarComentarioPacienteId(id);
                return _mapper.Map<ComentarioPacienteDTo>(comentarioPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar comentário do paciente por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ComentarioPacienteDTo>> BuscarComentariosPacientePorPaciente(long pacienteId)
        {
            try
            {
                var comentarios = await _comentarioPacienteRepository.BuscarComentariosPacientePorPacienteId(pacienteId);
                return _mapper.Map<List<ComentarioPacienteDTo>>(comentarios);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar comentários do paciente por paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<ComentarioPacienteDTo> AtualizarComentarioPaciente(UpdateBaseDTo model)
        {
            try
            {
                var comentarioPacienteExistente = await _comentarioPacienteRepository.BuscarComentarioPacienteId(model.Id);
                if (comentarioPacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Comentário do paciente não encontrado para atualização.");
                    return null;
                }

                _mapper.Map(model, comentarioPacienteExistente);

                var updatedComentarioPaciente = await _comentarioPacienteRepository.AtualizarComentarioPaciente(comentarioPacienteExistente);
                return _mapper.Map<ComentarioPacienteDTo>(updatedComentarioPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar comentário do paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirComentarioPaciente(long comentarioPacienteId)
        {
            try
            {
                var result = await _comentarioPacienteRepository.ExcluirComentarioPaciente(comentarioPacienteId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir comentário do paciente: {ex.Message}");
                throw;
            }
        }


        #endregion

    }
}
