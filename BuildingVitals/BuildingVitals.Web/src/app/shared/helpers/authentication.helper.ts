import { Injectable } from '@angular/core';

import { TokensAuthenticationModel } from '../models';
import { LocalStorageConstants } from '../constants';
import { LocalStorageService } from '../services/utility/local-storage.service';

@Injectable()
export class AuthenticationHelper {

  constructor(private localStorageService: LocalStorageService) { }

  storeUserTokens(tokensAuthentication: TokensAuthenticationModel): void {
    this.localStorageService.setItem(LocalStorageConstants.accessToken, tokensAuthentication.accessToken);
    this.localStorageService.setItem(LocalStorageConstants.refreshToken, tokensAuthentication.refreshToken);
    this.localStorageService.setItem(LocalStorageConstants.loginProvider, tokensAuthentication.loginProvider);
  }

  getUserTokens(): TokensAuthenticationModel {
    const tokensAuthenticationModel = new TokensAuthenticationModel();
    tokensAuthenticationModel.accessToken = this.localStorageService.getItem(LocalStorageConstants.accessToken);
    tokensAuthenticationModel.loginProvider = this.localStorageService.getItem(LocalStorageConstants.loginProvider);
    tokensAuthenticationModel.refreshToken = this.localStorageService.getItem(LocalStorageConstants.refreshToken);
    return tokensAuthenticationModel;
  }
}
