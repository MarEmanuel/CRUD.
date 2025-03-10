using AutoMapper;
using CRUD.Application.DTOs.Request;
using CRUD.Application.DTOs.Response.Login;
using CRUD.Domain.Entities;

namespace CRUD.Application.Mappers
{
    public class RegisterMappingsProfile : Profile
    {
        public RegisterMappingsProfile()
        {
            CreateMap<RegistrationRequestDTO, Register>();
        }
    }
}
