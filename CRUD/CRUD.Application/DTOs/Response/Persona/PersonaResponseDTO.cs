namespace CRUD.Application.DTOs.Response.Persona
{
    public class PersonaResponseDTO
    {
        public int IdPersona { get; set; }
        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public char Genero { get; set; }
        public string? GeneroDetallado { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public char EstadoPersona { get; set; }
        public string? EstadoDetallado { get; set; }
    }
}
