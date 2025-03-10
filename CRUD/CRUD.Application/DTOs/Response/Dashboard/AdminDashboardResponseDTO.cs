namespace CRUD.Application.DTOs.Response.Dashboard
{
    public class AdminDashboardResponseDTO
    {
        public int TotalUsuarios { get; set; }
        public int UsuariosActivos { get; set; }
        public int UsuariosInactivos { get; set; }
        public int TotalRoles { get; set; }
        public int RolesActivos { get; set; }
        public int RolesInactivos { get; set; }
        public int TotalPersonas { get; set; }
        public int PersonasActivas { get; set; }
        public int PersonasInactivas { get; set; }
    }
}
