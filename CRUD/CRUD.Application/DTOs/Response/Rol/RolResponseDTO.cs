namespace CRUD.Application.DTOs.Response.Rol
{
    public class RolResponseDTO
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;
        public string DescripcionRol { get; set; } = null!;
        public char EstadoRol { get; set; }
        public string? EstadoDetallado { get; set; }
    }
}
