using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nutrifit.Api.Filters;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Infra.CrossCutting.Handlers.Notifications;

namespace Nutrifit.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticacaoController : QControllerBase
    {
        private readonly INotificationHandler _notificationHandler;
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService, INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [TypeFilter(typeof(ApiKeyAttribute))]
        public async Task<IActionResult> Login(LoginDTo login)
        {
            return QResult(await _autenticacaoService.GetToken(login));
        }
    }
}
