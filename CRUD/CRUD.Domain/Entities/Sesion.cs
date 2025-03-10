namespace CRUD.Domain.Entities
{
    public partial class Sesion
    {
        public int IdSesion { get; set; }
        public int IdUsuario { get; set; }
        public string? NombresPersona { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public char SesionActiva { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
