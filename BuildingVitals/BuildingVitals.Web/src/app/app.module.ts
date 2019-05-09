import { HttpClientModule } from '@angular/common/http';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { JwtModule, JWT_OPTIONS } from '@auth0/angular-jwt';

import { environment } from '../environments/environment';

import { jwtOptionsFactory } from './shared/factories';
import { JwtOptionsService, LocalStorageService } from './shared/services';

import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared';

import { AppComponent } from './app.component';

import { LoginComponent } from './login';
import { RegisterComponent } from './register/register.component';
import { NotificationComponent } from './shared/components/notification/notification.component';
import { MaterialModule } from './material.module';
import { AddBuildingComponent } from './admin/add-building/add-building.component';
import { EditProfileComponent } from './tenant/edit-profile/edit-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    NotificationComponent,
    AddBuildingComponent,
    EditProfileComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,

    AppRoutingModule,
    ServiceWorkerModule.register('./ngsw-worker.js', { enabled: environment.production }),
    SharedModule,
    JwtModule.forRoot({
      jwtOptionsProvider: {
        provide: JWT_OPTIONS,
        useFactory: jwtOptionsFactory,
        deps: [LocalStorageService, JwtOptionsService]
      }
    })
  ],
  providers: [{ provide: LocationStrategy, useClass: HashLocationStrategy }],
  entryComponents: [AddBuildingComponent, EditProfileComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
