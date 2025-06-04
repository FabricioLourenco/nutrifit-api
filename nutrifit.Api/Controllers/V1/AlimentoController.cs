using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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


        //[HttpGet]
        //[MapToApiVersion(1.0)]
        //[Route("buscar-alimentos")]
        //public async Task<IActionResult> BuscarAlimentos()
        //{
        //    var alimentos = await _alimentoService.BuscarAlimentos();
        //    return QResult(alimentos);
        //}


        //[HttpPost]
        //[MapToApiVersion(1.0)]
        //[Route("inserir-alimento")]
        //public async Task<IActionResult> InserirAlimento([FromBody] AlimentoDTo model)
        //{
        //    var arquivo = await _arquivoService.InserirArquivo(model);
        //    return QResult(arquivo);
        //}

        //[HttpPut]
        //[MapToApiVersion(1.0)]
        //[Route("editar-arquivo")]
        //public async Task<IActionResult> AtualizarArquivo([FromBody] UpdateArquivoDTo model)
        //{
        //    var arquivo = await _arquivoService.AtualizarArquivo(model);
        //    return QResult(arquivo);
        //}

        //[HttpDelete]
        //[MapToApiVersion(1.0)]
        //[Route("excluir-arquivo")]
        //public async Task<IActionResult> ExcluirArquivo([FromBody] RemoverDTo model)
        //{
        //    var arquivo = await _arquivoService.ExcluirArquivo(model.Id);
        //    return QResult(arquivo);
        //}
    }
}
