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
    public class ConsultaService : IConsultaService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly IConsultaRepository _consultaRepository;
        private readonly IPacienteRepository _pacienteRepository; 
        private readonly INotificationHandler _notificationHandler;

        public ConsultaService(IMapper mapper,
                               IConsultaRepository consultaRepository,
                               IPacienteRepository pacienteRepository,
                               INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _consultaRepository = consultaRepository;
            _pacienteRepository = pacienteRepository;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<ConsultaDTo> InserirConsulta(ConsultaDTo model)
        {
            try
            {
                // Validação de existência do paciente
                var pacienteExistente = await _pacienteRepository.BuscarPacienteId(model.PacienteId);
                if (pacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Paciente não encontrado para associação com a consulta.");
                    return null;
                }

                var consulta = _mapper.Map<Consulta>(model);
                var insertedConsulta = await _consultaRepository.InserirConsulta(consulta);
                return _mapper.Map<ConsultaDTo>(insertedConsulta);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao inserir consulta: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ConsultaDTo>> BuscarConsultas()
        {
            try
            {
                var consultas = await _consultaRepository.BuscarConsultas();
                return _mapper.Map<List<ConsultaDTo>>(consultas);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar consultas: {ex.Message}");
                throw;
            }
        }

        public async Task<ConsultaDTo?> BuscarConsultaPorId(long id)
        {
            try
            {
                var consulta = await _consultaRepository.BuscarConsultaId(id);
                return _mapper.Map<ConsultaDTo>(consulta);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar consulta por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ConsultaDTo>> BuscarConsultasPorPaciente(long pacienteId)
        {
            try
            {
                var consultas = await _consultaRepository.BuscarConsultasPorPacienteId(pacienteId);
                return _mapper.Map<List<ConsultaDTo>>(consultas);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar consultas por paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<ConsultaDTo> AtualizarConsulta(UpdateBaseDTo model)
        {
            try
            {
                var consultaExistente = await _consultaRepository.BuscarConsultaId(model.Id);
                if (consultaExistente == null)
                {
                    _notificationHandler.AddNotification("Consulta não encontrada para atualização.");
                    return null;
                }

                _mapper.Map(model, consultaExistente);

                var updatedConsulta = await _consultaRepository.AtualizarConsulta(consultaExistente);
                return _mapper.Map<ConsultaDTo>(updatedConsulta);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar consulta: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirConsulta(long consultaId)
        {
            try
            {
                var result = await _consultaRepository.ExcluirConsulta(consultaId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir consulta: {ex.Message}");
                throw;
            }
        }


        #endregion
    }
}
