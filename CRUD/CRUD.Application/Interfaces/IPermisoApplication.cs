using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Permiso;

namespace CRUD.Application.Interfaces
{
    public interface IPermisoApplication
    {
        Task<BaseResponse<IEnumerable<PermisoResponseDTO>>> ListarPermisosPorRol(int idRol);
    }
}
