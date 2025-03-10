using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ListarUsuariosAsync();

        Task<IEnumerable<Usuario>> ListarUsuarioPorIDAsync(int IdUsuario);
        
        Task InsertarUsuarioAsync(
            string UserUsername, 
            string UserPassword,
            string UserMail,
            int PersonID,
            int RoleID,
            char UserStatus
        );

        Task ActualizarUsuarioAsync(
            int IdUser,
            string UserUsername,
            string UserPassword,
            string UserMail,
            int PersonID,
            int RoleID,
            char UserStatus
        );

        Task EliminarUsuarioAsync(
            int IdUser
        );
    }
}
