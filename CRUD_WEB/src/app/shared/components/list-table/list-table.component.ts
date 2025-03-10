import { Component, Input, OnInit, ViewChild, EventEmitter, Output, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

export interface TableColumn {
  name: string;
  displayName: string;
  isSortable?: boolean;
}

export interface TableData {
  [key: string]: any;
}

export interface TableAction {
  name: string;
  label: string;
  visible: boolean;
  color?: string;
  icon?: string;
}

@Component({
  selector: 'app-list-table',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginator,
    MatSort,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule
  ],
  templateUrl: './list-table.component.html',
  styleUrls: ['./list-table.component.css']
})
export class ListTableComponent implements OnInit {
  @Input() columns: TableColumn[] = [];
  @Input() data: TableData[] = [];
  @Input() actions: TableAction[] = [];

  @Output() editItem = new EventEmitter<TableData>();
  @Output() deleteItem = new EventEmitter<TableData>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  columnNames: string[] = [];
  displayedData: MatTableDataSource<TableData> = new MatTableDataSource();
  hasActions: boolean = false;

  constructor(private _paginator: MatPaginatorIntl) {
    _paginator.itemsPerPageLabel = 'Datos mostrados:';
  }

  ngOnInit() {
    this.columnNames = this.columns.map(c => c.name);
    this.hasActions = this.actions.some(action => action.visible);
  }

  ngAfterViewInit() {
    this.displayedData.paginator = this.paginator;
    this.displayedData.sort = this.sort;
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['data'] && changes['data'].currentValue) {
      this.displayedData.data = [...changes['data'].currentValue];
    }
  }

  onAction(action: TableAction, item: TableData) {
    switch (action.name) {
      case 'edit':
        this.editItem.emit(item);
        break;
      case 'delete':
        this.deleteItem.emit(item);
        break;
      default:
        console.warn('Acción desconocida:', action.name);
        break;
    }
  }
}
