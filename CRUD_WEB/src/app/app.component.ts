import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { AuthService } from './pages/services/authentication-service';
import { PermisoService } from './pages/services/permiso-service';
import { MaterialModule } from './modules/material.module';
import { RouterModule } from '@angular/router';
import { SesionService } from './pages/services/sesion-service';
import { SnackBarHelper } from './shared/functions/snack-bar';
import { MatSnackBar } from '@angular/material/snack-bar';

interface Permiso {
  nombreRol: string;
  nombrePermiso: string;
  rutaPermiso: string;
  descripcionPermiso: string;
  iconoPermiso: string;
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, MaterialModule, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'crud-web';

  private snackBarHelper: SnackBarHelper;
  isLoginPage: boolean = false;

  permisos: Permiso[] = [];

  constructor(
    private authService: AuthService,
    private permisoService: PermisoService,
    private sesionService: SesionService,
    private snackBar: MatSnackBar,
    private router: Router) { 
      this.snackBarHelper = new SnackBarHelper(this.snackBar)}

  ngOnInit() {
    this.router.events.subscribe(() => {
      this.isLoginPage = this.router.url === '/iniciar-sesion';
    });
    
    this.ObtenerPermisos();
  }

  ObtenerPermisos() {
    const roleID = localStorage.getItem('RoleID')!;
    const roleIDNumber = Number(roleID);
    
    this.permisoService.ListarPermisosPorRol(roleIDNumber).subscribe({
      next: (response) => {
        this.permisos = response.data;
        this.permisos = [...this.permisos];
      },
      error: (err) => {
        console.error('Error al obtener permisos', err);
      }
    });
  }
  
  onLogout(): void {
    this.permisos = [];

    const userID = localStorage.getItem('UserID')!;
    const userIDNumber = Number(userID);

    const sessionID = localStorage.getItem('SessionID')!;
    const sessionIDNumber = Number(sessionID);

    this.sesionService.FinalizarSesion(sessionIDNumber, userIDNumber).subscribe({
      next: (response) => {
        this.snackBarHelper.showSnackBar("Ha cerrado sesión correctamente.");
      }
    });

    this.authService.logout();
    this.router.navigate(['/iniciar-sesion']);
  }
}
