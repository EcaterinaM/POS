import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { AuthenticationHelper } from 'src/app/shared';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Tenant } from '../shared/models/_tenant';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {
  editProfileForm: FormGroup;
  tenant: Tenant;

  constructor(private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<EditProfileComponent>,
    private authHelper: AuthenticationHelper,
    private jwtHelperService: JwtHelperService) { }

  ngOnInit() {
    this.tenant = new Tenant();

    this.editProfileForm = this.formBuilder.group({
      'name': [this.tenant.name],
      'surname': [this.tenant.surname],
      'phonenumber': [this.tenant.phonenumber],
      'email':[this.tenant.email]
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }

  editProfile() {
  }
}
