using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Dashboard;

namespace CRUD.Application.Interfaces
{
    public interface IDashboardApplication
    {
        Task<BaseResponse<IEnumerable<AdminDashboardResponseDTO>>> ListarDashboardAdmin();
    }
}
