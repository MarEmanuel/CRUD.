using CRUD.Application.Commons.Bases;

namespace CRUD.Application.Interfaces
{
    public interface IRegisterApplication
    {
        Task<BaseResponse<bool>> InsertarPersonaUsuario(
            string NombresPersona,
            string ApellidosPersona,
            string Identificacion,
            char Genero,
            DateTime FechaNacimiento,
            string Username,
            string Password,
            string Mail
         );
    }
}
