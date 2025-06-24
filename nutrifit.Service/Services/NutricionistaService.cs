using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.DI;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;

namespace Nutrifit.Service.Services
{
    public class NutricionistaService : INutricionistaService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly INutricionistaRepository _nutricionistaRepository;
        private readonly IUsuarioRepository _usuarioRepository; // Necessário para validação de UsuarioId
        private readonly INotificationHandler _notificationHandler;

        public NutricionistaService(IMapper mapper,
                                    INutricionistaRepository nutricionistaRepository,
                                    IUsuarioRepository usuarioRepository,
                                    INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _nutricionistaRepository = nutricionistaRepository;
            _usuarioRepository = usuarioRepository;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

       

        public async Task<List<NutricionistaDTo>> BuscarNutricionistas()
        {
            try
            {
                var nutricionistas = await _nutricionistaRepository.BuscarNutricionistas();
                return _mapper.Map<List<NutricionistaDTo>>(nutricionistas);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar nutricionistas: {ex.Message}");
                throw;
            }
        }

        public async Task<NutricionistaDTo?> BuscarNutricionistaPorId(long id)
        {
            try
            {
                var nutricionista = await _nutricionistaRepository.BuscarNutricionistaId(id);
                return _mapper.Map<NutricionistaDTo>(nutricionista);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar nutricionista por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<NutricionistaDTo> AtualizarNutricionista(UpdateBaseDTo model)
        {
            try
            {
                var nutricionistaExistente = await _nutricionistaRepository.BuscarNutricionistaId(model.Id);
                if (nutricionistaExistente == null)
                {
                    _notificationHandler.AddNotification("Nutricionista não encontrado para atualização.");
                    return null;
                }

                // Mapeia os dados do DTO para a entidade existente
                _mapper.Map(model, nutricionistaExistente);

                var updatedNutricionista = await _nutricionistaRepository.AtualizarNutricionista(nutricionistaExistente);
                return _mapper.Map<NutricionistaDTo>(updatedNutricionista);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar nutricionista: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirNutricionista(long nutricionistaId)
        {
            try
            {
                var result = await _nutricionistaRepository.ExcluirNutricionista(nutricionistaId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir nutricionista: {ex.Message}");
                throw;
            }
        }


        #endregion

    }
}
