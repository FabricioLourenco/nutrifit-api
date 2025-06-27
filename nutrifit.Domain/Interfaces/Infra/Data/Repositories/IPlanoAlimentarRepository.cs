using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IPlanoAlimentarRepository
    {
        Task<PlanoAlimentar> InserirPlanoAlimentar(PlanoAlimentar entity);
        Task<PlanoAlimentar> AtualizarPlanoAlimentar(PlanoAlimentar entity);
        Task<PlanoAlimentar?> BuscarPlanoAlimentarId(long planoAlimentarId);
        Task<IEnumerable<PlanoAlimentar>> BuscarPlanosAlimentares();
        Task<IEnumerable<PlanoAlimentar>> BuscarPlanosAlimentaresPorPacienteId(long pacienteId);
        Task<bool> ExcluirPlanoAlimentar(long planoAlimentarId);
    }
}
