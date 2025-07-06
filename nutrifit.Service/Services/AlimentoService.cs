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
                    PageSize = pagedAlimentosIbge.PageSize 
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

        public async Task<AlimentosAlternativosResponseDTo> BuscarAlimentosAlternativos(long alimentoId, decimal quantidadeGrama)
        {
            try
            {

                var alimentoOriginalEntity = await _alimentoRepository.BuscarAlimentoId(alimentoId);
                if (alimentoOriginalEntity == null)
                {
                    _notificationHandler.AddNotification("Alimento original não encontrado.");
                    return new AlimentosAlternativosResponseDTo
                    {
                        AlimentoOriginal = null,
                        AlimentosAlternativos = new List<AlimentoAlternativoDTo>()
                    };
                }

                if (quantidadeGrama <= 0)
                {
                    _notificationHandler.AddNotification("A quantidade em gramas deve ser maior que zero.");
                    return new AlimentosAlternativosResponseDTo
                    {
                        AlimentoOriginal = _mapper.Map<AlimentoDTo>(alimentoOriginalEntity),
                        AlimentosAlternativos = new List<AlimentoAlternativoDTo>()
                    };
                }

                var alimentoOriginalDTo = _mapper.Map<AlimentoDTo>(alimentoOriginalEntity);

                decimal caloriasPorGramaOriginal = alimentoOriginalEntity.Calorias / 100m;
                decimal caloriasAlvo = caloriasPorGramaOriginal * quantidadeGrama;

                const decimal toleranciaPercentualNaBusca = 0.50m; 
                decimal minCaloriasPorGramaAceitavel = caloriasPorGramaOriginal * (1 - toleranciaPercentualNaBusca);
                decimal maxCaloriasPorGramaAceitavel = caloriasPorGramaOriginal * (1 + toleranciaPercentualNaBusca);

                var todosAlimentos = await _alimentoRepository.BuscarAlimentos();

                var listaAlternativasProcessadas = new List<AlimentoAlternativoDTo>();

                foreach (var alimentoAlternativo in todosAlimentos)
                {

                    if (alimentoAlternativo.Id == alimentoOriginalEntity.Id || alimentoAlternativo.Calorias <= 0)
                    {
                        continue;
                    }

                    decimal caloriasPorGramaAlternativo = alimentoAlternativo.Calorias / 100m;

                    if (caloriasPorGramaAlternativo == 0)
                    {
                        continue;
                    }

                    decimal quantidadeGramaNecessaria = caloriasAlvo / caloriasPorGramaAlternativo;

                    if (caloriasPorGramaAlternativo < minCaloriasPorGramaAceitavel || caloriasPorGramaAlternativo > maxCaloriasPorGramaAceitavel)
                    {
                        continue;
                    }


                    listaAlternativasProcessadas.Add(new AlimentoAlternativoDTo
                    {
                        Id = alimentoAlternativo.Id,
                        Nome = alimentoAlternativo.Nome,
                        CaloriasPorGrama = caloriasPorGramaAlternativo,
                        CaloriasNaQuantidadeInformada = caloriasAlvo, 
                        QuantidadeGramaNecessaria = quantidadeGramaNecessaria,
                        Proteinas = alimentoAlternativo.Proteinas,
                        Carboidratos = alimentoAlternativo.Carboidratos,
                        Gorduras = alimentoAlternativo.Gorduras
                    });
                }

                var alternativasOrdenadas = listaAlternativasProcessadas
                    .OrderBy(a => Math.Abs(a.QuantidadeGramaNecessaria - quantidadeGrama)) 
                    .Take(3) 
                    .ToList();


                return new AlimentosAlternativosResponseDTo
                {
                    AlimentoOriginal = alimentoOriginalDTo,
                    AlimentosAlternativos = alternativasOrdenadas
                };
            }
            catch (Exception ex)
            {
                _notificationHandler.AddNotification($"Erro ao buscar alimentos alternativos: {ex.Message}");
                throw;
            }
        }


        #endregion
    }
}
