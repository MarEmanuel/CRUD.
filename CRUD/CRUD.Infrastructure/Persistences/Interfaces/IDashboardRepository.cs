using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IDashboardRepository : IGenericRepository<AdminDashboard>
    {
        Task<IEnumerable<AdminDashboard>> ListarDashboardAdminAsync();
    }
}
