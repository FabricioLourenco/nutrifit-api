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
    public class ComentarioPacienteController : QControllerBase
    {
        private readonly IComentarioPacienteService _comentarioPacienteService;

        public ComentarioPacienteController(IComentarioPacienteService comentarioPacienteService)
        {
            _comentarioPacienteService = comentarioPacienteService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Route("inserir-comentario-paciente")]
        public async Task<IActionResult> InserirComentarioPaciente([FromBody] ComentarioPacienteDTo model)
        {
            var comentarioPaciente = await _comentarioPacienteService.InserirComentarioPaciente(model);
            return QResult(comentarioPaciente);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-comentarios-paciente")]
        public async Task<IActionResult> BuscarComentariosPaciente()
        {
            var comentarios = await _comentarioPacienteService.BuscarComentariosPaciente();
            return QResult(comentarios);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-comentario-paciente-por-id")]
        public async Task<IActionResult> BuscarComentarioPacientePorId(long id)
        {
            var comentarioPaciente = await _comentarioPacienteService.BuscarComentarioPacientePorId(id);
            if (comentarioPaciente == null)
            {
                return NotFound();
            }
            return QResult(comentarioPaciente);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-comentarios-paciente-por-paciente")]
        public async Task<IActionResult> BuscarComentariosPacientePorPaciente(long pacienteId)
        {
            var comentarios = await _comentarioPacienteService.BuscarComentariosPacientePorPaciente(pacienteId);
            return QResult(comentarios);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-comentario-paciente")]
        public async Task<IActionResult> AtualizarComentarioPaciente([FromBody] UpdateBaseDTo model)
        {
            var comentarioPaciente = await _comentarioPacienteService.AtualizarComentarioPaciente(model);
            return QResult(comentarioPaciente);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-comentario-paciente")]
        public async Task<IActionResult> ExcluirComentarioPaciente([FromBody] RemoverDTo model)
        {
            var result = await _comentarioPacienteService.ExcluirComentarioPaciente(model.Id);
            return QResult(result);
        }
    }
}
