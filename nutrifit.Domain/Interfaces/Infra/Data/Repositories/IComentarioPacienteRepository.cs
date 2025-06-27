using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IComentarioPacienteRepository
    {
        Task<ComentarioPaciente> InserirComentarioPaciente(ComentarioPaciente entity);
        Task<ComentarioPaciente> AtualizarComentarioPaciente(ComentarioPaciente entity);
        Task<ComentarioPaciente?> BuscarComentarioPacienteId(long comentarioPacienteId);
        Task<IEnumerable<ComentarioPaciente>> BuscarComentariosPaciente();
        Task<IEnumerable<ComentarioPaciente>> BuscarComentariosPacientePorPacienteId(long pacienteId);
        Task<bool> ExcluirComentarioPaciente(long comentarioPacienteId);
    }
}
