import { Breadcrumb } from "../../../shared/components/breadcrumb/breadcrumb.component";
import { TableAction, TableColumn, TableData } from "../../../shared/components/list-table/list-table.component";
import { ModalAlert, HeaderColor, ModalDataValues } from "../../../shared/components/modal-alert/modal-alert.component";
import { Estados, Generos} from "../../../shared/common/static-data";
import { FormField } from "../../../shared/components/dynamic-form/dynamic-form.component";
import { ParseDate } from "../../../shared/functions/date-hour-converter";

const Persona_Breadcrumb: Breadcrumb[] = [
    { 
        label: 'Dashboard', 
        url: '/administrador' 
    },
    { 
        label: 'Personas registradas', 
        url: '/personas-registradas' 
    },
];

const TableColumns: TableColumn[] = [
    {
        name: 'idPersona', 
        displayName: 'ID'
    },
    {
        name: 'nombresPersona', 
        displayName: 'Nombres'
    },
    {
        name: 'apellidosPersona', 
        displayName: 'Apellidos'
    },
    {
        name: 'identificacion', 
        displayName: 'Identificación'
    },
    {
        name: 'generoDetallado', 
        displayName: 'Género'
    },
    {
        name: 'fechaNacimiento', 
        displayName: 'Fecha de Nacimiento'
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
        name: 'nombresPersona',
        label: 'Nombres',
        type: 'text',
        maxLength: 80,
        required: true,
        value: ''
    },
    { 
        name: 'apellidosPersona',
        label: 'Apellidos',
        type: 'text',
        maxLength: 60,
        required: true,
        value: ''
    },
    { 
        name: 'identificacion',
        label: 'Identificación',
        maxLength: 10, 
        type: 'numeric_text',
        required: true,
        value: ''
    },
    { 
        name: 'genero',
        label: 'Género',
        type: 'select', 
        required: true,
        options: Generos
    },
    { 
        name: 'fechaNacimiento',
        label: 'Fecha de Nacimiento',
        type: 'datepicker',
        required: true 
    },
    { 
        name: 'estadoPersona', 
        label: 'Estado', 
        type: 'select', 
        required: true, 
        options: Estados
    }
]

export function AddModalData() {
    const modalData = ModalDataValues(
        HeaderColor.DarkBlue, 
        'Agregar Persona',
        'person_add_alt_1',
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
        'Actualizar Persona',
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
        modalData.fields = modalData.fields.map((field) => {
          if (field.name === 'fechaNacimiento' && selectedRol[field.name]) {
            const parsedDate = ParseDate(selectedRol[field.name]);
            return {
              ...field,
              value: parsedDate ? parsedDate : ''
            };
          }
          return {
            ...field,
            value: selectedRol[field.name] !== undefined ? selectedRol[field.name] : field.value
          };
        });
      }

    return modalData;
}

export function DeleteModalData(selectedRol: TableData): ModalAlert {
    var personName = selectedRol['nombresPersona']
    var personLastName = selectedRol['apellidosPersona']

    const modalData = ModalDataValues(
        HeaderColor.Red, 
        'Eliminar Persona', 
        'delete',
        [
            { 
                color: HeaderColor.Red, 
                label: 'Eliminar',
                type: 'mat-flat-button' 
            }
        ],
        '¿Está seguro que desea eliminar a la persona "' + personName + ' ' + personLastName + '"?',
        undefined,
        false
    )

    return modalData;
}

export const PersonaComponentConfig = {
    componentBreadcrumb: Persona_Breadcrumb,
    tableColumns: TableColumns,
    tableActions: TableActions,
    tableDatas: TableDatas
}