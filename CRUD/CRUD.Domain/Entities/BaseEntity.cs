namespace CRUD.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int? Id { get; set; }
        public int? UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioEdicion { get; set; }
        public DateTime? FechaEdicion { get; set; }
        public int? UsuarioEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public char? EsActivo { get; set; }
    }
}
