import { Component, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  @Output() clickLogout = new EventEmitter<boolean>();

  constructor(private router: Router) {
  }

  logout() {
    this.clickLogout.emit();
  }
}
