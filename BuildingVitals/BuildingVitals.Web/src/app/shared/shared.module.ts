import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { LoaderComponent, HeaderComponent } from './components';
import { AuthenticationHelper, ServiceHelper } from './helpers';
import {
  AuthenticationService, JwtOptionsService, LoaderService, LocalStorageService,
  AdminNotAuthenticateGuard, TenantNotAuthenticateGuard,
  BaseService
} from './services';

@NgModule({
  declarations: [
    LoaderComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LoaderComponent,
    HeaderComponent
  ],
  providers: [
    AuthenticationHelper,
    ServiceHelper,

    BaseService,

    AuthenticationService,
    JwtOptionsService,
    LocalStorageService,
    LoaderService,

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

import { AuthenticationInterceptor } from './interceptors';
