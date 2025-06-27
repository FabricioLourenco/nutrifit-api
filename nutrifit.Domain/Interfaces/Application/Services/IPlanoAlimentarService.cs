using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IPlanoAlimentarService
    {
        Task<PlanoAlimentarDTo> InserirPlanoAlimentar(PlanoAlimentarDTo model);
        Task<List<PlanoAlimentarDTo>> BuscarPlanosAlimentares();
        Task<PlanoAlimentarDTo?> BuscarPlanoAlimentarPorId(long id);
        Task<List<PlanoAlimentarDTo>> BuscarPlanosAlimentaresPorPaciente(long pacienteId);
        Task<PlanoAlimentarDTo> AtualizarPlanoAlimentar(UpdateBaseDTo model);
        Task<bool> ExcluirPlanoAlimentar(long planoAlimentarId);
    }
}
