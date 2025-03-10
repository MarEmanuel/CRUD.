import { Component, EventEmitter, Input, Optional, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { provideNativeDateAdapter } from '@angular/material/core';
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogRef } from '@angular/material/dialog';
import { ModalAlertComponent } from '../modal-alert/modal-alert.component';
import { MaterialModule } from '../../../modules/material.module';
import { SnackBarHelper } from '../../functions/snack-bar';
import { MatSnackBar } from '@angular/material/snack-bar';

export interface FormField {
  name: string;
  label: string;
  type: 'text' | 'password' | 'email' | 'number' | 'textarea' | 'datepicker' | 'select' | 'numeric_text';
  value?: string;
  options?: {
    value: string;
    label: string
  }[];
  required: boolean;
  maxLength?: number
}

export interface ButtonDesign {
  color: string;
  label: string;
  type: string;
}

@Component({
  selector: 'app-dynamic-form',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MaterialModule
  ],
  templateUrl: './dynamic-form.component.html',
  providers: [
    {
      provide: MAT_DATE_FORMATS,
      useValue: {
        display: {
          dateInput: 'DD/MM/YYYY',
          monthYearLabel: 'MM/YYYY',
          dateA11yLabel: 'LL',
          monthDayLabel: 'MM/DD',
        },
        parse: {
          dateInput: 'DD/MM/YYYY',
        }
      }
    },
    {
      provide: MAT_DATE_LOCALE,
      useValue: 'es-ES',
    },
    provideNativeDateAdapter()
  ],
  styleUrl: './dynamic-form.component.css'
})
export class DynamicFormComponent {

  private snackBarHelper: SnackBarHelper;

  @Input() fields: FormField[] = [];
  @Input() buttons: ButtonDesign[] = [];
  
  @Output() submit = new EventEmitter<any>();
  @Output() cancel = new EventEmitter<void>();
  form: FormGroup;
  dialogRef: any;
  
  @Input() showCancel: boolean = true;

  showPassword: boolean = false;
  
  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  constructor(
    private fb: FormBuilder, 
    private snackBar: MatSnackBar,
    @Optional() dialogRef?: MatDialogRef<ModalAlertComponent>
    ) {
    this.form = this.fb.group({});
    dialogRef: MatDialogRef;
    this.snackBarHelper = new SnackBarHelper(this.snackBar);
  }

  ngOnInit() {
    if (!this.fields || this.fields.length === 0) {
      console.warn('No se han definido campos para el formulario.');
      return;
    }

    this.fields.forEach(field => {
      const validators = [];
      if (field.required) {
        validators.push(Validators.required);
      }
      if (field.type === 'email') {
        validators.push(Validators.email);
      }
      if (field.type === 'number') {
        validators.push(this.nonNegativeValidator());
      }
      if (field.type === 'numeric_text') {
        validators.push(Validators.pattern('^[0-9]+$'));
      }

      this.form.addControl(
        field.name,
        this.fb.control(field.value || '', validators)
      );
    });
  }
  
  onSubmit() {
    if (this.form.valid) {
      this.submit.emit(this.form.value);
    } else {
      this.snackBarHelper.showSnackBar("Por favor, complete todos los campos.");
      this.getFormErrors();
    }
  }

  onCancel() {
    this.form.reset();
    if (this.dialogRef) {
      this.dialogRef.close();
    }
    this.cancel.emit();
  }

  private nonNegativeValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;
      return value != null && value < 0 ? { nonNegative: true } : null;
    };
  }

  private getFormErrors(): { [key: string]: string[] } {
    const errors: { [key: string]: string[] } = {};
    Object.keys(this.form.controls).forEach(key => {
      const controlErrors = this.form.get(key)?.errors;
      if (controlErrors) {
        errors[key] = Object.keys(controlErrors).map(errorKey => errorKey);
      }
    });
    return errors;
  }
}