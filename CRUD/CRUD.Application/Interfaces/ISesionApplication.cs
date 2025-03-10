using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Sesion;

namespace CRUD.Application.Interfaces
{
    public interface ISesionApplication
    {
        Task<BaseResponse<IEnumerable<SesionResponseDTO>>> ListarSesiones();

        Task<BaseResponse<IEnumerable<SesionResponseDTO>>> ListarSesionPorID(int IdUsuario);

        Task<BaseResponse<bool>> IniciarSesion(int IdUsuario);

        Task<BaseResponse<bool>> FinalizarSesion(int IdSesion, int IdUsuario);
    }
}
