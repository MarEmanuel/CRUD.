import { Estados } from "../../../shared/common/static-data";
import { Breadcrumb } from "../../../shared/components/breadcrumb/breadcrumb.component";
import { FormField } from "../../../shared/components/dynamic-form/dynamic-form.component";
import { TableAction, TableColumn, TableData } from "../../../shared/components/list-table/list-table.component";
import { ModalAlert, HeaderColor, ModalDataValues } from "../../../shared/components/modal-alert/modal-alert.component";

const Users_Breadcrumb: Breadcrumb[] = [
    {
        label: 'Dashboard', 
        url: '/administrador' 
    },
    {
        label: 'Usuarios registrados',
        url: '/usuarios-registrados'
    },
];

const TableColumns: TableColumn[] = [
    {
        name: 'idUsuario',
        displayName: 'ID'
    },
    {
        name: 'username',
        displayName: 'Usuario'
    },
    {
        name: 'nombrePersona',
        displayName: 'Persona'
    },
    {
        name: 'nombreRol',
        displayName: 'Rol'
    },
    {
        name: 'estadoDetallado',
        displayName: 'Estado'
    }
]

const TableDatas: TableData[] = [];

const TableActions: TableAction[] = [
    {
        name: 'edit',
        label: 'Editar',
        visible: true,
        color: 'royalblue',
        icon: 'edit'
    },
    {
        name: 'delete',
        label: 'Eliminar',
        visible: true,
        color: 'maroon',
        icon: 'delete'
    }
];

const DataFields: FormField[] = [
    {
        name: 'username',
        label: 'Nombre de Usuario',
        type: 'text',
        maxLength: 50,
        required: true
    },
    {
        name: 'contraseniaUsuario',
        label: 'Contraseña de cuenta',
        type: 'password',
        maxLength: 100,
        required: true
    },
    {
        name: 'mail',
        label: 'Correo de cuenta',
        type: 'email',
        required: true,
    },
    {
        name: 'rolDeseado',
        label: 'Rol del usuario',
        type: 'select',
        required: true,
        options: []
    },
    {
        name: 'personaCuenta',
        label: 'Persona a la que pertenece la cuenta',
        type: 'select',
        required: true,
        options: []
    },
    {
        name: 'estadoUsuario',
        label: 'Estado de la cuenta',
        type: 'select',
        required: true,
        options: Estados
    }
]

export function AddModalData() {
    const modalData = ModalDataValues(
        HeaderColor.DarkBlue,
        'Agregar Usuario',
        'person_add',
        [
            {
                color: HeaderColor.DarkBlue,
                label: 'Guardar',
                type: 'mat-flat-button'
            }
        ],
        undefined,
        DataFields,
        false
    )

    return modalData;
}

export function UpdateModalData(selectedUser: TableData): ModalAlert {
    const modalData = ModalDataValues(
        HeaderColor.Blue,
        'Actualizar Usuario',
        'edit',
        [
            { 
                color: HeaderColor.Blue, 
                label: 'Actualizar',
                type: 'mat-flat-button' 
            }
        ],
        undefined,
        DataFields,
        false
    );

    if (modalData.fields) {
        modalData.fields = modalData.fields.map((field) => ({
            ...field,
            value: selectedUser[field.name] !== undefined ? selectedUser[field.name] : field.value
        }));
    }

    return modalData;
}

export function DeleteModalData(selectedUser: TableData): ModalAlert {
    var userName = selectedUser['nombrePersona']
    var userUser = selectedUser['username']

    const modalData = ModalDataValues(
        HeaderColor.Red, 
        'Eliminar Usuario', 
        'delete',
        [
            { 
                color: HeaderColor.Red, 
                label: 'Eliminar',
                type: 'mat-flat-button' 
            }
        ],
        '¿Está seguro que desea eliminar el usuario "' + userUser + '" pertenciente a "' + userName + '"?',
        undefined,
        false
    )

    return modalData;
}

export const UsersComponentConfig = {
    componentBreadcrumb: Users_Breadcrumb,
    tableColumns: TableColumns,
    tableActions: TableActions,
    tableDatas: TableDatas,
    dataFields: DataFields
}