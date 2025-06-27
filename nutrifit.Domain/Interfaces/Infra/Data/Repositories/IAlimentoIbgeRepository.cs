using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IAlimentoIbgeRepository
    {
        Task<AlimentoIbge?> BuscarAlimentoIbgePorNumero(int numeroDoAlimento);
        Task<IEnumerable<AlimentoIbge>> BuscarTodosAlimentosIbge();
        Task<PagedResultDTo<AlimentoIbge>> BuscarAlimentosIbgePaginado(PaginationDTo pagination);
    }
}
