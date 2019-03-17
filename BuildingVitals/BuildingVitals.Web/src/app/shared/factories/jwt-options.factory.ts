import { LocalStorageConstants } from '../constants';
import { JwtOptionsService, LocalStorageService } from '../services';

export function jwtOptionsFactory(localStorageService: LocalStorageService, jwtOptionsService: JwtOptionsService) {
  return {
    tokenGetter: () => {
      return localStorageService.getItem(LocalStorageConstants.accessToken);
    },
    whitelistedDomains: jwtOptionsService.getWhitelistedDomains(),
    blacklistedRoutes: jwtOptionsService.getBlacklistedRoutes()
  }
}
