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
    public class PlanoAlimentarService : IPlanoAlimentarService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly IPlanoAlimentarRepository _planoAlimentarRepository;
        private readonly IPacienteRepository _pacienteRepository; 
        private readonly INotificationHandler _notificationHandler;

        public PlanoAlimentarService(IMapper mapper,
                                     IPlanoAlimentarRepository planoAlimentarRepository,
                                     IPacienteRepository pacienteRepository,
                                     INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _planoAlimentarRepository = planoAlimentarRepository;
            _pacienteRepository = pacienteRepository;
            _notificationHandler = notificationHandler;
        }

        #region Public Methods

        public async Task<PlanoAlimentarDTo> InserirPlanoAlimentar(PlanoAlimentarDTo model)
        {
            try
            {
                var pacienteExistente = await _pacienteRepository.BuscarPacienteId(model.PacienteId);
                if (pacienteExistente == null)
                {
                    _notificationHandler.AddNotification("Paciente não encontrado para associar o plano alimentar.");
                    return null;
                }

                var planoAlimentar = _mapper.Map<PlanoAlimentar>(model);
                var insertedPlanoAlimentar = await _planoAlimentarRepository.InserirPlanoAlimentar(planoAlimentar);
                return _mapper.Map<PlanoAlimentarDTo>(insertedPlanoAlimentar);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao inserir plano alimentar: {ex.Message}");
                throw;
            }
        }

        public async Task<List<PlanoAlimentarDTo>> BuscarPlanosAlimentares()
        {
            try
            {
                var planos = await _planoAlimentarRepository.BuscarPlanosAlimentares();
                return _mapper.Map<List<PlanoAlimentarDTo>>(planos);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar planos alimentares: {ex.Message}");
                throw;
            }
        }

        public async Task<PlanoAlimentarDTo?> BuscarPlanoAlimentarPorId(long id)
        {
            try
            {
                var plano = await _planoAlimentarRepository.BuscarPlanoAlimentarId(id);
                return _mapper.Map<PlanoAlimentarDTo>(plano);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar plano alimentar por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<List<PlanoAlimentarDTo>> BuscarPlanosAlimentaresPorPaciente(long pacienteId)
        {
            try
            {
                var planos = await _planoAlimentarRepository.BuscarPlanosAlimentaresPorPacienteId(pacienteId);
                return _mapper.Map<List<PlanoAlimentarDTo>>(planos);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar planos alimentares por paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<PlanoAlimentarDTo> AtualizarPlanoAlimentar(UpdateBaseDTo model)
        {
            try
            {
                var planoAlimentarExistente = await _planoAlimentarRepository.BuscarPlanoAlimentarId(model.Id);
                if (planoAlimentarExistente == null)
                {
                    _notificationHandler.AddNotification("Plano alimentar não encontrado para atualização.");
                    return null;
                }

                _mapper.Map(model, planoAlimentarExistente);

                var updatedPlanoAlimentar = await _planoAlimentarRepository.AtualizarPlanoAlimentar(planoAlimentarExistente);
                return _mapper.Map<PlanoAlimentarDTo>(updatedPlanoAlimentar);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar plano alimentar: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirPlanoAlimentar(long planoAlimentarId)
        {
            try
            {
                var result = await _planoAlimentarRepository.ExcluirPlanoAlimentar(planoAlimentarId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir plano alimentar: {ex.Message}");
                throw;
            }
        }

        #endregion
    }
}
