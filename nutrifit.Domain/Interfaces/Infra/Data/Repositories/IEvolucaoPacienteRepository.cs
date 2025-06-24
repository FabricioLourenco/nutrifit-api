using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IEvolucaoPacienteRepository
    {
        Task<EvolucaoPaciente> InserirEvolucaoPaciente(EvolucaoPaciente entity);
        Task<EvolucaoPaciente> AtualizarEvolucaoPaciente(EvolucaoPaciente entity);
        Task<EvolucaoPaciente?> BuscarEvolucaoPacienteId(long evolucaoPacienteId);
        Task<IEnumerable<EvolucaoPaciente>> BuscarEvolucoesPaciente();
        Task<IEnumerable<EvolucaoPaciente>> BuscarEvolucoesPacientePorPacienteId(long pacienteId);
        Task<bool> ExcluirEvolucaoPaciente(long evolucaoPacienteId);
    }
}
