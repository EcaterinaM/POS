import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';

import { AdminNotAuthenticateGuard, TenantNotAuthenticateGuard } from './shared';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [ AdminNotAuthenticateGuard, TenantNotAuthenticateGuard ],
    pathMatch: 'full'
  },
  {
    path: 'tenant',
    loadChildren: './tenant/tenant.module#TenantModule'
  },
  {
    path: 'admin',
    loadChildren: './admin/admin.module#AdminModule'
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
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
  
}
