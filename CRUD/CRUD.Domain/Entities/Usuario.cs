namespace CRUD.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            IdRols = new HashSet<Rol>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Mail { get; set; } = null!;
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
        public string NombrePersona { get; set; } = null!;
        public string NombreRol { get; set; } = null!;
        public char EstadoUsuario { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;

        public virtual ICollection<Rol> IdRols { get; set; }
    }
}
