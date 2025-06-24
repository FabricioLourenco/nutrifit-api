using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IEvolucaoPacienteService
    {
        Task<EvolucaoPacienteDTo> InserirEvolucaoPaciente(EvolucaoPacienteDTo model);
        Task<List<EvolucaoPacienteDTo>> BuscarEvolucoesPaciente();
        Task<EvolucaoPacienteDTo?> BuscarEvolucaoPacientePorId(long id);
        Task<List<EvolucaoPacienteDTo>> BuscarEvolucoesPacientePorPaciente(long pacienteId);
        Task<EvolucaoPacienteDTo> AtualizarEvolucaoPaciente(UpdateBaseDTo model);
        Task<bool> ExcluirEvolucaoPaciente(long evolucaoPacienteId);
    }
}
