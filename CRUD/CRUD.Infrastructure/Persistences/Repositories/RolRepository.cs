using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;
using CRUD.Shared.Models;
using Microsoft.Data.SqlClient;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Rol>> ListarRolesAsync()
        {
            return await ExecuteStoredProcedureAsync("LeerRoles");
        }

        public async Task<IEnumerable<BaseDTO>> ListarRolesSeleccionadosAsync()
        {
            return await ExecuteStoredProcedureForBaseDTOAsync(
                "ListarRoles",
                "idRol",
                "NombreRol"
            );
        }

        public async Task InsertarRolAsync(
            string NombreRol, 
            string DescripcionRol, 
            char EstadoRol
        )
        {
            var parameters = new[]
            {
                new SqlParameter("@RolName", NombreRol),
                new SqlParameter("@RolDescription", DescripcionRol),
                new SqlParameter("@RolStatus", EstadoRol)
            };

            await ExecuteNonQueryStoredProcedureAsync("InsertarRol", parameters);
        }

        public async Task ActualizarRolAsync(
            int IdRol,
            string NombreRol,
            string DescripcionRol,
            char EstadoRol
        )
        {
            var parameters = new[]
            {
                new SqlParameter("@RolId", IdRol),
                new SqlParameter("@RolName", NombreRol),
                new SqlParameter("@RolDescription", DescripcionRol),
                new SqlParameter("@RolStatus", EstadoRol)
            };

            await ExecuteNonQueryStoredProcedureAsync("EditarRol", parameters);
        }

        public async Task EliminarRolAsync(int IdRol)
        {
            var parameters = new[]
            {
                new SqlParameter("@RolId", IdRol)
            };

            await ExecuteNonQueryStoredProcedureAsync("EliminarRol", parameters);
        }
    }
}
