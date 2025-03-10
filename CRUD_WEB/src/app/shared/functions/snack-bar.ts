import { MatSnackBar } from '@angular/material/snack-bar';

export class SnackBarHelper {
  constructor(private snackBar: MatSnackBar) {}

  showSnackBar(message: string, action: string = 'Cerrar', duration: number = 5000): void {
    this.snackBar.open(message, action, {
      duration,
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
  }
}
