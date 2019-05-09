import { Component, OnInit } from '@angular/core';
import { MatDialogConfig, MatDialog } from '@angular/material';
import { AddBuildingComponent } from '../add-building/add-building.component';
import { Building } from '../shared/models/_building';
import { BuildingService } from '../shared';
import { AuthenticationHelper } from 'src/app/shared';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
  buildings: Building[];

  constructor(public dialog: MatDialog,
    private buildingsService: BuildingService,
    private jwtHelperService: JwtHelperService,
    private authHelper: AuthenticationHelper) { }

  ngOnInit() {
    let token = this.authHelper.getUserTokens().accessToken;
    let ownerId = this.jwtHelperService.decodeToken(token)["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

    this.buildingsService.getAllBuildings(ownerId).subscribe(
      (data) => {
        this.buildings = data;
      }
    );
  }

  addNewBuilding() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "40%";
    const buildingDialogRef = this.dialog.open(AddBuildingComponent, dialogConfig);
    buildingDialogRef.afterClosed().subscribe(
      data => {
        console.log(data);
      }
    );
  }


}
