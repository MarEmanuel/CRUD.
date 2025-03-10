using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Rol;
using CRUD.Shared.Models;

namespace CRUD.Application.Interfaces
{
    public interface IRolApplication
    {
        Task<BaseResponse<IEnumerable<RolResponseDTO>>> ListarRoles();

        Task<BaseResponse<IEnumerable<BaseDTO>>> ListarRolesSeleccionados();

        Task<BaseResponse<bool>> InsertarRol(
            string NombreRol, 
            string DescripcionRol, 
            char EstadoRol
        );
        
        Task<BaseResponse<bool>> ActualizarRol(
            int IdRol,
            string NombreRol,
            string DescripcionRol,
            char EstadoRol
        );

        Task<BaseResponse<bool>> EliminarRol(
            int IdRol
        );
    }
}
