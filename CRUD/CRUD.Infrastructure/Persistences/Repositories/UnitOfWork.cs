using CRUD.Infrastructure.Persistences.Contexts;
using CRUD.Infrastructure.Persistences.Interfaces;

namespace CRUD.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public IPersonaRepository Persona { get; private set; }
        public IRolRepository Rol { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }
        public IDashboardRepository Dashboard { get; private set; }
        public ISesionRepository Sesion { get; private set; }
        public IPermisoRepository Permiso { get; private set; }
        public IRegisterRepository Register { get; private set; }
        public ILoginRepository Login { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            Persona = new PersonaRepository(context);
            Rol = new RolRepository(context);
            Usuario = new UsuarioRepository(context);
            Dashboard = new DashboardRepository(context);
            Sesion = new SesionRepository(context);
            Permiso = new PermisoRepository(context);
            Register = new RegisterRepository(context);
            Login = new LoginRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
