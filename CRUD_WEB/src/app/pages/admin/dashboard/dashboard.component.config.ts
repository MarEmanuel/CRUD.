import { TableColumn, TableData } from "../../../shared/components/list-table/list-table.component";

const TableColumns: TableColumn[] = [
    {
        name: 'idSesion',
        displayName: 'ID'
    },
    {
        name: 'nombresPersona',
        displayName: 'Nombre del Usuario'
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

export const DashboardComponentConfig = {
    tableColumns: TableColumns,
    tableDatas: TableDatas
}