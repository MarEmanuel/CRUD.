using CRUD.Domain.Entities;
using CRUD.Shared.Models;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {
        Task<IEnumerable<Persona>> ListarPersonasAsync();

        Task<IEnumerable<BaseDTO>> ListarPersonasSeleccionadasAsync();

        Task<IEnumerable<Persona>> ListarPersonaPorIDAsync(int IdPersona);

        Task InsertarPersonaAsync(
            string NombresPersona, 
            string ApellidosPersona, 
            string Identificacion,
            char Genero,
            DateTime FechaNacimiento,
            char EstadoPersona
        );

        Task ActualizarPersonaAsync(
            int IdPersona,
            string NombresPersona,
            string ApellidosPersona,
            string Identificacion,
            char Genero,
            DateTime FechaNacimiento,
            char EstadoPersona
        );

        Task EliminarPersonaAsync(
            int IdPersona
        );
    }
}
