using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;

namespace Nutrifit.Api.Controllers.V1
{

    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PacienteController : QControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-pacientes")]
        public async Task<IActionResult> BuscarPacientes()
        {
            var pacientes = await _pacienteService.BuscarPacientes();
            return QResult(pacientes);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-paciente-por-id")]
        public async Task<IActionResult> BuscarPacientePorId(long id)
        {
            var paciente = await _pacienteService.BuscarPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return QResult(paciente);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-paciente-por-usuario-id")]
        public async Task<IActionResult> BuscarPacientePorUsuarioId(long usuarioId)
        {
            var paciente = await _pacienteService.BuscarPacientePorUsuarioId(usuarioId);
            if (paciente == null)
            {
                return NotFound();
            }
            return QResult(paciente);
        }


        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-pacientes-por-nutricionista")]
        public async Task<IActionResult> BuscarPacientesPorNutricionista(long nutricionistaId)
        {
            var pacientes = await _pacienteService.BuscarPacientesPorNutricionista(nutricionistaId);
            return QResult(pacientes);
        }


        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-paciente")]
        [Authorize]
        public async Task<IActionResult> AtualizarPaciente([FromBody] UpdateBaseDTo model)
        {
            var paciente = await _pacienteService.AtualizarPaciente(model);
            return QResult(paciente);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-paciente")]
        [Authorize]
        public async Task<IActionResult> ExcluirPaciente([FromBody] RemoverDTo model)
        {
            var result = await _pacienteService.ExcluirPaciente(model.Id);
            return QResult(result);
        }
    }
}
