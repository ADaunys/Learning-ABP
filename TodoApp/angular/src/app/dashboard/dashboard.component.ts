import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'TodoApp.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'TodoApp.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
