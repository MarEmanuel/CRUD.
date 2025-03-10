import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../../../modules/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormField } from '../../../shared/components/dynamic-form/dynamic-form.component';
import { UserComponentConfig, PersonModalData } from './user.component.config';
import { CommonModule } from '@angular/common';
import { HeaderColor, ModalAlertComponent } from '../../../shared/components/modal-alert/modal-alert.component';
import { ConvertDateTime } from '../../../shared/functions/date-hour-converter';
import { MatDialog } from '@angular/material/dialog';
import { PersonaService } from '../../services/persona-service';
import { UsersService } from '../../services/users-service';
import { ApiResponse } from '../../../petitions/api-response';
import { Persona } from '../../../petitions/persona.petition';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarHelper } from '../../../shared/functions/snack-bar';
import { take } from 'rxjs';
import { Usuario } from '../../../petitions/usuario.petition';
import { ListTableComponent } from '../../../shared/components/list-table/list-table.component';
import { SesionService } from '../../services/sesion-service';

@Component({
  selector: 'app-user',
  imports: [MaterialModule, FormsModule, ListTableComponent, ReactiveFormsModule, CommonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {

  _userComponent: any;
  rolCuenta: string = "";
  private snackBarHelper: SnackBarHelper;
  personFormFields: FormField[] = [];
  userFormFields: FormField[] = [];
  persona: Persona[] = [];
  usuario: Usuario[] = [];

  constructor(
    public dialog: MatDialog,
    private personaService: PersonaService,
    private userService: UsersService,
    private sesionService: SesionService,
    private snackBar: MatSnackBar,
  ) {
    this.snackBarHelper = new SnackBarHelper(this.snackBar);
  }

  ngOnInit(): void {
    this._userComponent = UserComponentConfig
    this.personFormFields = this._userComponent.personFormFields
    this.userFormFields = this._userComponent.userFormFields
    this.ObtenerPersonaSesion();
    this.ObtenerUsuarioSesion();
    this.ObtenerDatosSesion();
  }

  ObtenerDatosSesion() {
    const userID = localStorage.getItem('UserID')!;
    const userIDNumber = Number(userID);

    const roleName = localStorage.getItem('RoleName')!;
    this.rolCuenta = roleName;

    this.sesionService.ListarSesionesPorID(userIDNumber).subscribe({
      next: (response) => {
        const sessions = Array.isArray(response.data) ? [...response.data] : [];
        sessions.forEach(session => {
          session.fechaIngreso = ConvertDateTime(session.fechaIngreso);
          if (session.fechaEgreso === null) {
            session.fechaEgreso = "Sesión se mantiene activa";
          } else {
            session.fechaEgreso = ConvertDateTime(session.fechaEgreso);
          }
        });

        this._userComponent.tableDatas = sessions;
        this._userComponent.tableDatasOriginal = sessions;
      },
      error: (err) => {
        this._userComponent.tableDatas = [];
        this._userComponent.tableDatasOriginal = [];
      }
    });
  }

  ObtenerPersonaSesion() {
    const userID = localStorage.getItem('UserID')!;
    const userIDNumber = Number(userID);

    this.personaService.ListarPersonasPorID(userIDNumber).subscribe({
      next: (response: ApiResponse) => {
        if (response.isSuccess && response.data.length > 0) {
          this.persona = response.data.map((item: any) => this.PersonaMapping(item));
        } else {
          console.error('No se encontraron datos de personas:', response.message);
        }
      },
      error: (error) => {
        console.error('Error al obtener los datos de personas:', error);
      },
    });
  }

  ObtenerUsuarioSesion() {
    const userID = localStorage.getItem('UserID')!;
    const userIDNumber = Number(userID);

    this.userService.ListarUsuarioPorID(userIDNumber).subscribe({
      next: (response: ApiResponse) => {
        if (response.isSuccess && response.data.length > 0) {
          this.usuario = response.data.map((item: any) => this.UserMapping(item));
        } else {
          console.error('No se encontraron datos de usuarios:', response.message);
        }
      },
      error: (error) => {
        console.error('Error al obtener los datos del usuario:', error);
      },
    });
  }

  VisualizarPersona() {
    const modalData = PersonModalData(
      HeaderColor.DarkBlue,
      'Visualizar datos: Mi Persona',
      'visibility',
      this.persona[0]
    );

    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '480px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });
  }

  EditarPersona() {
    const modalData = PersonModalData(
      HeaderColor.Blue,
      'Editar datos: Mi Persona',
      'edit',
      this.persona[0],
      [
        {
          color: HeaderColor.Blue,
          label: 'Actualizar',
          type: 'mat-flat-button'
        }
      ]
    );

    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '480px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.pipe(
      take(1)
    ).subscribe((formData: any) => {
      const _persona = { ...this.persona[0], ...formData };

      this.personaService.ActualizarPersona(_persona).subscribe({
        next: response => {
          this.snackBarHelper.showSnackBar("Se ha actualizado correctamente la persona.");
          this.ObtenerPersonaSesion();
        },
        error: err => {
          console.log(err);
          this.snackBarHelper.showSnackBar("Hubo un error al momento de actualizar la persona.");
        }
      });
    });
  }

  PersonaMapping(data: any): Persona {
    return {
      IdPersona: data.idPersona,
      NombresPersona: data.nombresPersona,
      ApellidosPersona: data.apellidosPersona,
      Identificacion: data.identificacion,
      Genero: data.genero,
      FechaNacimiento: data.fechaNacimiento,
      EstadoPersona: data.estadoPersona
    };
  }

  UserMapping(data: any): Usuario {
    return {
      idUsuario: data.idUsuario,
      Username: data.username,
      Mail: data.mail,
      idPersona: data.idPersona,
      NombrePersona: data.nombrePersona,
      EstadoUsuario: data.estadoUsuario
    };
  }
}
