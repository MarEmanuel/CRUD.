import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'

@Injectable({
    providedIn: 'root'
})
export class PermisoService {
    constructor(private _http: HttpClient) { }

    ListarPermisosPorRol(idRol: Number): Observable<any> {
        const requestUrl = `${ENV.api}${END.Permiso.LIST_PERMISSES_PER_ROLE}${idRol}`;
        return this._http.get(requestUrl);
    }
}