namespace CRUD.Domain.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            IdRols = new HashSet<Rol>();
        }

        public int IdUsuario { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Mail { get; set; }
        public string SesionActiva { get; set; } = null!;
        public int IdPersona { get; set; }
        public string Status { get; set; } = null!;

        public virtual Persona IdPersonaNavigation { get; set; } = null!;

        public virtual ICollection<Rol> IdRols { get; set; }
    }
}
