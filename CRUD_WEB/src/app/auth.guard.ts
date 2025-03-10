// > Sirve para la gestión de la autenticación. Necesario para la gestión de visibilidad de los componentes.
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './pages/services/authentication-service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  constructor(private authService: AuthService, private router: Router) { }

  // > Verifica si existe una sesión activa, caso contrario, redirige.
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
      
    const isAuthenticated = !!localStorage.getItem('UserID') && !!localStorage.getItem('RoleID');

    if (!isAuthenticated) {
      this.router.navigate(['/iniciar-sesion']);
    }

    return isAuthenticated;
  }
}