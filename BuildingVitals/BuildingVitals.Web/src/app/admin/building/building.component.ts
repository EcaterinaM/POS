import { Component, OnInit } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { AddApartmentComponent } from '../add-apartment/add-apartment.component';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../shared';
import { Apartment } from '../shared/models/_apartment';


@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.scss']
})
export class BuildingComponent implements OnInit {
  currentBuildingId: string;
  apartments = {};
  curentFloor: string = "0";
  apartmentsReady: boolean = false;
  floors = ["0", "1", "2", "3", "4", "5"];
  constructor(public dialog: MatDialog,
    private route: ActivatedRoute,
    private apartmentService: ApartmentService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.currentBuildingId = params.get("id");
      this.getApartments();
    });
  }

  getApartments() {
    this.apartmentService.getAllApartments(this.currentBuildingId).subscribe(
      (data) => {
        for (let apartment of data) {
          let curentApartments = this.apartments[apartment.floor];
          if (!curentApartments) {
            this.apartments[apartment.floor] = [apartment];
          } else {
            curentApartments.push(apartment);
            this.apartments[apartment.floor] = curentApartments;
          }
        }
        this.apartmentsReady = true;
      }
    );

  }

  checkApartment(apartmentNumber: number) {
    if (this.apartments) {
      let apartmentsOnFloor = this.apartments[this.curentFloor];
      return apartmentsOnFloor.find(x => x.number == apartmentNumber) ? true : false;
    }
  }

  onApartmentClick(id: number) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "40%";
    let apartment = null;

    if (this.checkApartment(id)) {
      let apartmentsOnFloor = this.apartments[this.curentFloor];
      apartment = apartmentsOnFloor.find(x => x.number == id);
    }

    dialogConfig.data = {
      buildingId: this.currentBuildingId,
      existingApartmentId: apartment.id
    };
    const buildingDialogRef = this.dialog.open(AddApartmentComponent, dialogConfig);
    buildingDialogRef.afterClosed().subscribe(
      data => {
      }
    );
  }
}
