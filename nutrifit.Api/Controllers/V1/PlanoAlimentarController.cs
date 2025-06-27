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
    public class PlanoAlimentarController : QControllerBase
    {
        private readonly IPlanoAlimentarService _planoAlimentarService;

        public PlanoAlimentarController(IPlanoAlimentarService planoAlimentarService)
        {
            _planoAlimentarService = planoAlimentarService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Route("inserir-plano-alimentar")]
        public async Task<IActionResult> InserirPlanoAlimentar([FromBody] PlanoAlimentarDTo model)
        {
            var planoAlimentar = await _planoAlimentarService.InserirPlanoAlimentar(model);
            return QResult(planoAlimentar);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-planos-alimentares")]
        public async Task<IActionResult> BuscarPlanosAlimentares()
        {
            var planos = await _planoAlimentarService.BuscarPlanosAlimentares();
            return QResult(planos);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-plano-alimentar-por-id")]
        public async Task<IActionResult> BuscarPlanoAlimentarPorId(long id)
        {
            var plano = await _planoAlimentarService.BuscarPlanoAlimentarPorId(id);
            if (plano == null)
            {
                return NotFound();
            }
            return QResult(plano);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-planos-alimentares-por-paciente")]
        public async Task<IActionResult> BuscarPlanosAlimentaresPorPaciente(long pacienteId)
        {
            var planos = await _planoAlimentarService.BuscarPlanosAlimentaresPorPaciente(pacienteId);
            return QResult(planos);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-plano-alimentar")]
        public async Task<IActionResult> AtualizarPlanoAlimentar([FromBody] UpdateBaseDTo model)
        {
            var planoAlimentar = await _planoAlimentarService.AtualizarPlanoAlimentar(model);
            return QResult(planoAlimentar);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-plano-alimentar")]
        public async Task<IActionResult> ExcluirPlanoAlimentar([FromBody] RemoverDTo model)
        {
            var result = await _planoAlimentarService.ExcluirPlanoAlimentar(model.Id);
            return QResult(result);
        }
    }
}
