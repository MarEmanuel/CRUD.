namespace CRUD.Domain.Entities
{
    public partial class Register
    {
        public string? NombresPersona { get; set; }
        public string? ApellidosPersona { get; set; }
        public string? Identificacion { get; set; }
        public char? Genero { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Mail { get; set; }
        public char? EstadoUsuario { get; set; }
    }
}
