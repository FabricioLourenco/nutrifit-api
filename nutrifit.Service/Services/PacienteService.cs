using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.DI;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;

namespace Nutrifit.Service.Services
{
    public class PacienteService : IPacienteService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INutricionistaRepository _nutricionistaRepository;
        private readonly INotificationHandler _notificationHandler;

        public PacienteService(IMapper mapper,
                               IPacienteRepository pacienteRepository,
                               IUsuarioRepository usuarioRepository,
                               INutricionistaRepository nutricionistaRepository,
                               INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _pacienteRepository = pacienteRepository;
            _usuarioRepository = usuarioRepository;
            _nutricionistaRepository = nutricionistaRepository;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<List<PacienteDTo>> BuscarPacientes()
        {
            try
            {
                var pacientes = await _pacienteRepository.BuscarPacientes();
                return _mapper.Map<List<PacienteDTo>>(pacientes);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar pacientes: {ex.Message}");
                throw;
            }
        }

        public async Task<PacienteDTo?> BuscarPacientePorId(long id)
        {
            try
            {
                var paciente = await _pacienteRepository.BuscarPacienteId(id);
                return _mapper.Map<PacienteDTo>(paciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar paciente por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<PacienteDTo?> BuscarPacientePorUsuarioId(long usuarioId)
        {
            try
            {
                var paciente = await _pacienteRepository.BuscarPacienteByUsuarioId(usuarioId);
                return _mapper.Map<PacienteDTo>(paciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar paciente por ID de usuário: {ex.Message}");
                throw;
            }
        }

        public async Task<List<PacienteDTo>> BuscarPacientesPorNutricionista(long nutricionistaId)
        {
            try
            {
                var pacientes = await _pacienteRepository.BuscarPacientesPorNutricionistaId(nutricionistaId);
                var pacientesDTo = _mapper.Map<List<PacienteDTo>>(pacientes);
                
                foreach(var paciente in pacientesDTo)
                {
                    var usuarioBanco = await _usuarioRepository.BuscarUsuarioId(paciente.UsuarioId);
                    paciente.Nome = usuarioBanco.Nome;
                }

                return pacientesDTo;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar pacientes por nutricionista: {ex.Message}");
                throw;
            }
        }

        public async Task<PacienteDTo> AtualizarPaciente(UpdateBaseDTo model)
        {
            try
            {
                var pacienteExistente = await _pacienteRepository.BuscarPacienteId(model.Id);
                if (pacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Paciente não encontrado para atualização.");
                    return null;
                }

                // Validação de existência do novo nutricionista (se o NutricionistaId for alterado)
                if (pacienteExistente.NutricionistaId != model.Id)
                {
                    var novoNutricionista = await _nutricionistaRepository.BuscarNutricionistaId(model.Id);
                    if (novoNutricionista == null)
                    {
                        _notificationHandler.AddNotification("O novo nutricionista informado não foi encontrado.");
                        return null;
                    }
                }

                // Mapeia os dados do DTO para a entidade existente
                _mapper.Map(model, pacienteExistente);

                var updatedPaciente = await _pacienteRepository.AtualizarPaciente(pacienteExistente);
                return _mapper.Map<PacienteDTo>(updatedPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirPaciente(long pacienteId)
        {
            try
            {
                var result = await _pacienteRepository.ExcluirPaciente(pacienteId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir paciente: {ex.Message}");
                throw;
            }
        }


        #endregion
    }
}
