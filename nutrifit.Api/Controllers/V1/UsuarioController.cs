using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;

namespace Nutrifit.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : QControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Route("inserir-usuario")]
        public async Task<IActionResult> InserirUsuario([FromBody] UsuarioDTo model)
        {
            var usuario = await _usuarioService.InserirUsuario(model);
            return QResult(usuario);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("buscar-usuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var arquivos = await _usuarioService.BuscarUsuarios();
            return QResult(arquivos);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Route("buscar-usuario-por-id")]
        public async Task<IActionResult> BuscarUsuarioPorId(long id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound(); 
            }
            return QResult(usuario);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("editar-usuario")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UpdateBaseDTo model)
        {
            var arquivo = await _usuarioService.AtualizarUsuario(model);
            return QResult(arquivo);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Route("excluir-usuario")]
        public async Task<IActionResult> ExcluirUsuario([FromBody] RemoverDTo model)
        {
            var arquivo = await _usuarioService.ExcluirUsuario(model.Id);
            return QResult(arquivo);
        }
    }
}
