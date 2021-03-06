import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthenticationGuard } from './shared';

import { DashboardComponent } from './dashboard';
import { BuildingComponent } from './building';


const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthenticationGuard],
    pathMatch: 'full'
  },
  {
    path: 'building/:id',
    component: BuildingComponent,
    canActivate: [AuthenticationGuard],
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]

})
export class AdminRoutingModule { }
