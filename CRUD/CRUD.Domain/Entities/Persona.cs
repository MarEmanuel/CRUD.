namespace CRUD.Domain.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
