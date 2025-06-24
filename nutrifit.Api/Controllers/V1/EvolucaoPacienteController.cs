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
    public class EvolucaoPacienteController : QControllerBase
    {
        private readonly IEvolucaoPacienteService _evolucaoPacienteService;

        public EvolucaoPacienteController(IEvolucaoPacienteService evolucaoPacienteService)
        {
            _evolucaoPacienteService = evolucaoPacienteService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Route("inserir-evolucao-paciente")]
        public async Task<IActionResult> InserirEvolucaoPaciente([FromBody] EvolucaoPacienteDTo model)
        {
            var evolucaoPaciente = await _evolucaoPacienteService.InserirEvolucaoPaciente(model);
            return QResult(evolucaoPaciente);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-evolucoes-paciente")]
        public async Task<IActionResult> BuscarEvolucoesPaciente()
        {
            var evolucoes = await _evolucaoPacienteService.BuscarEvolucoesPaciente();
            return QResult(evolucoes);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-evolucao-paciente-por-id")]
        public async Task<IActionResult> BuscarEvolucaoPacientePorId(long id)
        {
            var evolucaoPaciente = await _evolucaoPacienteService.BuscarEvolucaoPacientePorId(id);
            if (evolucaoPaciente == null)
            {
                return NotFound();
            }
            return QResult(evolucaoPaciente);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-evolucoes-paciente-por-paciente")]
        public async Task<IActionResult> BuscarEvolucoesPacientePorPaciente(long pacienteId)
        {
            var evolucoes = await _evolucaoPacienteService.BuscarEvolucoesPacientePorPaciente(pacienteId);
            return QResult(evolucoes);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-evolucao-paciente")]
        public async Task<IActionResult> AtualizarEvolucaoPaciente([FromBody] UpdateBaseDTo model)
        {
            var evolucaoPaciente = await _evolucaoPacienteService.AtualizarEvolucaoPaciente(model);
            return QResult(evolucaoPaciente);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-evolucao-paciente")]
        public async Task<IActionResult> ExcluirEvolucaoPaciente([FromBody] RemoverDTo model)
        {
            var result = await _evolucaoPacienteService.ExcluirEvolucaoPaciente(model.Id);
            return QResult(result);
        }
    }
}
