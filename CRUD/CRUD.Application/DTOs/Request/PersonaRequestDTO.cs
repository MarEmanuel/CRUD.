namespace CRUD.Application.DTOs.Request
{
    public class PersonaRequestDTO
    {
        public string? NombresPersona { get; set; }
        public string? ApellidosPersona { get; set; }
        public string? Identificacion { get; set; }
        public char? Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? EstadoPersona { get; set; }
    }
}
