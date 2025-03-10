using AutoMapper;
using CRUD.Application.DTOs.Request;
using CRUD.Application.DTOs.Response.Sesion;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Commons.Bases.Response;
using CRUD.Utilities.Static;

namespace CRUD.Application.Mappers
{
    public class SesionMappingsProfile : Profile
    {
        public SesionMappingsProfile()
        {
            CreateMap<Sesion, SesionResponseDTO>()
                .ForMember(x => x.SesionActiva, x => x.MapFrom(y =>
                (y.SesionActiva.Equals((char)StateTypes.Activo) ? StateTypes.Activo : StateTypes.Inactivo)))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Sesion>, BaseEntityResponse<SesionResponseDTO>>()
                .ReverseMap();

            CreateMap<SesionRequestDTO, Sesion>();
        }
    }
}
