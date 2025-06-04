using Microsoft.Extensions.Configuration;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.DI;
using Nutrifit.Infra.CrossCutting.Handlers.Jwt;

namespace Nutrifit.Service.Services
{
    public class AutenticacaoService : IAutenticacaoService, IScopedDependency
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoService(IJwtHandler jwtHandler,
                                   IConfiguration configuration,
                                   IUsuarioRepository usuarioRepository)
        {
            _jwtHandler = jwtHandler;
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }

        #region Private Methods

        private TokenDTo Token(LoginDTo login, Usuario usuario)
        {
            var jwtResponse = _jwtHandler.GetToken(new JwtHandlerOptions()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.TipoUsuario.ToString(),
                ExpireIn = DateTime.UtcNow.AddSeconds(Convert.ToInt32(_configuration.GetSection("JwtHandler:ExpireInSeconds").Value)).ToLocalTime(),
                JwtPrivateKey = _configuration.GetSection("JwtHandler:PrivateKey").Value
            },"UsuarioSistema");

            return new TokenDTo()
            {
                BearerToken = jwtResponse.Token,
                ExpiresIn = jwtResponse.ExpireIn
            };
        }

        #endregion

        #region Public Methods

        public async Task<TokenDTo> GetToken(LoginDTo login)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioLogin(login.Email, login.Senha);
            if (usuario == null)
                throw new Exception($"Não foi localizado o email {login.Email} ou o mesmo encontra-se inativo.");
            return Token(login, usuario);
        }

        #endregion
    }
}
