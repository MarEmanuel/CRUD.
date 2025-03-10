export interface AdminDashboard {
    TotalUsuarios: number,
    UsuariosActivos: number,
    UsuariosInactivos: number,
    TotalRoles: number,
    RolesActivos: number,
    RolesInactivos: number,
    TotalPersonas: number,
    PersonasActivas: number,
    PersonasInactivas: number,
}

export interface AdminDashboardApi {
    data: any,
    totalRecords: number
}