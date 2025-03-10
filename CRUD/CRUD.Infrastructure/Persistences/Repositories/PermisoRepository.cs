using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class PermisoRepository : GenericRepository<Permiso>, IPermisoRepository
    {
        public PermisoRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Permiso>> ListarPermisosAsync(int idRol)
        {
            var parameters = new[]
            {
                new SqlParameter("@IDRol", idRol)
            };

            return await ExecuteStoredProcedureAsync("ListarPermisosDeRol", parameters);
        }
    }
}
