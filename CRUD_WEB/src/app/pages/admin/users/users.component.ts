import { Component, OnInit } from '@angular/core';
import { Breadcrumb, BreadcrumbComponent } from '../../../shared/components/breadcrumb/breadcrumb.component';
import { SearchBarComponent } from '../../../shared/components/search-bar/search-bar.component';
import { ListTableComponent, TableData } from '../../../shared/components/list-table/list-table.component';
import {
  AddModalData,
  DeleteModalData,
  UpdateModalData,
  UsersComponentConfig
} from './users.component.config';
import { UsersService } from '../../services/users-service';
import { SnackBarHelper } from '../../../shared/functions/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ModalAlertComponent } from '../../../shared/components/modal-alert/modal-alert.component';
import { Usuario } from '../../../petitions/usuario.petition';
import { MaterialModule } from '../../../modules/material.module';
import { PersonaService } from '../../services/persona-service';
import { RolService } from '../../services/rol-service';

@Component({
  selector: 'app-users',
  imports: [BreadcrumbComponent, ListTableComponent, SearchBarComponent, MaterialModule],
  templateUrl: './users.component.html',
  standalone: true,
  styleUrls: [
    './users.component.css',
    '../../../shared/common/page-basics.css'
  ]
})
export class UsersComponent implements OnInit {

  _usersComponent: any;
  private snackBarHelper: SnackBarHelper;

  constructor(
    private userService: UsersService,
    private personaService: PersonaService,
    private rolService: RolService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {
    this.snackBarHelper = new SnackBarHelper(this.snackBar);
  }

  users_breadcrumb: Breadcrumb[] = [];

  ngOnInit() {
    this._usersComponent = UsersComponentConfig;
    this.users_breadcrumb = this._usersComponent.componentBreadcrumb;
    this.ObtenerPersonas();
    this.ObtenerRoles();
    this.ListarUsuarios();
  }

  // > Muestra los usuarios registrados.
  ListarUsuarios() {
    this.userService.ListarUsuarios().subscribe({
      next: (response) => {
        const roles = Array.isArray(response.data) ? [...response.data] : [];
        this._usersComponent.tableDatas = roles;
        this._usersComponent.tableDatasOriginal = roles;
      },
      error: (err) => {
        this._usersComponent.tableDatas = [];
        this._usersComponent.tableDatasOriginal = [];
      },
    });
  }

  // > Método para agregar un nuevo usuario.
  AgregarUsuario() {
    const modalData = AddModalData();
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '700px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      var _user = this.ValidarDatosUsuario(formData);

      console.log(_user)

      if (_user.Username != undefined) {
        this.userService.AgregarUsuario(_user).subscribe({
          next: response => {
            this.ListarUsuarios();
            this.snackBarHelper.showSnackBar("Se ha registrado correctamente el usuario.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de registrar el usuario.");
          }
        });
      }
    });
  }

  // > Método para editar un usuario.
  ActualizarUsuario(selectedUser: TableData) {
    const modalData = UpdateModalData(selectedUser);
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '480px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      const _user = this.ValidarDatosUsuario(formData);
      _user.idUsuario = selectedUser['idUsuario']

      if (_user.Username != null) {
        this.userService.ActualizarUsuario(_user).subscribe({
          next: response => {
            this.ListarUsuarios();
            this.snackBarHelper.showSnackBar("Se ha actualizado correctamente el usuario.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de actualizar el usuario.");
          }
        });
      }
    });
  }

  // > Método para eliminar un usuario.
  EliminarUsuario(selectedUser: TableData) {
    const modalData = DeleteModalData(selectedUser);
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '250px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      const _user = this.ValidarDatosUsuario(formData);
      _user.idUsuario = selectedUser['idUsuario']
      
      if (_user.idUsuario != null) {
        this.userService.EliminarUsuario(_user).subscribe({
          next: response => {
            this.ListarUsuarios();
            this.snackBarHelper.showSnackBar("Se ha eliminado correctamente el usuario.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de eliminar el usuario.");
          }
        });
      }
    });
  }

  onEdit(user: TableData) {
    this.ActualizarUsuario(user)
  }

  onDelete(user: TableData) {
    this.EliminarUsuario(user)
  }

  // SearchBox filtrando información en base al texto ingresado.
  onSearchTermChanged(term: string) {
    const filteredData = this._usersComponent.tableDatasOriginal.filter((item: any) =>
      Object.values(item).some((value) =>
        value?.toString().toLowerCase().includes(term.trim().toLowerCase())
      )
    );

    this._usersComponent.tableDatas = filteredData;
  }

  // > Retorna datos del formulario en un objeto 'Usuario'.
  ValidarDatosUsuario(datos: any): Usuario {
    const _user: Usuario = {
      idUsuario: datos.idUsuario,
      Username: datos.username,
      Password: datos.contraseniaUsuario,
      Mail: datos.mail,
      idPersona: datos.personaCuenta,
      EstadoUsuario: datos.estadoUsuario
    }

    return _user;
  }

  // > Obtiene el nombre de las personas registradas para guardarlas en el registro de 'Usuario'.
  ObtenerPersonas(): void {
    this.personaService.ListarPersonasSeleccionadas().subscribe(
      (response: any) => {
        if (Array.isArray(response.data)) {
          const personaCuentaField = this._usersComponent.dataFields.find(
            (field: { name: string }) => field.name === 'personaCuenta'
          );
          if (personaCuentaField) {
            personaCuentaField.options = response.data.map(
              (item: { string_value: any; id_value: any }) => ({
                label: item.string_value,
                value: item.id_value,
              })
            );
          } else {
            console.warn('El campo "personaCuenta" no fue encontrado en DataFields');
          }
        } else {
          console.error('La propiedad "data" no es un array:', response.data);
        }
      },
      (error) => {
        console.error('Error al obtener las personas seleccionadas:', error);
      }
    );
  }

  // > Obtiene el nombre de los roles registrados para guardarlas en el registro de 'Usuario'.
  ObtenerRoles(): void {
    this.rolService.ListarRolesSeleccionados().subscribe(
      (response: any) => {
        if (Array.isArray(response.data)) {
          const rolDeseadoField = this._usersComponent.dataFields.find(
            (field: { name: string }) => field.name === 'rolDeseado'
          );
          if (rolDeseadoField) {
            rolDeseadoField.options = response.data.map(
              (item: { string_value: any; id_value: any }) => ({
                label: item.string_value,
                value: item.id_value,
              })
            );
          } else {
            console.warn('El campo "rolDeseadoField" no fue encontrado en DataFields');
          }
        } else {
          console.error('La propiedad "data" no es un array:', response.data);
        }
      },
      (error) => {
        console.error('Error al obtener las personas seleccionadas:', error);
      }
    );
  }
}
