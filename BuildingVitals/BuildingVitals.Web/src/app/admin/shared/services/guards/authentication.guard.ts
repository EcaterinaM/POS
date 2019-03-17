import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

import { AuthenticationService } from '../../../../shared';
import { RouteConstants } from '../../../../shared';

@Injectable()
export class AuthenticationGuard implements CanActivate {

  constructor(private authenticationService: AuthenticationService,
    private router: Router) { }

  canActivate() {
    if (this.authenticationService.isAdminLoggedIn()) {
      return true;
    }
    this.router.navigate([RouteConstants.login]);
    return false;
  }
}
