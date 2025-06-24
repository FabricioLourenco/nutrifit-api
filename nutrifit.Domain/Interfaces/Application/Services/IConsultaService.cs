using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IConsultaService
    {
        Task<ConsultaDTo> InserirConsulta(ConsultaDTo model);
        Task<List<ConsultaDTo>> BuscarConsultas();
        Task<ConsultaDTo?> BuscarConsultaPorId(long id);
        Task<List<ConsultaDTo>> BuscarConsultasPorPaciente(long pacienteId);
        Task<ConsultaDTo> AtualizarConsulta(UpdateBaseDTo model);
        Task<bool> ExcluirConsulta(long consultaId);
    }
}
