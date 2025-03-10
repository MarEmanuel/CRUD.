import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { map, Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'
import { Rol } from '../../petitions/rol.petition';
import { ApiResponse } from '../../petitions/api-response';

@Injectable({
    providedIn: 'root'
})
export class RolService {
    constructor(private _http: HttpClient) { }

    ListarRoles(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Rol.LIST_ROL}`
        return this._http.get(requestUrl);
    }

    ListarRolesSeleccionados(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Rol.LIST_SELECT_ROL}`;
        return this._http.get(requestUrl);
    }

    AgregarRol(rol: Rol): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Rol.ROL_REGISTER}`;
        return this._http.post<ApiResponse>(requestUrl, rol).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
    
    ActualizarRol(rol: Rol): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Rol.ROL_EDIT}${rol.IdRol}`;
        return this._http.put<ApiResponse>(requestUrl, rol).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
    
    EliminarRol(rol: Number): Observable<ApiResponse> {
        const requestUrl = `${ENV.api}${END.Rol.ROL_REMOVE}${rol}`;
        return this._http.put<ApiResponse>(requestUrl, rol).pipe(
            map((resp: ApiResponse) => {
                return resp;
            })
        );
    }
}