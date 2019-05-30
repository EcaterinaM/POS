import { Component, OnInit, Input, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../shared';
import { AddApartment } from '../shared/models';
import { Apartment } from '../shared/models/_apartment';

@Component({
  selector: 'app-add-apartment',
  templateUrl: './add-apartment.component.html',
  styleUrls: ['./add-apartment.component.scss']
})
export class AddApartmentComponent implements OnInit {
  apartmentForm: FormGroup;
  apartment: AddApartment;
  currentBuildingId: string;
  existingApartmentId: string;
  dialogType: number = 0;
  existingApartment: Apartment;
  formReady: boolean = false;
  floor: string;
  apartmentNumber: number;
  constructor(@Inject(MAT_DIALOG_DATA) data,
    private activeRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<AddApartmentComponent>,
    private apartmentService: ApartmentService) {
        this.dialogType = data.dialogType;
        this.currentBuildingId = data.buildingId;
        this.floor = data.floor;
        this.apartmentNumber = data.apartmentNumber;
        if(this.dialogType == 0) {
          this.existingApartmentId = data.existingApartmentId;
        }
  }

  ngOnInit() {
    if (this.dialogType == 0) {
      this.apartmentService.getApartmentById(this.existingApartmentId).subscribe(
        (data) => {
          this.existingApartment = data;
          this.configureExistingApartment();
        }
      );
    } else {
      this.apartment = new AddApartment();
      this.configureApartmentForm();
    }
  }

  configureExistingApartment() {
    this.apartmentForm = this.formBuilder.group({
      'name': [this.existingApartment.owner.name, Validators.required],
      'surname': [this.existingApartment.owner.surname, Validators.required],
      'email': [this.existingApartment.owner.email, Validators.required],
      'phoneNumber': [this.existingApartment.owner.phonenumber, Validators.required],
      'floor': [this.floor, Validators.required],
      'number': [this.apartmentNumber, Validators.required],
      'buildingId': [this.existingApartment.buildingId],

    });
    this.apartmentForm.disable();
    this.formReady = true;
  }

  configureApartmentForm() {
    this.apartmentForm = this.formBuilder.group({
      'name': [this.apartment.name, Validators.required],
      'surname': [this.apartment.surname, Validators.required],
      'userName': [this.apartment.name, Validators.required],
      'email': [this.apartment.email, Validators.required],
      'password': [this.apartment.password, Validators.required],
      'phoneNumber': [this.apartment.phoneNumber, Validators.required],
      'floor': [this.floor, Validators.required],
      'number': [this.apartmentNumber, Validators.required],
      'buildingId': [this.apartment.buildingId],
    });
    this.formReady = true;
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
    console.log(this.apartment);
    this.apartmentService.save(this.apartment).subscribe(
      (data) => {
        this.dialogRef.close(this.apartment);
      }
    );
  }
}
