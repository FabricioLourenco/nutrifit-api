using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface INutricionistaRepository
    {
        Task<Nutricionista> AtualizarNutricionista(Nutricionista entity);
        Task<Nutricionista?> BuscarNutricionistaId(long nutricionistaId);
        Task<Nutricionista?> BuscarNutricionistaByUsuarioId(long usuarioId);
        Task<IEnumerable<Nutricionista>> BuscarNutricionistas();
        Task<bool> ExcluirNutricionista(long nutricionistaId);
    }
}
