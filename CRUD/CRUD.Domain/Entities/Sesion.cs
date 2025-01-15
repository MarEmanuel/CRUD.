namespace CRUD.Domain.Entities
{
    public partial class Sesion
    {
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
