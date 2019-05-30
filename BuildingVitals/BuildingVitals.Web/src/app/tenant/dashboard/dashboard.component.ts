import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material';

import { EditProfileComponent } from '../edit-profile/edit-profile.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent {

  constructor(public dialog: MatDialog,
    private router: Router) { }

  editProfile() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "40%";
    const buildingDialogRef = this.dialog.open(EditProfileComponent, dialogConfig);
    buildingDialogRef.afterClosed().subscribe(
      data => {
      }
    );
  }

  redirect(route: string): void {
    this.router.navigateByUrl(route);
  }
}
