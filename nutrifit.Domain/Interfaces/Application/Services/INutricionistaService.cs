using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface INutricionistaService
    {
        Task<List<NutricionistaDTo>> BuscarNutricionistas();
        Task<NutricionistaDTo> BuscarNutricionistaPorId(long id);
        Task<NutricionistaDTo> AtualizarNutricionista(UpdateBaseDTo model);
        Task<bool> ExcluirNutricionista(long nutricionistaId);
    }
}
