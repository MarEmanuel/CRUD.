export interface Rol {
    IdRol?: number,
    NombreRol: string,
    DescripcionRol: string,
    EstadoRol: string
}

export interface RolApi{
    data: any,
    totalRecords: number
}