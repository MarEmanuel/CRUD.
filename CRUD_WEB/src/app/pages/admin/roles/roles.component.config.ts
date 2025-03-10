import { Estados } from "../../../shared/common/static-data";
import { Breadcrumb } from "../../../shared/components/breadcrumb/breadcrumb.component";
import { FormField } from "../../../shared/components/dynamic-form/dynamic-form.component";
import { TableAction, TableColumn, TableData } from "../../../shared/components/list-table/list-table.component";
import { ModalAlert, HeaderColor, ModalDataValues } from "../../../shared/components/modal-alert/modal-alert.component";

const Roles_Breadcrumb: Breadcrumb[] = [
    { 
        label: 'Dashboard', 
        url: '/administrador'
    },
    { 
        label: 'Roles de Usuario', 
        url: '/roles-registrados' 
    },
];

const TableColumns: TableColumn[] = [
    {
        name: 'idRol', 
        displayName: 'ID'
    },
    {
        name: 'nombreRol', 
        displayName: 'Rol'
    },
    {
        name: 'descripcionRol', 
        displayName: 'Descripción'
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
        name: 'nombreRol',
        label: 'Nombre del Rol',
        type: 'text',
        maxLength: 50,
        required: true,
        value: ''
    },
    { 
        name: 'descripcionRol',
        label: 'Descripción del Rol',
        type: 'text',
        maxLength: 100,
        required: true,
        value: ''
    },
    { 
        name: 'estadoRol', 
        label: 'Estado del Rol', 
        type: 'select', 
        required: true, 
        options: Estados
    }
]

export function AddModalData() {
    const modalData = ModalDataValues(
        HeaderColor.DarkBlue, 
        'Agregar Rol',
        'add_circle',
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

export function UpdateModalData(selectedRol: TableData): ModalAlert {
    const modalData = ModalDataValues(
        HeaderColor.Blue,
        'Actualizar Rol',
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
            value: selectedRol[field.name] !== undefined ? selectedRol[field.name] : field.value
        }));
    }

    return modalData;
}

export function DeleteModalData(selectedRol: TableData): ModalAlert {
    var rolName = selectedRol['nombreRol']

    const modalData = ModalDataValues(
        HeaderColor.Red, 
        'Eliminar Rol', 
        'delete',
        [
            { 
                color: HeaderColor.Red, 
                label: 'Eliminar',
                type: 'mat-flat-button' 
            }
        ],
        '¿Está seguro que desea eliminar el rol "' + rolName + '"?',
        undefined,
        false
    )

    return modalData;
}

export const RolComponentConfig = {
    componentBreadcrumb: Roles_Breadcrumb,
    tableColumns: TableColumns,
    tableActions: TableActions,
    tableDatas: TableDatas
}