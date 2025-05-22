using Nutrifit.Domain.DTos.Base;

namespace Nutrifit.Domain.Interfaces.Application.Services
{
    public interface IAutenticacaoService
    {
        Task<TokenDTo> GetToken(LoginDTo login);
    }
}
