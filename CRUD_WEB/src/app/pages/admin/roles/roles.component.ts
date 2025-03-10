import { Component, OnInit } from '@angular/core';
import { Breadcrumb, BreadcrumbComponent } from '../../../shared/components/breadcrumb/breadcrumb.component';
import { SearchBarComponent } from '../../../shared/components/search-bar/search-bar.component';
import { ListTableComponent, TableData } from '../../../shared/components/list-table/list-table.component';
import { 
  AddModalData, 
  UpdateModalData,
  DeleteModalData, 
  RolComponentConfig 
} from './roles.component.config';
import { RolService } from '../../services/rol-service';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarHelper } from '../../../shared/functions/snack-bar';
import { ModalAlertComponent } from '../../../shared/components/modal-alert/modal-alert.component';
import { Rol } from '../../../petitions/rol.petition';
import { MaterialModule } from '../../../modules/material.module';

@Component({
  selector: 'app-roles',
  imports: [BreadcrumbComponent, ListTableComponent, SearchBarComponent, MaterialModule],
  templateUrl: './roles.component.html',
  standalone: true,
  styleUrls: [
    './roles.component.css',
    '../../../shared/common/page-basics.css'
  ]
})
export class RolesComponent implements OnInit {

  _rolComponent: any;
  private snackBarHelper: SnackBarHelper;

  constructor(
    private rolService: RolService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {
    this.snackBarHelper = new SnackBarHelper(this.snackBar);
  }

  roles_breadcrumb: Breadcrumb[] = [];

  ngOnInit() {
    this._rolComponent = RolComponentConfig;
    this.roles_breadcrumb = this._rolComponent.componentBreadcrumb;

    this.ListarRoles();
  }

  // > Muestra los roles registrados.
  ListarRoles() {
    this.rolService.ListarRoles().subscribe({
      next: (response) => {
        if (Array.isArray(response.data)) {
          this._rolComponent.tableDatasOriginal = [...response.data];
          this._rolComponent.tableDatas = [...response.data];
        } else {
          this._rolComponent.tableDatasOriginal = [];
          this._rolComponent.tableDatas = [];
        }
      },
      error: (err) => {
        this._rolComponent.tableDatasOriginal = [];
        this._rolComponent.tableDatas = [];
      },
    });
  }

  // > Método para agregar un nuevo rol.
  AgregarRol() {
    const modalData = AddModalData();
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '480px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      var _rol = this.ValidarDatosRol(formData);
      
      if (_rol.EstadoRol != null) {
        this.rolService.AgregarRol(_rol).subscribe({
          next: response => {
            this.ListarRoles();
            this.snackBarHelper.showSnackBar("Se ha registrado correctamente el rol.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de registrar el rol.");
          }
        });
      }
    });
  }

  // > Método para editar un rol.
  ActualizarRol(selectedRol: TableData) {
    const modalData = UpdateModalData(selectedRol);
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '480px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      const _rol = this.ValidarDatosRol(formData);
      _rol.IdRol = selectedRol['idRol']

      if (_rol.NombreRol != null) {
        this.rolService.ActualizarRol(_rol).subscribe({
          next: response => {
            this.ListarRoles();
            this.snackBarHelper.showSnackBar("Se ha actualizado correctamente el rol.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de actualizar el rol.");
          }
        });
      }
    });
  }

  // > Método para eliminar un rol.
  EliminarRol(selectedRol: TableData) {
    const modalData = DeleteModalData(selectedRol);
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '230px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      const _rol = this.ValidarDatosRol(formData);
      _rol.IdRol = selectedRol['idRol']

      if (_rol.IdRol != null) {
        this.rolService.EliminarRol(_rol.IdRol).subscribe({
          next: response => {
            this.ListarRoles();
            this.snackBarHelper.showSnackBar("Se ha eliminado correctamente el rol.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de eliminar el rol.");
          }
        });
      }
    });
  }

  onEdit(rol: TableData) {
    this.ActualizarRol(rol)
  }

  onDelete(rol: TableData) {
    this.EliminarRol(rol)
  }

  // > Retorna datos del formulario en un objeto 'Rol'.
  ValidarDatosRol(datos: any): Rol {
    const _rol: Rol = {
      IdRol: datos.idRol,
      NombreRol: datos.nombreRol,
      DescripcionRol: datos.descripcionRol,
      EstadoRol: datos.estadoRol
    }

    return _rol;
  }

  // > Filtra el término ingresado.
  onSearchTermChanged(term: string) {
    if (!term.trim()) {
      this._rolComponent.tableDatas = [...this._rolComponent.tableDatasOriginal];
      return;
    }

    const searchTerm = term.trim().toLowerCase();

    const filteredData = this._rolComponent.tableDatasOriginal.filter((item: any) =>
      Object.values(item).some((value) => {
        if (value !== null && value !== undefined) {
          return value.toString().toLowerCase().includes(searchTerm);
        }
        return false;
      })
    );

    this._rolComponent.tableDatas = filteredData;
  }
}
