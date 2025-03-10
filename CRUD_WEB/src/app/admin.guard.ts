import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './pages/services/authentication-service';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AdminGuard implements CanActivate {

    constructor(private authService: AuthService, private router: Router) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

        const userRole = this.authService.getUserRole();

        if (userRole === 'Administrador') {
            return true;
        } else {
            this.router.navigate(['/mi-usuario']); 
            return false;
        }
    }
}
