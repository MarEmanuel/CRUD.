namespace CRUD.Domain.Entities
{
    public partial class Persona : BaseEntity
    {
        public Persona()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public char Genero { get; set; }
        public char EstadoPersona { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
