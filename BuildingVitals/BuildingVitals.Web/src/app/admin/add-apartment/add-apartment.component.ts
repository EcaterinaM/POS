import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { AddApartment } from '../shared/models';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../shared';

@Component({
  selector: 'app-add-apartment',
  templateUrl: './add-apartment.component.html',
  styleUrls: ['./add-apartment.component.scss']
})
export class AddApartmentComponent implements OnInit {
  apartmentForm: FormGroup;
  apartment: AddApartment;
  currentBuildingId: string;

  constructor(private activeRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private dialogRef: MatDialogRef<AddApartmentComponent>,
    private apartmentService: ApartmentService) { }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => {
        if(params['id']) {
           this.currentBuildingId = params['id'];
        }
    })
    this.apartment = new AddApartment();
    this.apartmentForm = this.formBuilder.group({
      'name': [this.apartment.name, Validators.required],
      'surname': [this.apartment.surname, Validators.required],
      'userName': [this.apartment.userName, Validators.required],
      'email': [this.apartment.email, Validators.required],
      'password': [this.apartment.password, Validators.required],
      'phoneNumber': [this.apartment.phoneNumber, Validators.required],
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
