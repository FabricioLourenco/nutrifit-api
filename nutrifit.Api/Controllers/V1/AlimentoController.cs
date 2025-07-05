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
    public class AlimentoController : QControllerBase
    {
        private readonly IAlimentoService _alimentoService;

        public AlimentoController(IAlimentoService alimentoService)
        {
            _alimentoService = alimentoService;
        }

        [HttpGet] 
        [MapToApiVersion(1.0)]
        [Route("importar-ibge-paginado")]
        public async Task<IActionResult> ImportarAlimentosIbgePaginado(
        [FromQuery] int pageNumber = 1, 
        [FromQuery] int pageSize = 100) 
        {
            var pagination = new PaginationDTo
            {
                PageNumber = pageNumber,
                PageSize = pageSize 
            };

            var result = await _alimentoService.ImportarAlimentosDoIbgePaginado(pagination);
            return QResult(result);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-alimentos")]
        public async Task<IActionResult> BuscarAlimentos()
        {
            var alimentos = await _alimentoService.BuscarAlimentos();
            return QResult(alimentos);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-alimento-por-id")]
        public async Task<IActionResult> BuscarAlimentoPorId(long id)
        {
            var alimento = await _alimentoService.BuscarAlimentoPorId(id);
            if (alimento == null)
            {
                return NotFound();
            }
            return QResult(alimento);
        }

    }
}
