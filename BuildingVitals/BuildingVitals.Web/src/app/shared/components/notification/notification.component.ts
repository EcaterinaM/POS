import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {
  @Input() title: string;
  @Input() notificationText: string;
  @Input() type: string;
  @Input() show: boolean;

  constructor() { }

  ngOnInit() {
    setTimeout(function(){
      this.show = false;
    }, 100)
  }

}
