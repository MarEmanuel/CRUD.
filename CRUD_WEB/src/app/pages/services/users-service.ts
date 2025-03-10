import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { map, Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'
import { Usuario } from '../../petitions/usuario.petition';
import { ApiResponse } from '../../petitions/api-response';

@Injectable({
    providedIn: 'root'
})
export class UsersService {
    constructor(private _http: HttpClient) { }

    ListarUsuarios(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Usuario.LIST_USUARIO}`
        return this._http.get(requestUrl);
    }
    
    ListarUsuarioPorID(id: Number): Observable<any> {
        const requestUrl = `${ENV.api}${END.Usuario.USUARIO_BY_ID}${id}`;
        return this._http.get(requestUrl);
    }

    AgregarUsuario(user: Usuario): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Usuario.USUARIO_REGISTER}`;
        return this._http.post<ApiResponse>(requestUrl, user).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
    
    ActualizarUsuario(user: Usuario): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Usuario.USUARIO_EDIT}${user.idUsuario}`;
        return this._http.put<ApiResponse>(requestUrl, user).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }

    EliminarUsuario(user: Usuario): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Usuario.USUARIO_REMOVE}${user.idUsuario}`;
        return this._http.put<ApiResponse>(requestUrl, user).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
}