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
    public class AlimentoService : IAlimentoService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly IAlimentoRepository _alimentoRepository;
        private readonly IAlimentoIbgeRepository _alimentoIbgeRepository; 
        private readonly INotificationHandler _notificationHandler;

        public AlimentoService(IMapper mapper,
                               IAlimentoRepository alimentoRepository,
                               IAlimentoIbgeRepository alimentoIbgeRepository,
                               INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _alimentoRepository = alimentoRepository;
            _alimentoIbgeRepository = alimentoIbgeRepository;
            _notificationHandler = notificationHandler;
        }

        #region Public Methods

        public async Task<PagedResultDTo<AlimentoDTo>> ImportarAlimentosDoIbgePaginado(PaginationDTo pagination)
        {
            try
            {
                var pagedAlimentosIbge = await _alimentoIbgeRepository.BuscarAlimentosIbgePaginado(pagination);

                var alimentosToInsert = new List<Alimento>();
                var importedAlimentosResponse = new List<AlimentoDTo>();

                foreach (var alimentoIbge in pagedAlimentosIbge.Items)
                {
                    var existingAlimento = await _alimentoRepository.BuscarAlimentoByAlimentoIbgeId(alimentoIbge.NumeroDoAlimento);
                    if (existingAlimento != null)
                    {
                        importedAlimentosResponse.Add(_mapper.Map<AlimentoDTo>(existingAlimento));
                        continue;
                    }

                    var alimento = new Alimento
                    {
                        Nome = alimentoIbge.DescricaoDosAlimentos,
                        AlimentoIbgeId = alimentoIbge.NumeroDoAlimento,
                        Calorias = alimentoIbge.EnergiaKcal ?? 0,
                        Proteinas = alimentoIbge.ProteinaG ?? 0,
                        Carboidratos = alimentoIbge.CarboidratoG ?? 0,
                        Gorduras = alimentoIbge.LipideosG ?? 0,
                    };
                    alimentosToInsert.Add(alimento);
                }

                if (alimentosToInsert.Any())
                {
                    await _alimentoRepository.AddRangeAlimentosAsync(alimentosToInsert);                  
                }

                foreach (var alimentoItem in alimentosToInsert) 
                {
                    importedAlimentosResponse.Add(_mapper.Map<AlimentoDTo>(alimentoItem));
                }


                return new PagedResultDTo<AlimentoDTo>
                {
                    Items = importedAlimentosResponse, 
                    TotalCount = pagedAlimentosIbge.TotalCount,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize
                };
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao importar alimentos do IBGE: {ex.Message}");
                throw;
            }
        }

        public async Task<List<AlimentoDTo>> BuscarAlimentos()
        {
            try
            {
                var alimentos = await _alimentoRepository.BuscarAlimentos();
                return _mapper.Map<List<AlimentoDTo>>(alimentos);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar alimentos: {ex.Message}");
                throw;
            }
        }


        public async Task<AlimentoDTo?> BuscarAlimentoPorId(long id)
        {
            try
            {
                var alimento = await _alimentoRepository.BuscarAlimentoId(id);
                return _mapper.Map<AlimentoDTo>(alimento);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar alimento por ID: {ex.Message}");
                throw;
            }
        }

        public async Task<AlimentoDTo> AtualizarAlimento(UpdateBaseDTo model)
        {
            try
            {
                var alimentoExistente = await _alimentoRepository.BuscarAlimentoId(model.Id);
                if (alimentoExistente == null)
                {
                    _notificationHandler.AddNotification("Alimento não encontrado para atualização.");
                    return null;
                }
                alimentoExistente.Nome = "";
                var updatedAlimento = await _alimentoRepository.AtualizarAlimento(alimentoExistente);
                return _mapper.Map<AlimentoDTo>(updatedAlimento);
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao atualizar alimento: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ExcluirAlimento(long alimentoId)
        {
            try
            {
                var result = await _alimentoRepository.ExcluirAlimento(alimentoId);
                return result;
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao excluir alimento: {ex.Message}");
                throw;
            }
        }

        #endregion
    }
}
