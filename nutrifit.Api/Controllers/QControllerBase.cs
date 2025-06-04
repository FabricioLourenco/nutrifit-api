using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace Nutrifit.Api.Controllers
{
    public class QControllerBase : ControllerBase
    {
        public QControllerBase() { }

        protected JwtSecurityToken GetToken()
        {
            var jwt = (Request.Headers[HeaderNames.Authorization]).FirstOrDefault()?.Split(" ").Last();
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(jwt);
        }

        protected object GetValueByClaims(JwtSecurityToken token, string typeClaim)
        {
            var claims = token.Claims.Where(c => c.Type == typeClaim);
            if (claims.Any())
                return claims.FirstOrDefault().Value;
            return null;
        }

        protected string GetApiKeyRequest()
        {
            var headers = Request.Headers;

            headers.TryGetValue("x-api-key", out var apikeyRequest);

            return apikeyRequest;
        }

        protected ActionResult QResult(object? value = null)
        {
            return new JsonResult(value);
        }
    }
}
