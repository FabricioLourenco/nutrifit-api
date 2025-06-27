using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.Entities;

namespace Nutrifit.Service.Mappers
{
    public class ComentarioPacienteMapper : Profile
    {
        public ComentarioPacienteMapper()
        {
            CreateMap<ComentarioPacienteDTo, ComentarioPaciente>();
            CreateMap<ComentarioPaciente, ComentarioPacienteDTo>();
        }
    }
}
