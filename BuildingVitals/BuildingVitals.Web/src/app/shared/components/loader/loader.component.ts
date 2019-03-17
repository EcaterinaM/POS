import { Component } from '@angular/core';
import { LoaderService } from '../../services';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})

export class LoaderComponent {

  constructor(public loaderService: LoaderService) {
  }

}
