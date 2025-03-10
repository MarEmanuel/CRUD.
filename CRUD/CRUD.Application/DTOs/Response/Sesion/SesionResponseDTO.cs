namespace CRUD.Application.DTOs.Response.Sesion
{
    public class SesionResponseDTO
    {
        public int IdSesion { get; set; }
        public int IdUsuario { get; set; }
        public string? NombresPersona { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public string? SesionActiva { get; set; }
    }
}
