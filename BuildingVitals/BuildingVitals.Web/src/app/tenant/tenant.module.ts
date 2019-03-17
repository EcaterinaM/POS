import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared';

import { TenantRoutingModule } from './tenant.routing.module';

import { AuthenticationGuard } from './shared';

import { DashboardComponent } from './dashboard';

@NgModule({
  declarations: [
    DashboardComponent
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
