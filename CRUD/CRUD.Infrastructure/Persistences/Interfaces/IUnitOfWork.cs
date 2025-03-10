namespace CRUD.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Persona { get; }
        IRolRepository Rol { get; }
        IUsuarioRepository Usuario { get; }
        IDashboardRepository Dashboard { get; }
        ISesionRepository Sesion { get; }
        IPermisoRepository Permiso { get; }
        IRegisterRepository Register { get; }
        ILoginRepository Login { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
