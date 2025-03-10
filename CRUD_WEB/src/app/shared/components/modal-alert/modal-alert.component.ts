import { Component, EventEmitter, Inject, Output } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogActions,
  MatDialogContent,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { 
  ButtonDesign, 
  DynamicFormComponent, 
  FormField 
} from '../dynamic-form/dynamic-form.component';
import { CommonModule } from '@angular/common';

export enum HeaderColor {
  Red = '#800000',
  Blue = '#3498DB',
  DarkBlue = '191970'
}

export interface ModalAlert {
  header_color: HeaderColor;
  title: string;
  icon: string;
  message?: string;
  fields?: FormField[];
  value?: string;
  showButtons?: boolean
  buttons?: ButtonDesign[];
}

export function ModalDataValues(
  _color: HeaderColor, 
  _title: string, 
  _icon: string,
  _buttons?: ButtonDesign[], 
  _message?: string,
  _fields?: FormField[],
  _showButtons?: boolean
) 
{
  const modalData = { 
      header_color: _color,
      title: _title, 
      icon: _icon,
      message: _message,
      fields: _fields,
      showButtons: _showButtons,
      buttons: _buttons
  };

  return modalData;
}

@Component({
  selector: 'app-modal-alert',
  imports: [
    MatDialogContent, 
    MatDialogActions, 
    MatButtonModule, 
    DynamicFormComponent, 
    MatIcon, 
    CommonModule
  ],
  templateUrl: './modal-alert.component.html',
  styleUrl: './modal-alert.component.css'
})
export class ModalAlertComponent {

  fields: any[] = [];
  buttons: any[] = [];

  @Output() submit = new EventEmitter<any>();
  @Output() cancel = new EventEmitter<void>();

  constructor(
    public dialogRef: MatDialogRef<ModalAlertComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ModalAlert
  ) {
    if (data.fields) {
      this.fields = data.fields || [];
    }
    if (data.buttons) {
      this.buttons = data.buttons || [];
    }
  }

  onConfirm(formValue: any): void {
    this.submit.emit(formValue);
    this.dialogRef.close();
  }
  
  onCancel(): void {
    this.cancel.emit();
    this.dialogRef.close();
  }
}
