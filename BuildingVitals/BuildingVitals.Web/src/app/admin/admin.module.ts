import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared';

import { AdminRoutingModule } from './admin.routing.module';

import { AuthenticationGuard } from './shared';

import { DashboardComponent } from './dashboard';

@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  providers: [
    AuthenticationGuard
  ]
})
export class AdminModule { }
