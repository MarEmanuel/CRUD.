export interface Persona {
    IdPersona?: number
    NombresPersona: string,
    ApellidosPersona: string,
    Identificacion: string,
    Genero: string,
    FechaNacimiento: Date,
    EstadoPersona: string
}

export interface PersonaApi {
    data: any,
    totalRecords: number
}