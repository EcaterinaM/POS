import { Observable, Subject } from 'rxjs';

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { JwtHelperService } from '@auth0/angular-jwt';

import { environment } from '../../../../environments/environment';

import { AuthenticationHelper, ServiceHelper } from '../../helpers';
import { CredentialsModel, TokensAuthenticationModel } from '../../models';
import { LocalStorageConstants, RouteConstants, UserRolesConstants, TokenClaimsConstants } from '../../constants';

import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  baseServiceUrl: string;
  loginObservable = new Subject<any>();

  constructor(private authenticationHelper: AuthenticationHelper,
    private httpClient: HttpClient,
    private serviceHelper: ServiceHelper,
    private localStorageService: LocalStorageService,
    private jwtHelperService: JwtHelperService,
    private router: Router) {
    this.baseServiceUrl = environment.serviceUrl;
  }

  clientSideLogout() {
    this.localStorageService.clearAll();
    this.router.navigate([RouteConstants.login]);
  }

  isAdminLoggedIn(): boolean {
    const accessToken = this.localStorageService.getItem(LocalStorageConstants.accessToken);
    const userRole = this.localStorageService.getItem(LocalStorageConstants.userRole);
    return accessToken && userRole === UserRolesConstants.admin;
  }

  isTenantLoggedIn(): boolean {
    const accessToken = this.localStorageService.getItem(LocalStorageConstants.accessToken);
    const userRole = this.localStorageService.getItem(LocalStorageConstants.userRole);
    return accessToken && userRole === UserRolesConstants.tenant;
  }

  login(user: CredentialsModel): Observable<TokensAuthenticationModel> {
    return this.httpClient.post<TokensAuthenticationModel>(`${this.baseServiceUrl}token`, user, this.serviceHelper.getHttpHeaders());
  }

  loginCallback(tokensAuthentication: TokensAuthenticationModel): void {
    this.authenticationHelper.storeUserTokens(tokensAuthentication);
    var userRole = this.jwtHelperService.decodeToken(tokensAuthentication.accessToken)[TokenClaimsConstants.role];
    this.localStorageService.setItem(LocalStorageConstants.userRole, userRole);
    this.loginObservable.next();
    if (userRole === UserRolesConstants.tenant) {
      this.router.navigate([RouteConstants.tenantDashboard]);
    }

    if (userRole === UserRolesConstants.admin) {
      this.router.navigate([RouteConstants.adminDashboard]);
    }
  }

  logout() {
    const tokensAuthenticationModel = this.authenticationHelper.getUserTokens();

    this.httpClient.put<TokensAuthenticationModel>(`${this.baseServiceUrl}logout`,
      tokensAuthenticationModel,
      this.serviceHelper.getHttpHeaders()).subscribe(
      () => {
        this.clientSideLogout();
      },
      () => {
        this.clientSideLogout();
      });
  }

  updateRefreshToken(tokensAuthenticationModel: TokensAuthenticationModel): Observable<TokensAuthenticationModel>  {
    return this.httpClient.put<TokensAuthenticationModel>(`${this.baseServiceUrl}refreshToken`, tokensAuthenticationModel, this.serviceHelper.getHttpHeaders());
  }

}
