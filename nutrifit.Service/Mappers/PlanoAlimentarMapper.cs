using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class PlanoAlimentarMapper : Profile
    {
        public PlanoAlimentarMapper()
        {
            CreateMap<PlanoAlimentarDTo, PlanoAlimentar>();
            CreateMap<PlanoAlimentar, PlanoAlimentarDTo>();
        }
    }
}
