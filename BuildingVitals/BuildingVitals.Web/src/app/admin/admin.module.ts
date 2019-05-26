import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared';

import { AdminRoutingModule } from './admin.routing.module';

import { AuthenticationGuard } from './shared';
import { ApartmentService } from './shared';

import { BuildingComponent } from './building';
import { DashboardComponent } from './dashboard';
import { MaterialModule } from '../material.module';


@NgModule({
  declarations: [
    DashboardComponent,
    BuildingComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ],
  providers: [
    AuthenticationGuard,
    ApartmentService
  ]
})
export class AdminModule { }
