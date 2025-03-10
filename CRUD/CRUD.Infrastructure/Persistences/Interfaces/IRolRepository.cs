using CRUD.Domain.Entities;
using CRUD.Shared.Models;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IRolRepository : IGenericRepository<Rol>
    {
        Task<IEnumerable<Rol>> ListarRolesAsync();

        Task<IEnumerable<BaseDTO>> ListarRolesSeleccionadosAsync();

        Task InsertarRolAsync(
            string NombreRol, 
            string DescripcionRol, 
            char EstadoRol
        );
        
        Task ActualizarRolAsync(
            int IdRol,
            string NombreRol,
            string DescripcionRol,
            char EstadoRol
        );

        Task EliminarRolAsync(
            int IdRol
        );
    }
}
