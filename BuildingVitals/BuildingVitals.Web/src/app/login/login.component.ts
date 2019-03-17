import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthenticationService } from '../shared';
import { PathServicesConstants } from '../shared';
import { CredentialsModel, TokensAuthenticationModel } from '../shared';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  isFormSubmitted = false;
  pathServiceConstants = PathServicesConstants;
  invalidCredentials: boolean;

  loginForm: FormGroup;
  credentialsModel: CredentialsModel;

  constructor(private authenticationService: AuthenticationService,
    private loginFormBuilder: FormBuilder) { }

  ngOnInit() {
    this.credentialsModel = new CredentialsModel();
    this.loginForm = this.generateLoginFormBuilder(this.credentialsModel);
  }

  submitForm() {
    this.isFormSubmitted = true;
    if (this.loginForm.valid) {
      this.credentialsModel = this.loginForm.value;

      this.authenticationService.login(this.credentialsModel).subscribe(
        (tokensAuthentication: TokensAuthenticationModel) => {
          this.authenticationService.loginCallback(tokensAuthentication);
        },
        (error) => {
          if (error.status === 401) {
            this.invalidCredentials = true;
            this.isFormSubmitted = false;
          }
        });
    }
  }

  transformImage(backgroundImage: string) {
    return "url('" + backgroundImage + "')";
  }

  generateLoginFormBuilder(credentialsModel: CredentialsModel): FormGroup {
    return this.loginFormBuilder.group({
      username: [credentialsModel.username, Validators.required],
      password: [credentialsModel.password, Validators.required]
    });
  }
}
