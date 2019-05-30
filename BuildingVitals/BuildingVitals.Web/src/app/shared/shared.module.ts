import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartsModule } from 'ng2-charts';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { LoaderComponent, HeaderComponent, ChartComponent } from './components';
import { AuthenticationHelper, ServiceHelper } from './helpers';
import {
  AuthenticationService, JwtOptionsService, LoaderService, LocalStorageService,
  AdminNotAuthenticateGuard, TenantNotAuthenticateGuard,
  BaseService,
  RegisterService,
  UserService,
  SensorDataService
} from './services';
import { AuthenticationInterceptor } from './interceptors';

@NgModule({
  declarations: [
    LoaderComponent,
    HeaderComponent,
    ChartComponent,
  ],
  imports: [
    CommonModule,
    ChartsModule  ],
  exports: [
    LoaderComponent,
    HeaderComponent,
    ChartComponent
  ],
  providers: [
    AuthenticationHelper,
    ServiceHelper,

    RegisterService,
    UserService,

    BaseService,

    AuthenticationService,
    JwtOptionsService,
    LocalStorageService,
    LoaderService,
    SensorDataService,

    AdminNotAuthenticateGuard,
    TenantNotAuthenticateGuard,

    AuthenticationInterceptor,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthenticationInterceptor,
      multi: true
    }
  ]
})
export class SharedModule { }

