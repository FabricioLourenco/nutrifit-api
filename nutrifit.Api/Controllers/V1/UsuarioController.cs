using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;

namespace Nutrifit.Api.Controllers.V1
{
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
        [Route("buscar-usuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var arquivos = await _usuarioService.BuscarUsuarios();
            return QResult(arquivos);
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
