import { Component, OnInit } from '@angular/core';
import { Breadcrumb, BreadcrumbComponent } from '../../../shared/components/breadcrumb/breadcrumb.component';
import { SearchBarComponent } from '../../../shared/components/search-bar/search-bar.component';
import { ListTableComponent, TableData } from '../../../shared/components/list-table/list-table.component';
import { PersonaService } from '../../services/persona-service';
import { AddModalData, DeleteModalData, PersonaComponentConfig, UpdateModalData } from './personas.component.config';
import { ConvertDate } from '../../../shared/functions/date-hour-converter';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarHelper } from '../../../shared/functions/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ModalAlertComponent } from '../../../shared/components/modal-alert/modal-alert.component';
import { Persona } from '../../../petitions/persona.petition';
import { MaterialModule } from '../../../modules/material.module';

@Component({
  selector: 'app-personas',
  imports: [BreadcrumbComponent, ListTableComponent, SearchBarComponent, MaterialModule],
  templateUrl: './personas.component.html',
  standalone: true,
  styleUrls: [
    './personas.component.css',
    '../../../shared/common/page-basics.css'
  ]
})
export class PersonasComponent implements OnInit {

  _personaComponent: any;
  private snackBarHelper: SnackBarHelper;

  constructor(
    private personaService: PersonaService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog
  ) {
    this.snackBarHelper = new SnackBarHelper(this.snackBar);
  }

  personas_breadcrumb: Breadcrumb[] = [];

  ngOnInit() {
    this._personaComponent = PersonaComponentConfig;
    this.personas_breadcrumb = this._personaComponent.componentBreadcrumb;

    this.ListarPersonas();
  }

  // > Muestra las personas registradas.
  ListarPersonas() {
    this.personaService.ListarPersonas().subscribe({
      next: (response) => {
        if (Array.isArray(response.data)) {
          const personas = response.data.map((item: { fechaNacimiento: string }) => {
            if (item.fechaNacimiento) {
              item.fechaNacimiento = ConvertDate(item.fechaNacimiento);
            }
            return item;
          });

          this._personaComponent.tableDatasOriginal = [...personas];
          this._personaComponent.tableDatas = [...personas];
        }
        else {
          this._personaComponent.tableDatasOriginal = [];
          this._personaComponent.tableDatas = [];
        }
      },
      error: (err) => {
        this._personaComponent.tableDatasOriginal = [];
        this._personaComponent.tableDatas = [];
      },
    });
  }

  // > Método para agregar una nueva persona.
  AgregarPersona() {
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
      var _persona = this.ValidarDatosPersona(formData);

      if (_persona.EstadoPersona != null) {
        this.personaService.AgregarPersona(_persona).subscribe({
          next: response => {
            this.ListarPersonas();
            this.snackBarHelper.showSnackBar("Se ha registrado correctamente a la persona.");
          },
          error: err => {
            this.snackBarHelper.showSnackBar("Hubo un error al momento de registrar a la persona.");
          }
        });
      }
    });
  }
  
  // > Método para editar una persona.
  ActualizarPersona(selectedPerson: TableData) {
    const modalData = UpdateModalData(selectedPerson);
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '480px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      const _persona = this.ValidarDatosPersona(formData);
      _persona.IdPersona = selectedPerson['idPersona']

      if (_persona.NombresPersona != undefined) {
        this.personaService.ActualizarPersona(_persona).subscribe({
          next: response => {
            this.ListarPersonas();
            this.snackBarHelper.showSnackBar("Se ha actualizado correctamente la persona.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de actualizar la persona.");
          }
        });
      }
    });
  }

  // > Método para eliminar una persona.
  EliminarPersona(selectedPerson: TableData) {
    const modalData = DeleteModalData(selectedPerson);
    const dialogRef = this.dialog.open(ModalAlertComponent, {
      data: modalData,
      width: '700px',
      height: '230px',
      maxWidth: '90vw',
      maxHeight: '80vh',
      disableClose: true
    });

    dialogRef.componentInstance.submit.subscribe((formData: any) => {
      const _persona = this.ValidarDatosPersona(formData);
      _persona.IdPersona = selectedPerson['idPersona']

      if (_persona.IdPersona != null) {
        this.personaService.EliminarPersona(_persona.IdPersona).subscribe({
          next: response => {
            this.ListarPersonas();
            this.snackBarHelper.showSnackBar("Se ha eliminado correctamente la persona.");
          },
          error: err => {
            console.log(err);
            this.snackBarHelper.showSnackBar("Hubo un error al momento de eliminar la persona.");
          }
        });
      }
    });
  }

  onEdit(persona: TableData) {
    this.ActualizarPersona(persona)
  }

  onDelete(persona: TableData) {
    this.EliminarPersona(persona)
  }

  // > Retorna datos del formulario en un objeto 'Persona'.
  ValidarDatosPersona(datos: any): Persona {

    const _persona: Persona = {
      IdPersona: datos.idPersona,
      NombresPersona: datos.nombresPersona,
      ApellidosPersona: datos.apellidosPersona,
      Identificacion: datos.identificacion,
      Genero: datos.genero,
      FechaNacimiento: datos.fechaNacimiento,
      EstadoPersona: datos.estadoPersona
    }

    return _persona;
  }

  // > Filtra el término ingresado.
  onSearchTermChanged(term: string) {
    if (!term.trim()) {
      this._personaComponent.tableDatas = [...this._personaComponent.tableDatasOriginal];
      return;
    }

    const searchTerm = term.trim().toLowerCase();

    const filteredData = this._personaComponent.tableDatasOriginal.filter((item: any) =>
      Object.values(item).some((value) => {
        if (value !== null && value !== undefined) {
          return value.toString().toLowerCase().includes(searchTerm);
        }
        return false;
      })
    );

    this._personaComponent.tableDatas = filteredData;
  }
}
