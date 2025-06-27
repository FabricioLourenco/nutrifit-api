using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class ItemRefeicaoMapper : Profile
    {
        public ItemRefeicaoMapper()
        {
            CreateMap<ItemRefeicaoDTo, ItemRefeicao>();
            CreateMap<ItemRefeicao, ItemRefeicaoDTo>();
        }
    }
}
