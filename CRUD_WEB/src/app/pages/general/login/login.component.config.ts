import { Generos } from "../../../shared/common/static-data";
import { ButtonDesign, FormField } from "../../../shared/components/dynamic-form/dynamic-form.component";
import { HeaderColor } from "../../../shared/components/modal-alert/modal-alert.component";

const LoginDataFields: FormField[] = [
    {
        name: 'nombre_usuario',
        label: 'Usuario',
        type: 'text',
        maxLength: 50,
        required: true,
        value: ''
    },
    {
        name: 'contrasenia_usuario',
        label: 'Contraseña',
        type: 'password',
        maxLength: 20,
        required: true,
        value: ''
    }
]

const LoginDataButtons: ButtonDesign[] = [
    {
        color: HeaderColor.Blue,
        label: 'Iniciar Sesión',
        type: 'mat-flat-button'
    }
]

const RegisterDataFields: FormField[] = [
    {
        name: 'nombres_persona',
        label: 'Nombres',
        type: 'text',
        maxLength: 80,
        required: true,
        value: ''
    },
    {
        name: 'apellidos_persona',
        label: 'Apellidos',
        type: 'text',
        maxLength: 60,
        required: true,
        value: ''
    },
    {
        name: 'identificacion_persona',
        label: 'Identificación',
        type: 'numeric_text',
        maxLength: 10,
        required: true,
        value: ''
    },
    {
        name: 'genero_persona',
        label: 'Género',
        type: 'select',
        required: true,
        options: Generos
    },
    {
        name: 'fecnac_persona',
        label: 'Fecha de Nacimiento',
        type: 'datepicker',
        required: true
    },
    {
        name: 'nombre_registro',
        label: 'Usuario',
        type: 'text',
        maxLength: 20,
        required: true,
        value: ''
    },
    {
        name: 'contrasenia_registro',
        label: 'Contraseña',
        type: 'password',
        maxLength: 20,
        required: true,
        value: ''
    }
]

const RegisterDataButtons: ButtonDesign[] = [
    {
        color: HeaderColor.Blue,
        label: 'Registrarse',
        type: 'mat-flat-button'
    }
]


export const LoginComponentConfig = {
    loginDataFields: LoginDataFields,
    loginDataButtons: LoginDataButtons,
    registerDataFields: RegisterDataFields,
    registerDataButtons: RegisterDataButtons
}