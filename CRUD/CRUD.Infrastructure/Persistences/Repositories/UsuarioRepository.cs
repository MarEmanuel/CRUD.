using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Usuario>> ListarUsuariosAsync()
        {
            return await ExecuteStoredProcedureAsync("LeerUsuarios");
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarioPorIDAsync(int IdUsuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", IdUsuario)
            };

            return await ExecuteStoredProcedureAsync("LeerUsuarioPorID", parameters);
        }

        public async Task InsertarUsuarioAsync(
            string UserUsername, 
            string UserPassword, 
            string UserMail, 
            int PersonID,
            int RoleID,
            char UserStatus
        )
        {
            var parameters = new[]
             {
                new SqlParameter("@UserUsername", UserUsername),
                new SqlParameter("@UserPassword", UserPassword),
                new SqlParameter("@UserMail", UserMail),
                new SqlParameter("@PersonID", PersonID),
                new SqlParameter("@UserRole", RoleID),
                new SqlParameter("@UserStatus", UserStatus)
            };

            await ExecuteNonQueryStoredProcedureAsync("InsertarUsuario", parameters);
        }

        public async Task ActualizarUsuarioAsync(
            int IdUser, 
            string UserUsername, 
            string UserPassword, 
            string UserMail, 
            int PersonID,
            int RoleID,
            char UserStatus
        )
        {
            var parameters = new[]
             {
                new SqlParameter("@UserID", IdUser),
                new SqlParameter("@UserUsername", UserUsername),
                new SqlParameter("@UserPassword", UserPassword),
                new SqlParameter("@UserMail", UserMail),
                new SqlParameter("@PersonID", PersonID),
                new SqlParameter("@UserRole", RoleID),
                new SqlParameter("@UserStatus", UserStatus)
            };

            await ExecuteNonQueryStoredProcedureAsync("EditarUsuario", parameters);
        }

        public async Task EliminarUsuarioAsync(int IdUser)
        {
            var parameters = new[]
             {
                new SqlParameter("@UserID", IdUser),
            };

            await ExecuteNonQueryStoredProcedureAsync("EliminarUsuario", parameters);
        }
    }
}
