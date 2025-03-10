using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IPermisoRepository : IGenericRepository<Permiso>
    {
        Task<IEnumerable<Permiso>> ListarPermisosAsync(int idRol);
    }
}
