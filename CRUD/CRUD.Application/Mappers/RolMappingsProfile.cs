using AutoMapper;
using CRUD.Application.DTOs.Request;
using CRUD.Application.DTOs.Response.Rol;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Commons.Bases.Response;
using CRUD.Utilities.Static;

namespace CRUD.Application.Mappers
{
    public class RolMappingsProfile : Profile
    {
        public RolMappingsProfile()
        {
            CreateMap<Rol, RolResponseDTO>()
                .ForMember(x => x.IdRol, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.EstadoDetallado, x => x.MapFrom(y =>
                (y.EstadoRol.Equals((char)StateTypes.Activo) ? StateTypes.Activo : StateTypes.Inactivo)))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Rol>, BaseEntityResponse<RolResponseDTO>>()
                .ReverseMap();

            CreateMap<RolRequestDTO, Rol>();

            CreateMap<Rol, RolSelectResponseDTO>()
                .ForMember(x => x.IdRol, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
