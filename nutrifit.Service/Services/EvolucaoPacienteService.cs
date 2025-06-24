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
    public class EvolucaoPacienteService : IEvolucaoPacienteService , IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly IEvolucaoPacienteRepository _evolucaoPacienteRepository;
        private readonly IPacienteRepository _pacienteRepository; // Necessário para validação de PacienteId
        private readonly INotificationHandler _notificationHandler;

        public EvolucaoPacienteService(IMapper mapper,
                                       IEvolucaoPacienteRepository evolucaoPacienteRepository,
                                       IPacienteRepository pacienteRepository,
                                       INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _evolucaoPacienteRepository = evolucaoPacienteRepository;
            _pacienteRepository = pacienteRepository;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<EvolucaoPacienteDTo> InserirEvolucaoPaciente(EvolucaoPacienteDTo model)
        {
            try
            {
                var pacienteExistente = await _pacienteRepository.BuscarPacienteId(model.PacienteId);
                if (pacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Paciente não encontrado para associar a evolução.");
                    return null;
                }

                var evolucaoPaciente = _mapper.Map<EvolucaoPaciente>(model);
                var insertedEvolucaoPaciente = await _evolucaoPacienteRepository.InserirEvolucaoPaciente(evolucaoPaciente);
                return _mapper.Map<EvolucaoPacienteDTo>(insertedEvolucaoPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao inserir evolução do paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<List<EvolucaoPacienteDTo>> BuscarEvolucoesPaciente()
        {
            try
            {
                var evolucoes = await _evolucaoPacienteRepository.BuscarEvolucoesPaciente();
                return _mapper.Map<List<EvolucaoPacienteDTo>>(evolucoes);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar evoluções do paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<EvolucaoPacienteDTo?> BuscarEvolucaoPacientePorId(long id)
        {
            try
            {
                var evolucaoPaciente = await _evolucaoPacienteRepository.BuscarEvolucaoPacienteId(id);
                return _mapper.Map<EvolucaoPacienteDTo>(evolucaoPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar evolução do paciente por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<List<EvolucaoPacienteDTo>> BuscarEvolucoesPacientePorPaciente(long pacienteId)
        {
            try
            {
                var evolucoes = await _evolucaoPacienteRepository.BuscarEvolucoesPacientePorPacienteId(pacienteId);
                return _mapper.Map<List<EvolucaoPacienteDTo>>(evolucoes);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar evoluções do paciente por paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<EvolucaoPacienteDTo> AtualizarEvolucaoPaciente(UpdateBaseDTo model)
        {
            try
            {
                var evolucaoPacienteExistente = await _evolucaoPacienteRepository.BuscarEvolucaoPacienteId(model.Id);
                if (evolucaoPacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Evolução do paciente não encontrada para atualização.");
                    return null;
                }

                _mapper.Map(model, evolucaoPacienteExistente);

                var updatedEvolucaoPaciente = await _evolucaoPacienteRepository.AtualizarEvolucaoPaciente(evolucaoPacienteExistente);
                return _mapper.Map<EvolucaoPacienteDTo>(updatedEvolucaoPaciente);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar evolução do paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirEvolucaoPaciente(long evolucaoPacienteId)
        {
            try
            {
                var result = await _evolucaoPacienteRepository.ExcluirEvolucaoPaciente(evolucaoPacienteId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir evolução do paciente: {ex.Message}");
                throw;
            }
        }


        #endregion
    }
}
