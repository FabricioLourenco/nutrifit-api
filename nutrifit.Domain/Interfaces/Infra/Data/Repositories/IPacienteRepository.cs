using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IPacienteRepository
    {
        Task<Paciente> AtualizarPaciente(Paciente entity);
        Task<Paciente?> BuscarPacienteId(long pacienteId);
        Task<Paciente?> BuscarPacienteByUsuarioId(long usuarioId);
        Task<IEnumerable<Paciente>> BuscarPacientes();
        Task<IEnumerable<Paciente>> BuscarPacientesPorNutricionistaId(long nutricionistaId);
        Task<bool> ExcluirPaciente(long pacienteId);
    }
}
