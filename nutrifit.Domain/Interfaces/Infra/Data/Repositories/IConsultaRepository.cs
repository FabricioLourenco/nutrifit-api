using Nutrifit.Domain.Entities;

namespace Nutrifit.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IConsultaRepository
    {
        Task<Consulta> InserirConsulta(Consulta entity);
        Task<Consulta> AtualizarConsulta(Consulta entity);
        Task<Consulta?> BuscarConsultaId(long consultaId);
        Task<IEnumerable<Consulta>> BuscarConsultas();
        Task<IEnumerable<Consulta>> BuscarConsultasPorPacienteId(long pacienteId);
        Task<bool> ExcluirConsulta(long consultaId);
    }
}
