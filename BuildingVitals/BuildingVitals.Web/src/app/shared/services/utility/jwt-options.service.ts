import { Injectable } from '@angular/core';

import { environment } from '../../../../environments/environment';

import { NotAuthorizedRoutesConstants } from '../../constants';

@Injectable({
  providedIn: 'root'
})
export class JwtOptionsService {
  getWhitelistedDomains(): string[] {
    const serviceDomain = environment.serviceUrl.split('//')[1];
    return[serviceDomain.substring(0, serviceDomain.indexOf('/'))];
  }

  getBlacklistedRoutes(): string[] {
    const routes = NotAuthorizedRoutesConstants.routes;
    let blacklistedRoutes = [];
    for (let route of routes) {
      let blacklistedRoute = environment.serviceUrl + route;
      blacklistedRoutes.push(blacklistedRoute);
    }
    return blacklistedRoutes;
  }
}
