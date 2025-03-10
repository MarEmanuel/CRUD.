namespace CRUD.Domain.Entities
{
    public partial class Rol : BaseEntity
    {
        public Rol()
        {
            IdUsuarios = new HashSet<Usuario>();
        }

        public string NombreRol { get; set; } = null!;
        public string DescripcionRol { get; set; } = null!;
        public char EstadoRol { get; set; }

        public virtual ICollection<Usuario> IdUsuarios { get; set; }
    }
}
