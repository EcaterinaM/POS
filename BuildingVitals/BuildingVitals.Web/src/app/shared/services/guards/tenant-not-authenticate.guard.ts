import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { AuthenticationService } from '../utility';
import { RouteConstants } from '../../constants';

@Injectable()
export class TenantNotAuthenticateGuard implements CanActivate {

  constructor(private authenticationService: AuthenticationService,
    private router: Router) { }

  canActivate() {
    if (!this.authenticationService.isTenantLoggedIn()) {
      return true;
    }
    this.router.navigate([RouteConstants.tenantDashboard]);
    return false;
  }
}
