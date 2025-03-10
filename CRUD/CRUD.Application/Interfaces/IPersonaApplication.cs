using CRUD.Application.Commons.Bases;
using CRUD.Application.DTOs.Response.Persona;
using CRUD.Shared.Models;

namespace CRUD.Application.Interfaces
{
    public interface IPersonaApplication
    {
        Task<BaseResponse<IEnumerable<PersonaResponseDTO>>> ListarPersonas();

        Task<BaseResponse<IEnumerable<BaseDTO>>> ListarPersonasSeleccionadas();

        Task<BaseResponse<IEnumerable<PersonaResponseDTO>>> ListarPersonaPorID(int IdPersona);

        Task<BaseResponse<bool>> InsertarPersona(
            string NombresPersona, 
            string ApellidosPersona, 
            string Identificacion, 
            char Genero, 
            DateTime FechaNacimiento, 
            char EstadoPersona
        );

        Task<BaseResponse<bool>> ActualizarPersona(
            int IdPersona,
            string NombresPersona,
            string ApellidosPersona,
            string Identificacion,
            char Genero,
            DateTime FechaNacimiento,
            char EstadoPersona
        );

        Task<BaseResponse<bool>> EliminarPersona(
            int IdPersona
        );
    }
}
