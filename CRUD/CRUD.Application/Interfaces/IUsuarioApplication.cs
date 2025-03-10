using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Usuario;

namespace CRUD.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<BaseResponse<IEnumerable<UsuarioResponseDTO>>> ListarUsuarios();

        Task<BaseResponse<IEnumerable<UsuarioResponseDTO>>> ListarUsuarioPorID(int IdUsuario);

        Task<BaseResponse<bool>> InsertarUsuario(
            string UserUsername,
            string UserPassword,
            string UserMail,
            int PersonID,
            int UserID,
            char UserStatus
        );

        Task<BaseResponse<bool>> ActualizarUsuario(
            int IdUser,
            string UserUsername,
            string UserPassword,
            string UserMail,
            int PersonID,
            int UserID,
            char UserStatus
        );

        Task<BaseResponse<bool>> EliminarUsuario(
            int IdUser
        );
    }
}
