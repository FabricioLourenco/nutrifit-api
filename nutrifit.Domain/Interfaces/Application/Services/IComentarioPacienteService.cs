using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IComentarioPacienteService
    {
        Task<ComentarioPacienteDTo> InserirComentarioPaciente(ComentarioPacienteDTo model);
        Task<List<ComentarioPacienteDTo>> BuscarComentariosPaciente();
        Task<ComentarioPacienteDTo?> BuscarComentarioPacientePorId(long id);
        Task<List<ComentarioPacienteDTo>> BuscarComentariosPacientePorPaciente(long pacienteId);
        Task<ComentarioPacienteDTo> AtualizarComentarioPaciente(UpdateBaseDTo model);
        Task<bool> ExcluirComentarioPaciente(long comentarioPacienteId);
    }
}
