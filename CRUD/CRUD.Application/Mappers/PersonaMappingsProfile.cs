using AutoMapper;
using CRUD.Application.DTOs.Request;
using CRUD.Application.DTOs.Response.Persona;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Commons.Bases.Response;
using CRUD.Utilities.Static;

namespace CRUD.Application.Mappers
{
    public class PersonaMappingsProfile : Profile
    {
        public PersonaMappingsProfile()
        {
            CreateMap<Persona, PersonaResponseDTO>()
                .ForMember(x => x.IdPersona, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.GeneroDetallado, x => x.MapFrom (y => 
                y.Genero.Equals((char)GenderTypes.Masculino) ? GenderTypes.Masculino : GenderTypes.Femenino))
                .ForMember(x => x.EstadoDetallado, x => x.MapFrom(y =>
                (y.EstadoPersona.Equals((char)StateTypes.Activo) ? StateTypes.Activo : StateTypes.Inactivo)))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Persona>, BaseEntityResponse<PersonaResponseDTO>>()
                .ReverseMap();

            CreateMap<PersonaRequestDTO, Persona>();

            CreateMap<Persona, PersonaSelectResponseDTO>()
                .ForMember(x => x.IdPersona, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
