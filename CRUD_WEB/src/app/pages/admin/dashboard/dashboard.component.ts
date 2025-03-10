import { Component, OnInit } from '@angular/core';
import { MaterialModule } from '../../../modules/material.module';
import { CommonModule } from '@angular/common';
import { DashboardService } from '../../services/dashboard-service';
import { SesionService } from '../../services/sesion-service';
import { ConvertDateTime } from '../../../shared/functions/date-hour-converter';
import { DashboardComponentConfig } from './dashboard.component.config';
import { ListTableComponent } from '../../../shared/components/list-table/list-table.component';

@Component({
  selector: 'app-dashboard',
  imports: [MaterialModule, CommonModule, ListTableComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {

  _dashboardComponent: any;

  constructor(
    private sesionService: SesionService,
    private dashboardService: DashboardService
  ) { }

  cards = [
    {
      icon: 'groups',
      title: 'Personas',
      subtitle: '¿Cuántas personas existen?',
      mainNumber: 0,
      active: 0,
      inactive: 0,
    },
    {
      icon: 'people',
      title: 'Usuarios',
      subtitle: '¿Cuántos usuarios existen?',
      mainNumber: 0,
      active: 0,
      inactive: 0,
    },
    {
      icon: 'lock_person',
      title: 'Roles',
      subtitle: '¿Qué roles existen?',
      mainNumber: 0,
      active: 0,
      inactive: 0,
    }
  ];

  ngOnInit() {
    this._dashboardComponent = DashboardComponentConfig;
    this.loadDashboardData();
    this.ObtenerSesiones();
  }

  ObtenerSesiones() {
    this.sesionService.ListarSesiones().subscribe({
      next: (response) => {
        const sessions = Array.isArray(response.data) ? [...response.data] : [];
        sessions.forEach(session => {
          session.fechaIngreso = ConvertDateTime(session.fechaIngreso);

          if (session.fechaEgreso === null) {
            session.fechaEgreso = "Sesión se mantiene activa";
          } else {
            session.fechaEgreso = ConvertDateTime(session.fechaEgreso);
          }
        });

        this._dashboardComponent.tableDatas = sessions;
        this._dashboardComponent.tableDatasOriginal = sessions;
      },
      error: (err) => {
        this._dashboardComponent.tableDatas = [];
        this._dashboardComponent.tableDatasOriginal = [];
      }
    });
  }

  loadDashboardData() {
    this.dashboardService.ListarDashboardAdmin().subscribe({
      next: (response) => {
        if (response.data && response.data.length > 0) {
          const dashboard = response.data[0];

          this.cards[0] = {
            ...this.cards[0],
            mainNumber: dashboard.totalPersonas,
            active: dashboard.personasActivas,
            inactive: dashboard.personasInactivas,
          };

          this.cards[1] = {
            ...this.cards[1],
            mainNumber: dashboard.totalUsuarios,
            active: dashboard.usuariosActivos,
            inactive: dashboard.usuariosInactivos,
          };

          this.cards[2] = {
            ...this.cards[2],
            mainNumber: dashboard.totalRoles,
            active: dashboard.rolesActivos,
            inactive: dashboard.rolesInactivos,
          };
        }
      }
    });
  }
}
