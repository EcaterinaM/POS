import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../shared';
import { Apartment } from '../shared/models/_apartment';

@Component({
  selector: 'app-add-apartment',
  templateUrl: './add-apartment.component.html',
  styleUrls: ['./add-apartment.component.scss']
})
export class AddApartmentComponent implements OnInit {
  apartmentForm: FormGroup;
  apartment: Apartment;
  currentBuildingId: string;
  existingApartmentId: string;
  dialogType: number = 0;
  constructor(@Inject(MAT_DIALOG_DATA) data,
    private activeRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<AddApartmentComponent>,
    private apartmentService: ApartmentService) {
    this.dialogType = data.dialogType;
    this.currentBuildingId = data.buildingId;
    if (this.dialogType == 0) {
      this.existingApartmentId = data.existingApartmentId;
    }
  }

  ngOnInit() {
    if (this.dialogType == 0) {
      this.apartmentService.getApartmentById(this.existingApartmentId).subscribe(
        (data) => {
          this.apartment = data;
          this.configureApartmentForm();
        }
      );
    } else {
      this.apartment = new Apartment();
      this.configureApartmentForm();
    }
  
  }

  configureApartmentForm() {
    this.apartmentForm = this.formBuilder.group({
      'name': [this.apartment.owner.name, Validators.required],
      'surname': [this.apartment.owner.surname, Validators.required],
      'userName': [this.apartment.owner.name, Validators.required],
      'email': [this.apartment.owner.email, Validators.required],
      'password': [this.apartment.owner.password, Validators.required],
      'phoneNumber': [this.apartment.owner.phonenumber, Validators.required],
      'floor': [this.apartment.floor, Validators.required],
      'number': [this.apartment.number, Validators.required],
      'buildingId': [this.apartment.buildingId],
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }

  saveApartment() {
    if (this.apartmentForm.invalid) {
      this.apartmentForm.markAsDirty();
      return;
    }
    this.apartment = this.apartmentForm.value;

    this.apartment.buildingId = this.currentBuildingId;

    this.apartmentService.save(this.apartment).subscribe(
      (data) => {
        this.dialogRef.close(data);
      }
    );
  }
}
