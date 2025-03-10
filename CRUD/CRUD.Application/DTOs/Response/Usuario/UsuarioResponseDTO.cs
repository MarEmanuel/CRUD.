namespace CRUD.Application.DTOs.Response.Usuario
{
    public class UsuarioResponseDTO
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; } = null!;
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;
        public char EstadoUsuario { get; set; }
        public string? EstadoDetallado { get; set; }
    }
}
