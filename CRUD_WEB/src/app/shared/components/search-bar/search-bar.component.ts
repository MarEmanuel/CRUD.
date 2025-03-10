import { Component, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-bar',
  imports: [
    CommonModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './search-bar.component.html',
  styleUrl: './search-bar.component.css'
})
export class SearchBarComponent {
  searchTerm: string = '';

  @Output() searchChanged: EventEmitter<string> = new EventEmitter<string>();

  onSearchChange() {
    this.searchChanged.emit(this.searchTerm);
  }

  onSearch() {
    // Emite el valor de la búsqueda cuando se hace clic en el botón
    this.searchChanged.emit(this.searchTerm);
  }
}
