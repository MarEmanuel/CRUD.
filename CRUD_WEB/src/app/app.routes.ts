import { Routes } from '@angular/router';
import { PersonasComponent } from './pages/admin/personas/personas.component';
import { RolesComponent } from './pages/admin/roles/roles.component';
import { UserComponent } from './pages/single-user/user/user.component';
import { UsersComponent } from './pages/admin/users/users.component';
import { LoginComponent } from './pages/general/login/login.component';
import { DashboardComponent } from './pages/admin/dashboard/dashboard.component';
import { AuthGuard } from './auth.guard';
import { AdminGuard } from './admin.guard';

export const routes: Routes = [
    { path: "", redirectTo: "mi-usuario", pathMatch: "full" },
    { path: "mi-usuario", component: UserComponent, canActivate: [AuthGuard] },
    { path: "iniciar-sesion", component: LoginComponent },
    {
        path: "administrador",
        canActivate: [AuthGuard, AdminGuard],
        children: [
            { path: "", redirectTo: "dashboard", pathMatch: "full" },
            { path: "dashboard", component: DashboardComponent, canActivate: [AuthGuard] },
            { path: "usuarios-registrados", component: UsersComponent, canActivate: [AuthGuard] },
            { path: "personas-registradas", component: PersonasComponent, canActivate: [AuthGuard] },
            { path: "roles-registrados", component: RolesComponent, canActivate: [AuthGuard] },
        ]
    },
    { path: "**", redirectTo: "mi-usuario", pathMatch: "full" }
];