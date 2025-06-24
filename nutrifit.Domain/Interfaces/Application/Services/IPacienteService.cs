using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IPacienteService
    {
        Task<List<PacienteDTo>> BuscarPacientes();
        Task<PacienteDTo?> BuscarPacientePorId(long id);
        Task<PacienteDTo?> BuscarPacientePorUsuarioId(long usuarioId);
        Task<List<PacienteDTo>> BuscarPacientesPorNutricionista(long nutricionistaId);
        Task<PacienteDTo> AtualizarPaciente(UpdateBaseDTo model);
        Task<bool> ExcluirPaciente(long pacienteId);
    }
}
