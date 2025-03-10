import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { catchError, map, Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'
import { ApiResponse } from '../../petitions/api-response';

@Injectable({
    providedIn: 'root'
})
export class SesionService {
    constructor(private _http: HttpClient) { }

    ListarSesiones(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Sesion.LIST_SESSIONS}`
        return this._http.get(requestUrl);
    }

    ListarSesionesPorID(id: Number): Observable<any> {
        const requestUrl = `${ENV.api}${END.Sesion.LIST_SESSIONS_BY_ID}${id}`;
        return this._http.get(requestUrl);
    }

    FinalizarSesion(IdSesion: number, IdUsuario: number): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Sesion.END_SESSION}`;
    
        const requestData = {
            IdSesion: IdSesion,
            IdUsuario: IdUsuario
        };
    
        return this._http.put<ApiResponse>(requestUrl, requestData).pipe(
            map((resp: ApiResponse) => {
                return resp;
            }),
            catchError(error => {
                console.error('Error al finalizar sesión:', error);
                throw error;
            })
        );
    }    
}