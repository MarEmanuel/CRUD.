namespace CRUD.Application.DTOs.Request
{
    public class UsuarioRequestDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Mail { get; set; }
        public string? EstadoUsuario { get; set; }
        public int IdPersona { get; set; }
        public int IdRol { get; set; }
    }
}
