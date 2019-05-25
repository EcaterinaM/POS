import { Component, OnInit } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { AddApartmentComponent } from '../add-apartment/add-apartment.component';


@Component({
  selector: 'app-building',
  templateUrl: './building.component.html',
  styleUrls: ['./building.component.scss']
})
export class BuildingComponent implements OnInit{
  currentBuildingId: string;
  constructor(
    public dialog: MatDialog){}

  ngOnInit(): void {
  }

  addNewApartment(){
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "40%";
    const buildingDialogRef = this.dialog.open(AddApartmentComponent, dialogConfig);
    buildingDialogRef.afterClosed().subscribe(
      data => {
        // this.getBuildings();
      }
    );
  }
}
