namespace CRUD.Application.DTOs.Request
{
    public class RegistrationRequestDTO
    {
        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public char Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Mail { get; set; } = null!;
    }
}
