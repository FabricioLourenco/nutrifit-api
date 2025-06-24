using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Interfaces.Application.Services;

namespace Nutrifit.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ConsultaController : QControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Route("inserir-consulta")]
        public async Task<IActionResult> InserirConsulta([FromBody] ConsultaDTo model)
        {
            var consulta = await _consultaService.InserirConsulta(model);
            return QResult(consulta);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-consultas")]
        public async Task<IActionResult> BuscarConsultas()
        {
            var consultas = await _consultaService.BuscarConsultas();
            return QResult(consultas);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-consulta-por-id")]
        public async Task<IActionResult> BuscarConsultaPorId(long id)
        {
            var consulta = await _consultaService.BuscarConsultaPorId(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return QResult(consulta);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-consultas-por-paciente")]
        public async Task<IActionResult> BuscarConsultasPorPaciente(long pacienteId)
        {
            var consultas = await _consultaService.BuscarConsultasPorPaciente(pacienteId);
            return QResult(consultas);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-consulta")]
        public async Task<IActionResult> AtualizarConsulta([FromBody] UpdateBaseDTo model)
        {
            var consulta = await _consultaService.AtualizarConsulta(model);
            return QResult(consulta);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-consulta")]
        public async Task<IActionResult> ExcluirConsulta([FromBody] RemoverDTo model)
        {
            var result = await _consultaService.ExcluirConsulta(model.Id);
            return QResult(result);
        }
    }
}
