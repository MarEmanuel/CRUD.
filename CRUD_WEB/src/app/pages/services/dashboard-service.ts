import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs';
import { Environment as ENV } from '../../environments/environment'
import { Endpoint as END } from '../../shared/apis/endpoints'

@Injectable({
    providedIn: 'root'
})
export class DashboardService {
    constructor(private _http: HttpClient) { }

    ListarDashboardAdmin(): Observable<any> {
        const requestUrl = `${ENV.api}${END.Dashboard.LIST_ADMIN_DASHBOARD}`;
        return this._http.get(requestUrl);
    }
}