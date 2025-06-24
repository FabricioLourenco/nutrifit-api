using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class EvolucaoPacienteMapper : Profile
    {
        public EvolucaoPacienteMapper()
        {
            CreateMap<EvolucaoPacienteDTo, EvolucaoPaciente>();
            CreateMap<EvolucaoPaciente, EvolucaoPacienteDTo>();
        }  
    }
}
