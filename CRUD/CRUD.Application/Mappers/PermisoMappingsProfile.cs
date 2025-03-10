using AutoMapper;
using CRUD.Application.DTOs.Response.Permiso;
using CRUD.Domain.Entities;

namespace CRUD.Application.Mappers
{
    public class PermisoMappingsProfile : Profile
    {
        public PermisoMappingsProfile()
        {
            CreateMap<Permiso, PermisoResponseDTO>()
                .ReverseMap();
        }
    }
}
