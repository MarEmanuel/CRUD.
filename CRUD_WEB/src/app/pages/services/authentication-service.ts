import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private router: Router) { }

    getUserRole(): string {
        const roleID = localStorage.getItem('RoleID');
        
        if (roleID === '2') {
            return 'Administrador';
        }
        return 'Usuario';
    }

    isLoggedIn(): boolean {
        return !!localStorage.getItem('UserID') && !!localStorage.getItem('RoleID');
    }

    logout(): void {
        localStorage.removeItem('UserID');
        localStorage.removeItem('RoleID');
        localStorage.removeItem('RoleName');
        localStorage.removeItem('SessionID');
        localStorage.removeItem('token');

        this.router.navigate(['/iniciar-sesion']);
    }
}
