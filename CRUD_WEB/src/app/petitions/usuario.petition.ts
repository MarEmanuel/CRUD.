export interface Usuario {
    idUsuario?: number,
    Username: string,
    Password?: string,
    Mail: string,
    idPersona?: number,
    NombrePersona?: string,
    EstadoUsuario?: string
}

export interface UsuarioApi{
    data: any,
    totalRecords: number
}