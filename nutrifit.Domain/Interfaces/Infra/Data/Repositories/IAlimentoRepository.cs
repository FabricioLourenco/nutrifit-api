using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IAlimentoRepository
    {
        Task AddAlimentoAsync(Alimento entity); 
        Task AddRangeAlimentosAsync(IEnumerable<Alimento> entities);
        Task<Alimento?> BuscarAlimentoByAlimentoIbgeId(int alimentoIbgeId); 
        Task<Alimento> AtualizarAlimento(Alimento entity);
        Task<Alimento?> BuscarAlimentoId(long alimentoId);
        Task<IEnumerable<Alimento>> BuscarAlimentos();
        Task<bool> ExcluirAlimento(long alimentoId);
    }
}
