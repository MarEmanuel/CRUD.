using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IRegisterRepository : IGenericRepository<Register>
    {
        Task InsertarPersonaUsuarioAsync(
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
