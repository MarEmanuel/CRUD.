using CRUD.Domain.Entities;
using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class DashboardRepository : GenericRepository<AdminDashboard>, IDashboardRepository
    {
        public DashboardRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<AdminDashboard>> ListarDashboardAdminAsync()
        {
            var result = await ExecuteStoredProcedureForNonBaseEntity("DatosDashboardAdmin");

            var dashboardList = result.Select(row => new AdminDashboard
            {
                TotalUsuarios = Convert.ToInt32(row["TotalUsuarios"]),
                UsuariosActivos = Convert.ToInt32(row["UsuariosActivos"]),
                UsuariosInactivos = Convert.ToInt32(row["UsuariosInactivos"]),
                TotalRoles = Convert.ToInt32(row["TotalRoles"]),
                RolesActivos = Convert.ToInt32(row["RolesActivos"]),
                RolesInactivos = Convert.ToInt32(row["RolesInactivos"]),
                TotalPersonas = Convert.ToInt32(row["TotalPersonas"]),
                PersonasActivas = Convert.ToInt32(row["PersonasActivas"]),
                PersonasInactivas = Convert.ToInt32(row["PersonasInactivas"])
            });

            return dashboardList;
        }
    }
}
