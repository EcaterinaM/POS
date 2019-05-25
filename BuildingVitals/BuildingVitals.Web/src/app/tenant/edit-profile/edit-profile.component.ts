import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { AuthenticationHelper } from 'src/app/shared';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Tenant } from '../shared/models/_tenant';

import { UserService } from '../../shared/services/model-services/user.service';
import { UserModel } from '../../shared/models/user.model';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent {
  editProfileForm: FormGroup;
  tenant: UserModel;
  isFormSubmitted: boolean;
  username: string;

  constructor(private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<EditProfileComponent>,
    private authHelper: AuthenticationHelper,
    private jwtHelperService: JwtHelperService,
    private userService: UserService) {

    let token = this.authHelper.getUserTokens().accessToken;
    this.username = this.jwtHelperService.decodeToken(token)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    this.getUserInformation();
  }


  editProfile() {
    this.isFormSubmitted = true;
    if (this.editProfileForm.valid) {
      this.tenant = this.editProfileForm.value;
      this.userService.editUser(this.tenant, this.username).subscribe(() => {
        this.closeDialog();
      });
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }

  private async getUserInformation() {
    this.userService.getUserDetails(this.username)
      .subscribe((user) => {
        this.tenant = user;
        this.createForm();
      });
  }

  private createForm() {
    this.editProfileForm = this.formBuilder.group({
      'name': [this.tenant.name],
      'surname': [this.tenant.surname],
      'phonenumber': [this.tenant.phoneNumber],
      'email': [this.tenant.email]
    });
    this.isFormSubmitted = false;
  }
}
