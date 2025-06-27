using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class RefeicaoMapper : Profile
    {
        public RefeicaoMapper()
        {
            CreateMap<RefeicaoDTo, Refeicao>();
            CreateMap<Refeicao, RefeicaoDTo>();
        }
    }
}
