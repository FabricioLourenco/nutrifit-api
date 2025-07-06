using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IAlimentoService
    {
        Task<List<AlimentoDTo>> BuscarAlimentos();
        Task<AlimentoDTo?> BuscarAlimentoPorId(long id);
        Task<AlimentoDTo> AtualizarAlimento(UpdateBaseDTo model);
        Task<bool> ExcluirAlimento(long alimentoId);
        Task<PagedResultDTo<AlimentoDTo>> ImportarAlimentosDoIbgePaginado(PaginationDTo pagination);
        Task<AlimentosAlternativosResponseDTo> BuscarAlimentosAlternativos(long alimentoId, decimal quantidadeGrama); 
    }
}
