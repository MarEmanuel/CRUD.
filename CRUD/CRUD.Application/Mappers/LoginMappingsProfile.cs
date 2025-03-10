using AutoMapper;
using CRUD.Application.DTOs.Request;
using CRUD.Application.DTOs.Response.Login;
using CRUD.Domain.Entities;

namespace CRUD.Application.Mappers
{
    public class LoginMappingsProfile : Profile
    {
        public LoginMappingsProfile()
        {
            CreateMap<LoginRequestDTO, Login>();
            CreateMap<Login, LoginResponseDTO>();
        }
    }
}
