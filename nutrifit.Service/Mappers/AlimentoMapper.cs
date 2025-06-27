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
        }
    }
}
