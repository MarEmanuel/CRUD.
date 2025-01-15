namespace CRUD.Domain.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            IdUsuarios = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string RolName { get; set; } = null!;

        public virtual ICollection<Usuario> IdUsuarios { get; set; }
    }
}
