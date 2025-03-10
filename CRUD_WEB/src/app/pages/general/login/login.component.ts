import { Component } from '@angular/core';
import { FormField, DynamicFormComponent, ButtonDesign } from '../../../shared/components/dynamic-form/dynamic-form.component';
import { MaterialModule } from '../../../modules/material.module';
import { LoginComponentConfig } from './login.component.config';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarHelper } from '../../../shared/functions/snack-bar';
import { PersonaService } from '../../services/persona-service';
import { Persona } from '../../../petitions/persona.petition';
import { Usuario } from '../../../petitions/usuario.petition';
import { LoginService } from '../../services/login-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [DynamicFormComponent, MaterialModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  private snackBarHelper: SnackBarHelper;
  _loginConfiguration: any;
  loginFields: FormField[] = [];
  loginButtons: ButtonDesign[] = [];
  registerFields: FormField[] = [];
  registerButtons: ButtonDesign[] = [];

  constructor(
    private personaService: PersonaService,
    private loginService: LoginService,
    private router: Router,
    private snackBar: MatSnackBar) {
    this.snackBarHelper = new SnackBarHelper(this.snackBar);
  }

  ngOnInit() {
    this._loginConfiguration = LoginComponentConfig;
    this.loginFields = LoginComponentConfig.loginDataFields;
    this.loginButtons = LoginComponentConfig.loginDataButtons;
    this.registerFields = LoginComponentConfig.registerDataFields;
    this.registerButtons = LoginComponentConfig.registerDataButtons;
  }

  IniciarSesion(data: any) {
    if (data.nombre_usuario != null && data.contrasenia_usuario != null) {
      
      this.loginService.IniciarSesion(data.nombre_usuario, data.contrasenia_usuario).subscribe({
        next: response => {

          localStorage.setItem('UserID', response.data[0].userID);
          localStorage.setItem('RoleID', response.data[0].roleID);
          localStorage.setItem('RoleName', response.data[0].roleName);
          localStorage.setItem('SessionID', response.data[0].sessionID);

          this.snackBarHelper.showSnackBar("Se ha iniciado sesión correctamente.");
          
          this.router.navigate(['/mi-usuario']);
        },
        error: err => {
          this.snackBarHelper.showSnackBar("Hubo un error al momento de iniciar sesión.");
        }
      });
    } else {
      this.snackBarHelper.showSnackBar("Por favor ingrese ambos campos.");
    }
  }

  AgregarRegistro(data: any) {
    let validacionesCorrectas = true;

    if (data.nombres_persona != null) {
      if (this.ValidarIdentificacion(data.identificacion_persona) !== null) {
        validacionesCorrectas = false;
      }
      if (this.ValidarNombreUsuario(data.nombre_registro) !== null) {
        validacionesCorrectas = false;
      }
      if (this.ValidarContrasena(data.contrasenia_registro) !== null) {
        validacionesCorrectas = false;
      }

      if (validacionesCorrectas) {
        var correo_usuario = this.GenerarCorreo(data.nombres_persona, data.apellidos_persona);

        var _persona = this.ValidarDatosPersona(data);
        _persona.Mail = correo_usuario;

        this.loginService.RegistrarNuevoUsuario(_persona).subscribe({
          next: response => {
            this.snackBarHelper.showSnackBar("Se ha registrado correctamente a la persona.");
          },
          error: err => {
            this.snackBarHelper.showSnackBar("Hubo un error al momento de registrar a la persona.");
          }
        });
      }
    }
  }

  ValidarNombreUsuario(nombreUsuario: string): string | null {
    // > No contener signos.
    const regexSinSignos = /^[a-zA-Z0-9_]+$/;
    if (!regexSinSignos.test(nombreUsuario)) {
      this.snackBarHelper.showSnackBar("El nombre de usuario no debe contener signos.");
      return "El nombre de usuario no debe contener signos.";
    }

    // > Al menos un número
    const regexNumero = /[0-9]/;
    if (!regexNumero.test(nombreUsuario)) {
      this.snackBarHelper.showSnackBar("El nombre de usuario debe contener al menos un número.");
      return "El nombre de usuario debe contener al menos un número.";
    }

    // > Al menos una letra mayúscula
    const regexMayuscula = /[A-Z]/;
    if (!regexMayuscula.test(nombreUsuario)) {
      this.snackBarHelper.showSnackBar("El nombre de usuario debe contener al menos una letra mayúscula.");
      return "El nombre de usuario debe contener al menos una letra mayúscula.";
    }

    // > Longitud máxima de 20 y mínima de 8
    if (nombreUsuario.length < 8 || nombreUsuario.length > 20) {
      this.snackBarHelper.showSnackBar("El nombre de usuario debe tener entre 8 y 20 caracteres.");
      return "El nombre de usuario debe tener entre 8 y 20 caracteres.";
    }

    return null;
  }

  ValidarContrasena(contrasena: string): string | null {
    // > Debe tener al menos 8 dígitos
    if (contrasena.length < 8) {
      this.snackBarHelper.showSnackBar("La contraseña debe tener al menos 8 caracteres.");
      return "La contraseña debe tener al menos 8 caracteres.";
    }

    // > Debe tener al menos una letra mayúscula
    const regexMayuscula = /[A-Z]/;
    if (!regexMayuscula.test(contrasena)) {
      this.snackBarHelper.showSnackBar("La contraseña debe contener al menos una letra mayúscula.");
      return "La contraseña debe contener al menos una letra mayúscula.";
    }

    // > No debe contener espacios
    if (/\s/.test(contrasena)) {
      this.snackBarHelper.showSnackBar("La contraseña no debe contener espacios.");
      return "La contraseña no debe contener espacios.";
    }

    // > Debe tener al menos un signo
    const regexSigno = /[!@#$%^&*(),.?":{}|<>]/;
    if (!regexSigno.test(contrasena)) {
      this.snackBarHelper.showSnackBar("La contraseña debe contener al menos un signo especial.");
      return "La contraseña debe contener al menos un signo especial.";
    }
    return null;
  }

  ValidarIdentificacion(identificacion: string): string | null {
    // > Debe tener 10 dígitos
    if (identificacion.length !== 10) {
      this.snackBarHelper.showSnackBar("La identificación debe tener exactamente 10 dígitos.");
      return "La identificación debe tener exactamente 10 dígitos.";
    }

    // > Solo números
    const regexSoloNumeros = /^\d+$/;
    if (!regexSoloNumeros.test(identificacion)) {
      this.snackBarHelper.showSnackBar("La identificación debe contener solo números.");
      return "La identificación debe contener solo números.";
    }

    // > Validar que no tenga 4 números seguidos repetidos
    const regexCuatroRepetidos = /(\d)\1{3}/;
    if (regexCuatroRepetidos.test(identificacion)) {
      this.snackBarHelper.showSnackBar("La identificación no debe contener un mismo número repetido 4 veces consecutivas.");
      return "La identificación no debe contener un mismo número repetido 4 veces consecutivas.";
    }
    return null;
  }

  GenerarCorreo(_nombre: string, _apellido: string): string {
    const nombre = _nombre.split(" ")[0];
    const apellidos = _apellido.split(" ");
    const primerApellido = apellidos[0];
    const correo = `${nombre.charAt(0).toLowerCase()}${primerApellido.toLowerCase()}@mail.com`;

    return correo;
  }

  // > Retorna datos del formulario en un objeto 'Persona & Usuario'.
  ValidarDatosPersona(datos: any): Persona & Usuario {

    const _persona: Persona & Usuario = {
      NombresPersona: datos.nombres_persona,
      ApellidosPersona: datos.apellidos_persona,
      Identificacion: datos.identificacion_persona,
      Genero: datos.genero_persona,
      FechaNacimiento: datos.fecnac_persona,
      EstadoPersona: 'A',
      Mail: datos.nombres_persona,
      Username: datos.nombre_registro,
      Password: datos.contrasenia_registro
    }

    return _persona;
  }
}

