using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class ConsultaMapper : Profile
    {
        public ConsultaMapper()
        {
            CreateMap<ConsultaDTo, Consulta>();
            CreateMap<Consulta, ConsultaDTo>();
        }
    }
}
