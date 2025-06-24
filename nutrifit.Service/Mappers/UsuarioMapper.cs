using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioDTo, Usuario>();

            CreateMap<Usuario, UsuarioDTo>();
        }
    }
}
