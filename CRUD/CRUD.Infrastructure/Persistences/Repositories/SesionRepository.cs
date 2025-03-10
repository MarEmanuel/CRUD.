using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class SesionRepository : GenericRepository<Sesion>, ISesionRepository
    {
        public SesionRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Sesion>> ListarSesionesAsync()
        {
            return await ExecuteStoredProcedureAsync("LeerSesiones");
        }

        public async Task<IEnumerable<Sesion>> ListarSesionPorIDAsync(int IdUsuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", IdUsuario)
            };

            return await ExecuteStoredProcedureAsync("LeerSesionPorID", parameters);
        }

        public async Task IniciarSesionAsync(int IdUsuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@UserID", IdUsuario)
            };

            await ExecuteNonQueryStoredProcedureAsync("GuardarSesionActiva", parameters);
        }

        public async Task FinalizarSesionAsync(int IdSesion, int IdUsuario)
        {
            var parameters = new[]
            {
                new SqlParameter("@SessionID", IdSesion),
                new SqlParameter("@UserID", IdUsuario)
            };

            await ExecuteNonQueryStoredProcedureAsync("GuardarSesionInactiva", parameters);
        }
    }
}
