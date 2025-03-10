using AutoMapper;
using CRUD.Application.DTOs.Request;
using CRUD.Application.DTOs.Response.Usuario;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Commons.Bases.Response;
using CRUD.Utilities.Static;

namespace CRUD.Application.Mappers
{
    public class UsuarioMappingsProfile : Profile
    {
        public UsuarioMappingsProfile()
        {
            CreateMap<Usuario, UsuarioResponseDTO>()
               .ForMember(x => x.IdUsuario, x => x.MapFrom(y => y.Id))
               .ForMember(x => x.EstadoDetallado, x => x.MapFrom(y =>
               (y.EstadoUsuario.Equals((char)StateTypes.Activo) ? StateTypes.Activo : StateTypes.Inactivo)))
               .ReverseMap();

            CreateMap<BaseEntityResponse<Usuario>, BaseEntityResponse<UsuarioResponseDTO>>()
                .ReverseMap();

            CreateMap<UsuarioRequestDTO, Usuario>();

            CreateMap<Usuario, UsuarioSelectResponseDTO>()
                .ForMember(x => x.IdUsuario, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
