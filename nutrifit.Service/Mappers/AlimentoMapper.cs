using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class AlimentoMapper : Profile
    {
        public AlimentoMapper()
        {
            CreateMap<Alimento, AlimentoDTo>();
            CreateMap<Alimento, AlimentoAlternativoDTo>()
            .ForMember(dest => dest.CaloriasPorGrama, opt => opt.MapFrom(src => src.Calorias / 100m)) 
            .ForMember(dest => dest.CaloriasNaQuantidadeInformada, opt => opt.Ignore()); 
        }
    }
}
