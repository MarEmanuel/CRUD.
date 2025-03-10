import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { map, Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'
import { ApiResponse } from '../../petitions/api-response';
import { Usuario } from '../../petitions/usuario.petition';
import { Persona } from '../../petitions/persona.petition';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    constructor(private _http: HttpClient) { }

    RegistrarNuevoUsuario(data: Persona & Usuario): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Login.REGISTER_USER_PERSON}`;
        return this._http.post<ApiResponse>(requestUrl, data).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }

    IniciarSesion(username: string, password: string): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Login.START_SESSION}`;

        const requestData = {
            username: username,
            password: password
        };
        
        return this._http.post<ApiResponse>(requestUrl, requestData).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
}