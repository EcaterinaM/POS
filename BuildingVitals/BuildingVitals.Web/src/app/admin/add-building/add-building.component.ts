import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Building } from '../shared/models/_building';
import { AuthenticationHelper } from 'src/app/shared';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BuildingService } from '../shared/services/building.service';

@Component({
  selector: 'app-add-building',
  templateUrl: './add-building.component.html',
  styleUrls: ['./add-building.component.scss']
})
export class AddBuildingComponent implements OnInit {
  buildingForm: FormGroup;
  building: Building;
  constructor(private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<AddBuildingComponent>,
    private authHelper: AuthenticationHelper,
    private jwtHelperService: JwtHelperService,
    private buildingService: BuildingService) { }

  ngOnInit() {
    this.building = new Building();
    this.buildingForm = this.formBuilder.group({
      'name': [this.building.name, Validators.required],
      'address': [this.building.address, Validators.required],
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }

  saveBuilding() {
    if (this.buildingForm.invalid) {
      this.buildingForm.markAsDirty();
      return;
    }
    this.building = this.buildingForm.value;

    let token = this.authHelper.getUserTokens().accessToken;
    this.building.ownerId = this.jwtHelperService.decodeToken(token)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

    this.buildingService.save(this.building).subscribe(
      (data) => {
        this.dialogRef.close(data);
      }
    );
  }
}
