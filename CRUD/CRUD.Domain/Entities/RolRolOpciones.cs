namespace CRUD.Domain.Entities
{
    public partial class RolRolOpciones
    {
        public int RolIdRol { get; set; }
        public int RolOpcionesIdOpciones { get; set; }

        public virtual Rol RolIdRolNavigation { get; set; } = null!;
        public virtual RolOpciones RolOpcionesIdOpcionesNavigation { get; set; } = null!;
    }
}
