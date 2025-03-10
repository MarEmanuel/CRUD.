using AutoMapper;
using CRUD.Application.DTOs.Response.Dashboard;
using CRUD.Domain.Entities;

namespace CRUD.Application.Mappers
{
    public class AdminDashboardMappingsProfile : Profile
    {
        public AdminDashboardMappingsProfile()
        {
            CreateMap<AdminDashboard, AdminDashboardResponseDTO>()
                .ReverseMap();
        }
    }
}
