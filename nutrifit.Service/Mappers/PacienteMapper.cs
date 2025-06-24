using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<PacienteDTo, Paciente>();
            CreateMap<Paciente, PacienteDTo>();
        }
    }
}
