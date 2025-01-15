import { Routes } from '@angular/router';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { RolesComponent } from './pages/admin/roles/roles.component';
import { UsersComponent } from './pages/admin/roles/users/users.component';
import { UserComponent } from './pages/user/user.component';

export const routes: Routes = [
    { path: "", redirectTo: "inicio", pathMatch: "full" },
    { path: "inicio", component: WelcomeComponent },
    { path: "mi-usuario", component: UserComponent },
    {
        path: "administrador",
        children: [
            { path: "", redirectTo: "usuarios-registrados", pathMatch: "full" },
            { path: "roles-usuario", component: RolesComponent },
            { path: "usuarios-registrados", component: UsersComponent }
        ]
    },
    {path:"**", redirectTo: ""}
];
