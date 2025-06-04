using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class NutricionistaMapper : Profile
    {
        public NutricionistaMapper()
        {
            CreateMap<NutricionistaDTo, Nutricionista>();
        }
    }
}
