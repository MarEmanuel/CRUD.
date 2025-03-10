import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { map, Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'
import { Persona } from '../../petitions/persona.petition';
import { ApiResponse } from '../../petitions/api-response';

@Injectable({
    providedIn: 'root'
})
export class PersonaService {
    constructor(private _http: HttpClient) { }

    ListarPersonas(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Persona.LIST_PERSONA}`;
        return this._http.get(requestUrl);
    }

    ListarPersonasSeleccionadas(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Persona.LIST_SELECT_PERSONA}`;
        return this._http.get(requestUrl);
    }

    ListarPersonasPorID(id: Number): Observable<any> {
        const requestUrl = `${ENV.api}${END.Persona.PERSONA_BY_ID}${id}`;
        return this._http.get(requestUrl);
    }
    
    AgregarPersona(persona: Persona): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Persona.PERSONA_REGISTER}`;
        return this._http.post<ApiResponse>(requestUrl, persona).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }

    ActualizarPersona(persona: Persona): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Persona.PERSONA_EDIT}${persona.IdPersona}`;
        console.log(requestUrl);
        return this._http.put<ApiResponse>(requestUrl, persona).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }

    EliminarPersona(persona: Number): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Persona.PERSONA_REMOVE}${persona}`;
        return this._http.put<ApiResponse>(requestUrl, persona).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
}