import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from './shared';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  isUserLoggedIn: boolean;

  constructor(
    private readonly authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.setIsUserLoggedIn();
    this.listenToUserLogIn();
  }

  onClickLogout(): void {
    this.authenticationService.logout();
    this.isUserLoggedIn = false;
  }

  private listenToUserLogIn() {
    this.authenticationService.loginObservable.subscribe(() => {
      this.isUserLoggedIn = true;
    });
  }

  private setIsUserLoggedIn() {
    this.isUserLoggedIn = this.authenticationService.isAdminLoggedIn() || this.authenticationService.isTenantLoggedIn();
  }
}

