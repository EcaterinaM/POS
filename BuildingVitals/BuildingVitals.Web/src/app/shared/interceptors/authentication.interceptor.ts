import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError as observableThrowError, BehaviorSubject } from 'rxjs';
import { catchError, switchMap, finalize, filter, take, map } from 'rxjs/operators';

import { AuthenticationService, JwtOptionsService, LoaderService, LocalStorageService } from '../services';
import { LocalStorageConstants } from '../constants';
import { AuthenticationHelper } from '../helpers';
import { TokensAuthenticationModel } from '../models';


@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {


  isRefreshingToken: boolean = false;
  tokenSubject = new BehaviorSubject<string>(null);

  constructor(private authenticationHelper: AuthenticationHelper,
    private authenticationService: AuthenticationService,
    private jwtOptionsService: JwtOptionsService,
    private loaderService: LoaderService,
    private localStorageService: LocalStorageService
  ) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.loaderService.showApplicationLoader();

    return next.handle(request)
      .pipe(
        (catchError(error => {
          if (error.status === 401 && this.isAuthorizedRoute(request.url)) {
            return this.handle401Error(request, next);
          } else if (this.isServerError(error.status)) {
            //this.appToasterService.error();
          }

          return observableThrowError(error);
        })) as any,
        finalize(() => {
          this.loaderService.hideApplicationLoader();
        })) as any;
  }

  private isAuthorizedRoute(route: string): boolean {
    const notAuthorizedRoutes = this.jwtOptionsService.getBlacklistedRoutes();
    for (let notAuthorizedRoute of notAuthorizedRoutes) {
      if (notAuthorizedRoute === route) {
        return false;
      }
    }
    return true;
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
    if (!this.isRefreshingToken) {
      this.isRefreshingToken = true;

      this.tokenSubject.next(null);

      return this.updateRefreshToken()
        .pipe(
          (switchMap(() => {
            const accessToken = this.localStorageService.getItem(LocalStorageConstants.accessToken);
            if (accessToken) {
              this.tokenSubject.next(accessToken);
              return next.handle(request);
            }
          })) as any,
          catchError(error => {
            return observableThrowError(error);
          }),
          finalize(() => {
            this.isRefreshingToken = false;
          }));
    } else {
      this.isRefreshingToken = false;
      return this.tokenSubject.pipe(
        (filter(token => token != null)) as any,
        take(1),
        switchMap(() => {
          const accessToken = this.localStorageService.getItem(LocalStorageConstants.accessToken);
          if (accessToken) {
            return next.handle(request);
          }
        }));
    }
  }

  private updateRefreshToken() {
    this.loaderService.showApplicationLoader();
    const tokenAuthenticationModel = this.authenticationHelper.getUserTokens();
    return this.authenticationService.updateRefreshToken(tokenAuthenticationModel).pipe(
      (map((userTokens: TokensAuthenticationModel) => {
        this.authenticationHelper.storeUserTokens(userTokens);
        this.loaderService.hideApplicationLoader();

      })) as any,
      catchError(error => {
        this.authenticationService.clientSideLogout();
        this.loaderService.hideApplicationLoader();
        return observableThrowError(error);
      })
    );
  }

  private isServerError(statusCode): boolean {
    return statusCode.toString()[0] === '5' || statusCode.toString() === '0';
  }
}
