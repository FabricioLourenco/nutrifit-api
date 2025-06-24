using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;

namespace Nutrifit.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NutricionistaController : QControllerBase
    {
        private readonly INutricionistaService _nutricionistaService;

        public NutricionistaController(INutricionistaService nutricionistaService)
        {
            _nutricionistaService = nutricionistaService;
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-nutricionistas")]
        public async Task<IActionResult> BuscarNutricionistas()
        {
            var nutricionistas = await _nutricionistaService.BuscarNutricionistas();
            return QResult(nutricionistas);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-nutricionista-por-id")]
        public async Task<IActionResult> BuscarNutricionistaPorId(long id)
        {
            var nutricionista = await _nutricionistaService.BuscarNutricionistaPorId(id);
            if (nutricionista == null)
            {
                return NotFound(); // QResult deve lidar com isso ou você pode retornar NotFound direto
            }
            return QResult(nutricionista);
        }


        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-nutricionista")]
        public async Task<IActionResult> AtualizarNutricionista([FromBody] UpdateBaseDTo model)
        {
            var nutricionista = await _nutricionistaService.AtualizarNutricionista(model);
            return QResult(nutricionista);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-nutricionista")]
        public async Task<IActionResult> ExcluirNutricionista([FromBody] RemoverDTo model)
        {
            var result = await _nutricionistaService.ExcluirNutricionista(model.Id);
            return QResult(result);
        }
    }
}
