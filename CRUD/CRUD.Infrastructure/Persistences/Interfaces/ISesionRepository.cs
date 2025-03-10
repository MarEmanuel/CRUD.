using CRUD.Domain.Entities;

namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface ISesionRepository : IGenericRepository<Sesion>
    {
        Task<IEnumerable<Sesion>> ListarSesionesAsync();

        Task<IEnumerable<Sesion>> ListarSesionPorIDAsync(int IdUsuario);

        Task IniciarSesionAsync(int IdUsuario);

        Task FinalizarSesionAsync(int IdSesion, int IdUsuario);
    }
}
