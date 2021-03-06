import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared';

import { TenantRoutingModule } from './tenant.routing.module';

import { AuthenticationGuard } from './shared';

import { DashboardComponent } from './dashboard';
import { TemperatureComponent } from './sensors';
import { HumidityComponent } from './sensors';

@NgModule({
  declarations: [
    DashboardComponent,
    TemperatureComponent,
    HumidityComponent
  ],
  imports: [
    CommonModule,
    TenantRoutingModule,
    SharedModule
  ],
  providers: [
    AuthenticationGuard
  ]
})
export class TenantModule { }
