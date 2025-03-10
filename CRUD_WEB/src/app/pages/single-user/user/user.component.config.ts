import { Estados, Generos } from "../../../shared/common/static-data";
import { FormField, ButtonDesign } from "../../../shared/components/dynamic-form/dynamic-form.component";
import { TableColumn, TableData } from "../../../shared/components/list-table/list-table.component";
import { HeaderColor, ModalAlert, ModalDataValues } from "../../../shared/components/modal-alert/modal-alert.component";

const TableColumns: TableColumn[] = [
    {
        name: 'idSesion',
        displayName: 'ID'
    },
    {
        name: 'fechaIngreso',
        displayName: 'Fecha de Ingreso'
    },
    {
        name: 'fechaEgreso',
        displayName: 'Fecha de Egreso'
    },
    {
        name: 'sesionActiva',
        displayName: 'Estado de la sesión'
    }
]

const TableDatas: TableData[] = [];

const PersonFormFields: FormField[] = [
    { 
        name: 'NombresPersona',
        label: 'Nombres',
        type: 'text',
        maxLength: 80,
        required: true,
        value: ''
    },
    { 
        name: 'ApellidosPersona',
        label: 'Apellidos',
        type: 'text',
        maxLength: 60,
        required: true,
        value: ''
    },
    { 
        name: 'Identificacion',
        label: 'Identificación',
        maxLength: 10, 
        type: 'numeric_text',
        required: true,
        value: ''
    },
    { 
        name: 'Genero',
        label: 'Género',
        type: 'select', 
        required: true,
        options: Generos
    },
    { 
        name: 'FechaNacimiento',
        label: 'Fecha de Nacimiento',
        type: 'datepicker',
        required: true 
    },
    { 
        name: 'EstadoPersona', 
        label: 'Estado', 
        type: 'select', 
        required: true, 
        options: Estados
    }
]

export function PersonModalData(
    color: HeaderColor,
    title: string, 
    icon: string, 
    person: TableData,
    buttons?: ButtonDesign[]
): ModalAlert {
    const modalData = ModalDataValues(
        color,
        title,
        icon,
        buttons,
        undefined,
        PersonFormFields,
        false
    );

    if (modalData.fields) {
        modalData.fields = modalData.fields.map((field) => ({
            ...field,
            value: person[field.name] !== undefined ? person[field.name] : field.value
        }));
    }

    return modalData;
}

export const UserComponentConfig = {
    personFormFields: PersonFormFields,
    tableColumns: TableColumns,
    tableDatas: TableDatas
}